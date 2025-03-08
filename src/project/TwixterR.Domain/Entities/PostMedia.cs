using Core.Persistence.Entities;
using TwixterR.Domain.Enums;

namespace TwixterR.Domain.Entities;

public sealed class PostMedia : Entity<Guid>
{
    public Guid PostId { get; set; }
    public Post? Post { get; set; }
    public string MediaUrl { get; set; } = string.Empty;
    public string? MediaDescription { get; set; }
    public MediaType MediaType { get; set; }
    public int Order { get; set; } = 1;
}