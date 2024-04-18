using CodeBE_TEL.Entities;

namespace CodeBE_TEL.Controllers.ClassroomController
{
    public class Classroom_CommentDTO
    {
        public long Id { get; set; }

        public long ClassEventId { get; set; }

        public long? AppUserId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
        public Classroom_AppUserDTO? AppUser { get; set; } = null!;
        public Classroom_CommentDTO() { }
        public Classroom_CommentDTO(Comment Comment)
        {
            Id = Comment.Id;
            ClassEventId = Comment.ClassEventId;
            Description = Comment.Description;
            CreatedAt = Comment.CreatedAt;
            UpdatedAt = Comment.UpdatedAt;
            AppUser = Comment.AppUser == null ? null : new Classroom_AppUserDTO(Comment.AppUser);
        }

    }
}
