namespace CodeBE_TEL.Entities;

public class Comment
{
    public long Id { get; set; }

    public long ClassEventId { get; set; }

    public string Description { get; set; } = null!;

    public ClassEvent ClassEvent { get; set; } = null!;
}
