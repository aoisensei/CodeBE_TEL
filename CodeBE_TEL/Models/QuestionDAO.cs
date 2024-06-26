using System;
using System.Collections.Generic;

namespace CodeBE_TEL.Models;

public partial class QuestionDAO
{
    public long Id { get; set; }

    public long ClassEventId { get; set; }

    public string Name { get; set; } = null!;

    public string CorrectAnswer { get; set; } = null!;

    public string? Description { get; set; }

    public string? Instruction { get; set; }

    public virtual ICollection<AnswerDAO> Answers { get; set; } = new List<AnswerDAO>();

    public virtual ClassEventDAO ClassEvent { get; set; } = null!;

    public virtual ICollection<StudentAnswerDAO> StudentAnswers { get; set; } = new List<StudentAnswerDAO>();
}
