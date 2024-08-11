using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarKindred.Common.Entities;

namespace StarKindred.API.Database.Models;

public class Resource : IEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public ResourceType Type { get; set; }
    public int Quantity { get; set; }

    public class Configuration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.Property(x => x.Type).HasConversion<string>().HasMaxLength(20);
            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => new { x.UserId, x.Type }).IsUnique();
        }
    }
}