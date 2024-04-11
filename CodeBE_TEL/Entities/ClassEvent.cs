
using CodeBE_TEL.Common;

namespace CodeBE_TEL.Entities;

public class ClassEvent : IFilterable
{
    public long Id { get; set; }

    public long ClassroomId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool IsClassWork { get; set; }

    public bool Pinned { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? EndAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Classroom Classroom { get; set; } = null!;

    public List<Comment>? Comments { get; set; }

    public List<Question>? Questions { get; set; }
}
