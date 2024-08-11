using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarKindred.Common.Entities;

namespace StarKindred.API.Database.Models;

public class Announcement : IEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
    public AnnouncementType Type { get; set; }
    public string Body { get; set; } = null!;

    public class Configuration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.HasIndex(x => x.CreatedOn);

            builder.Property(x => x.Type).HasConversion<string>().HasMaxLength(20);
        }
    }
}
