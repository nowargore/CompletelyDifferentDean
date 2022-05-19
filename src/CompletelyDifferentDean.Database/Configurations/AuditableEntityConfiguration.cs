using CompletelyDifferentDean.Model.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompletelyDifferentDean.Database.Configurations;

public class AuditableEntityConfiguration /*: IEntityTypeConfiguration<AuditableEntity>*/
{
    public static void Configure<T>(EntityTypeBuilder<T> builder) where T : class, IAuditableEntity
    {
        builder.Property(e => e.CreatedBy).HasMaxLength(1024).IsRequired();
        builder.Property(e => e.LastModifiedBy).HasMaxLength(1024).IsRequired();
    }
}
