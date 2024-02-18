using System;
using System.Collections.Generic;

namespace CodeBE_TEL.Models;

public partial class CommentDAO
{
    public long Id { get; set; }

    public long ClassEventId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ClassEventDAO ClassEvent { get; set; } = null!;
}
