using System;
using System.Collections.Generic;

namespace CodeBE_TEL.Entities;

public partial class Board
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    public bool IsFavourite { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public List<Card>? Cards { get; set; }
}
