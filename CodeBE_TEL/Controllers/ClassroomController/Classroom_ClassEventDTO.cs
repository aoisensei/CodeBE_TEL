﻿using CodeBE_TEL.Entities;

namespace CodeBE_TEL.Controllers.ClassroomController;

public class Classroom_ClassEventDTO
{
    public long Id { get; set; }

    public long ClassroomId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool IsNotification { get; set; }

    public string? Description { get; set; }

    public bool Order { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime EndAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public List<Classroom_CommentDTO>? Comments { get; set; }
    public List<Classroom_QuestionDTO>? Questions { get; set; }

    public Classroom_ClassEventDTO() { }
    public Classroom_ClassEventDTO(ClassEvent ClassEvent)
    {
        Id = ClassEvent.Id;
        ClassroomId = ClassEvent.ClassroomId;
        Code = ClassEvent.Code;
        Name = ClassEvent.Name;
        Description = ClassEvent.Description;
        Order = ClassEvent.Order;
        CreatedAt = ClassEvent.CreatedAt;
        EndAt = ClassEvent.EndAt;
        UpdatedAt = ClassEvent.UpdatedAt;
        DeletedAt = ClassEvent.DeletedAt;
        Comments = ClassEvent.Comments?.Select(x => new Classroom_CommentDTO(x)).ToList();
        Questions = ClassEvent.Questions?.Select(x => new Classroom_QuestionDTO(x)).ToList();
    }
}