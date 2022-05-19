using CompletelyDifferentDean.Infrastructure.Services;
using CompletelyDifferentDean.Infrastructure.Timing;
using CompletelyDifferentDean.Model.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompletelyDifferentDean.Database;

public sealed class AppDbContext : IdentityDbContext
{
    private readonly ICurrentUserService _currentUserService = default!;

    public AppDbContext(DbContextOptions options) : base(options) { }

    public AppDbContext(
            DbContextOptions options,
            ICurrentUserService currentUserService)
            : base(options)
    {
        _currentUserService = currentUserService;
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.WasCreated(Clock.Now, _currentUserService?.UserId ?? "");
                    break;
                case EntityState.Modified:
                    entry.Entity.WasModified(Clock.Now, _currentUserService?.UserId ?? "");
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
