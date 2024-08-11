using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarKindred.Common.Entities;

namespace StarKindred.API.Database.Models;

public class AllianceLog : IEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

    public Guid AllianceId { get; set; }
    public Alliance? Alliance { get; set; }

    public string Message { get; set; } = null!;
    public AllianceLogActivityType ActivityType { get; set; }

    public class Configuration : IEntityTypeConfiguration<AllianceLog>
    {
        public void Configure(EntityTypeBuilder<AllianceLog> builder)
        {
            builder.HasIndex(x => x.CreatedOn);

            builder.Property(x => x.ActivityType).HasConversion<string>().HasMaxLength(20);
        }
    }
}