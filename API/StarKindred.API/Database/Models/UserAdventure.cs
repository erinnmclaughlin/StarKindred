namespace StarKindred.API.Database.Models;

public class UserAdventure : IEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid AdventureId { get; set; }
    public Adventure? Adventure { get; set; }
}