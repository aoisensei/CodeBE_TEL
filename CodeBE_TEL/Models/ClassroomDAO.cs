using System;
using System.Collections.Generic;

namespace GenModels.Models;

public partial class ClassroomDAO
{
    public long Id { get; set; }

    public long AppUserId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual ICollection<ClassEventDAO> ClassEvents { get; set; } = new List<ClassEventDAO>();
}
