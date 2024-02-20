using CodeBE_TEL.Entities;

namespace CodeBE_TEL.Controllers.ClassroomController
{
    public class Classroom_ClassroomDTO
    {
        public long Id { get; set; }

        public long AppUserId { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public List<Classroom_ClassEventDTO>? ClassEvents { get; set; }

        public Classroom_ClassroomDTO() { }
        public Classroom_ClassroomDTO(Classroom Classroom)
        {
            Id = Classroom.Id;
            AppUserId = Classroom.AppUserId;
            Code = Classroom.Code;
            Name = Classroom.Name;
            Description = Classroom.Description;
            CreatedAt = Classroom.CreatedAt;
            UpdatedAt = Classroom.UpdatedAt;
            DeletedAt = Classroom.DeletedAt;
            ClassEvents = Classroom.ClassEvents.Select(x => new Classroom_ClassEventDTO(x)).ToList();
        }
    }
}
