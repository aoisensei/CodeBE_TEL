using CodeBE_TEL.Entities;
using System;
using System.Collections.Generic;

namespace CodeBE_TEL.Models;

public partial class AppUserDAO
{
    public long Id { get; set; }

    public string UserName { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Gender { get; set; }

    public string? Password { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<ClassEventDAO> ClassEvents { get; set; } = new List<ClassEventDAO>();

    public virtual ICollection<CommentDAO> Comments { get; set; } = new List<CommentDAO>();

    public virtual ICollection<StudentAnswerDAO> StudentAnswers { get; set; } = new List<StudentAnswerDAO>();
    public virtual ICollection<StudentAnswerDAO> StudentAnswerFeedbacks { get; set; } = new List<StudentAnswerDAO>();
}
