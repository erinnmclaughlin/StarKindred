using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarKindred.API.Database.Models;

public class AnnouncementView : IEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public DateTimeOffset ViewedOn { get; set; }

    public class Configuration : IEntityTypeConfiguration<AnnouncementView>
    {
        public void Configure(EntityTypeBuilder<AnnouncementView> builder)
        {
            builder.HasOne(x => x.User).WithOne();
        }
    }
}