using System;
using System.Collections.Generic;

namespace CodeBE_TEL.Models;

public partial class CardDAO
{
    public long Id { get; set; }

    public long BoardId { get; set; }

    public string Name { get; set; } = null!;

    public int? Order { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual BoardDAO Board { get; set; } = null!;

    public virtual ICollection<JobDAO> Jobs { get; set; } = new List<JobDAO>();
}
