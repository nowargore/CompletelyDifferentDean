using CompletelyDifferentDean.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompletelyDifferentDean.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(e => e.Name).HasMaxLength(1024);

            builder.Property(e => e.Description).HasMaxLength(16 * 1024);

            AuditableEntityConfiguration.Configure(builder);
        }
    }
}
