using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarKindred.Common.Entities;

namespace StarKindred.API.Database.Models;

public class PersonalLogTag : IEntity
{
    public Guid Id { get; set; }

    public Guid PersonalLogId { get; set; }
    public PersonalLog? PersonalLog { get; set; }

    public PersonalLogActivityType Tag { get; set; }

    public class Configuration : IEntityTypeConfiguration<PersonalLogTag>
    {
        public void Configure(EntityTypeBuilder<PersonalLogTag> builder)
        {
            builder.Property(x => x.Tag).HasConversion<string>().HasMaxLength(20);
        }
    }
}