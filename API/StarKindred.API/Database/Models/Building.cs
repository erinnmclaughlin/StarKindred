using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarKindred.Common.Entities;

namespace StarKindred.API.Database.Models;

public class Building : IEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public int Position { get; set; }

    public BuildingType Type { get; set; }

    public int Level { get; set; }

    public DateTimeOffset LastHarvestedOn { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset PowerLastActivatedOn { get; set; } = DateTimeOffset.UtcNow.Date;

    public class Configuration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasIndex(x => x.Position);
            builder.Property(x => x.Type).HasConversion<string>().HasMaxLength(20);
        }
    }
}