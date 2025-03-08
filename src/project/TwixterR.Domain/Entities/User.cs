using Microsoft.AspNetCore.Identity;

namespace TwixterR.Domain.Entities;

public sealed class User : IdentityUser<Guid>
{
    public string? DisplayName { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? ProfileBackgroundPictureUrl { get; set; }
    public string? Bio { get; set; }
    public string? Location { get; set; }
    public string? Website { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    
    public ICollection<Post> Posts { get; set; } = new List<Post>();
    
    public ICollection<UserFollower> Followers { get; set; } = new List<UserFollower>();
    public ICollection<UserFollower> Followings { get; set; } = new List<UserFollower>();
    
    public ICollection<UserBlock> BlockedUsers { get; set; } = new List<UserBlock>();
    public ICollection<UserBlock> BlockedByUsers { get; set; } = new List<UserBlock>();
}