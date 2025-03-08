using Core.Persistence.Entities;

namespace TwixterR.Domain.Entities;

public sealed class UserBlock:Entity<Guid>
{
    public Guid BlockerId { get; set; } 
    public User Blocker { get; set; } = null!;

    public Guid BlockedId { get; set; } 
    public User Blocked { get; set; } = null!;
}