using System;
using System.Collections.Generic;

namespace CodeBE_TEL.Models;

public partial class AnswerDAO
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public long QuestionId { get; set; }

    public virtual QuestionDAO Question { get; set; } = null!;
}
