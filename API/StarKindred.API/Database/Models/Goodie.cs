using StarKindred.Common.Entities;

namespace StarKindred.API.Database.Models;

public class Goodie : IEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public int Location { get; set; }

    public ResourceType Type { get; set; }
    public int Quantity { get; set; }
}