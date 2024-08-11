using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarKindred.Common.Entities;

namespace StarKindred.API.Database.Models;

public class Treasure : IEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public TreasureType Type { get; set; }
    public int Quantity { get; set; }

    public class Configuration : IEntityTypeConfiguration<Treasure>
    {
        public void Configure(EntityTypeBuilder<Treasure> builder)
        {
            builder.Property(x => x.Type).HasConversion<string>().HasMaxLength(40);
        }
    }
}