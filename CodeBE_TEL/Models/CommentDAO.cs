using System;
using System.Collections.Generic;

namespace CodeBE_TEL.Models;

public partial class CommentDAO
{
    public long Id { get; set; }

    public long ClassEventId { get; set; }

    public string Description { get; set; } = null!;

    public long? AppUserId { get; set; }
    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual AppUserDAO? AppUser { get; set; }

    public virtual ClassEventDAO ClassEvent { get; set; } = null!;
}
