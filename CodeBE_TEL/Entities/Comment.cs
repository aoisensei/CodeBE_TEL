namespace CodeBE_TEL.Entities;

public class Comment
{
    public long Id { get; set; }

    public long ClassEventId { get; set; }

    public string Description { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
    public long? JobId { get; set; }
    public long? AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
    public Job Job { get; set; } = null!;
    public ClassEvent ClassEvent { get; set; } = null!;
}
