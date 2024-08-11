using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarKindred.Common.Entities;

namespace StarKindred.API.Database.Models;

public class TownLeader : IEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public TownLeaderPosition Position { get; set; }

    public Guid VassalId { get; set; }
    public Vassal? Vassal { get; set; }

    public DateTimeOffset AssignedOn { get; set; } = DateTimeOffset.UtcNow;

    public class Configuration : IEntityTypeConfiguration<TownLeader>
    {
        public void Configure(EntityTypeBuilder<TownLeader> builder)
        {
            builder.HasIndex(x => new { x.UserId, x.Position }).IsUnique();

            builder.Property(x => x.Position).HasConversion<string>().HasMaxLength(20);
        }
    }
}