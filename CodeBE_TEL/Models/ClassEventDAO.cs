using System;
using System.Collections.Generic;

namespace GenModels.Models;

public partial class ClassEventDAO
{
    public long Id { get; set; }

    public long ClassroomId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool IsNotification { get; set; }

    public string? Description { get; set; }

    public bool Oder { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime EndAt { get; set; }

    public DateTime UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual ClassroomDAO Classroom { get; set; } = null!;

    public virtual ICollection<CommentDAO> Comments { get; set; } = new List<CommentDAO>();

    public virtual ICollection<QuestionDAO> Questions { get; set; } = new List<QuestionDAO>();
}
