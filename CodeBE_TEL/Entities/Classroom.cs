namespace CodeBE_TEL.Entities;

public class Classroom
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public List<ClassEvent>? ClassEvents { get; set; }
}
