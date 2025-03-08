namespace Core.Persistence.Entities;

public abstract class Entity<TId>
{
    public TId Id { get; set; } = default!;
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public DateTime? UpdateTime { get; set; }
    public bool IsDeleted { get; set; } = false;
}