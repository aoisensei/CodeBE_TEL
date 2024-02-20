using CodeBE_TEL.Entities;

namespace CodeBE_TEL.Controllers.ClassroomController
{
    public class Classroom_CommentDTO
    {
        public long Id { get; set; }

        public long ClassEventId { get; set; }

        public string Description { get; set; } = null!;

        public Classroom_CommentDTO() { }
        public Classroom_CommentDTO(Comment Comment)
        {
            Id = Comment.Id;
            ClassEventId = Comment.ClassEventId;
            Description = Comment.Description;
        }

    }
}
