using Core.Persistence.Entities;

namespace TwixterR.Domain.Entities;

public sealed class Post : Entity<Guid>
{
    public string? Content { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public bool IsArchived { get; set; } = false;
    public ICollection<PostMedia> Media { get; set; } = new List<PostMedia>();
}