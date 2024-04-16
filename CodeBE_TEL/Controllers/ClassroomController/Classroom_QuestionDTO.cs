﻿using CodeBE_TEL.Entities;
using System.Xml.Linq;

namespace CodeBE_TEL.Controllers.ClassroomController
{
    public class Classroom_QuestionDTO
    {
        public long Id { get; set; }

        public long ClassEventId { get; set; }

        public string Name { get; set; } = null!;

        public string CorrectAnswer { get; set; } = null!;

        public string? StudentAnswer { get; set; }

        public string? Description { get; set; }
        public string? Instruction { get; set; }

        public List<Classroom_AnswerDTO>? Answers { get; set; }

        public Classroom_QuestionDTO() { }
        public Classroom_QuestionDTO(Question Question)
        {
            Id = Question.Id;
            ClassEventId = Question.ClassEventId;
            Name = Question.Name;
            CorrectAnswer = Question.CorrectAnswer;
            StudentAnswer = Question.StudentAnswer;
            Description = Question.Description;
            Instruction = Question.Instruction;
            Answers = Question.Answers?.Select(x => new Classroom_AnswerDTO(x)).ToList();
        }
    }
}
