using Core.Persistence.Entities;

namespace TwixterR.Domain.Entities;

public sealed class UserFollower:Entity<Guid>
{
    public Guid FollowerId { get; set; } 
    public User Follower { get; set; } = null!;

    public Guid FollowingId { get; set; } 
    public User Following { get; set; } = null!;
    
}