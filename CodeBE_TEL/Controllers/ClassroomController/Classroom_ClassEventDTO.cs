﻿using CodeBE_TEL.Entities;

namespace CodeBE_TEL.Controllers.ClassroomController;

public class Classroom_ClassEventDTO
{
    public long Id { get; set; }

    public long ClassroomId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool IsClassWork { get; set; }

    public bool Pinned { get; set; }
    public long? AppUserId { get; set; }
    public bool IsSubmit { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? StartAt { get; set; }
    public DateTime? EndAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public List<Classroom_CommentDTO>? Comments { get; set; }
    public Classroom_AppUserDTO? AppUser { get; set; } = null!;
    public List<Classroom_QuestionDTO>? Questions { get; set; }

    public Classroom_ClassEventDTO() { }
    public Classroom_ClassEventDTO(ClassEvent ClassEvent)
    {
        Id = ClassEvent.Id == 0 ? 0 : ClassEvent.Id;
        ClassroomId = ClassEvent.ClassroomId;
        Code = ClassEvent.Code;
        Name = ClassEvent.Name;
        Description = ClassEvent.Description;
        Pinned = ClassEvent.Pinned;
        IsSubmit = ClassEvent.IsSubmit;
        IsClassWork = ClassEvent.IsClassWork;
        CreatedAt = ClassEvent.CreatedAt;
        EndAt = ClassEvent.EndAt;
        StartAt = ClassEvent.StartAt;
        UpdatedAt = ClassEvent.UpdatedAt;
        DeletedAt = ClassEvent.DeletedAt;
        Comments = ClassEvent.Comments?.Select(x => new Classroom_CommentDTO(x)).ToList();
        Questions = ClassEvent.Questions?.Select(x => new Classroom_QuestionDTO(x)).ToList();
        AppUser = ClassEvent.AppUser == null ? null : new Classroom_AppUserDTO(ClassEvent.AppUser);
    }
}