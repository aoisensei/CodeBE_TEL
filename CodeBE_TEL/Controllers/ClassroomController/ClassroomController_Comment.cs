using CodeBE_TEL.Common;
using CodeBE_TEL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeBE_TEL.Controllers.ClassroomController
{
    public partial class ClassroomController
    {

        [Route(ClassroomRoute.CreateComment), HttpPost]
        public async Task<ActionResult<Classroom_CommentDTO>?> CreateComment([FromBody] Classroom_CommentDTO Classroom_CommentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Comment Comment = ConvertCommentDTOToEntity(Classroom_CommentDTO);

            Comment = await ClassEventService.CreateComment(Comment);

            return new Classroom_CommentDTO(Comment);
        }

        [Route(ClassroomRoute.UpdateComment), HttpPost]
        public async Task<ActionResult<Classroom_CommentDTO>?> UpdateComment([FromBody] Classroom_CommentDTO Classroom_CommentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Comment Comment = ConvertCommentDTOToEntity(Classroom_CommentDTO);

            Comment = await ClassEventService.UpdateComment(Comment);

            return new Classroom_CommentDTO(Comment);
        }

        [Route(ClassroomRoute.DeleteComment), HttpPost]
        public async Task<ActionResult<Classroom_CommentDTO>?> DeleteComment([FromBody] Classroom_CommentDTO Classroom_CommentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Comment Comment = ConvertCommentDTOToEntity(Classroom_CommentDTO);

            Comment = await ClassEventService.DeleteComment(Comment);

            return Ok();
        }

        private Comment ConvertCommentDTOToEntity(Classroom_CommentDTO Classroom_CommentDTO)
        {
            Comment Comment = new Comment();
            Comment.Id = Classroom_CommentDTO.Id;
            Comment.ClassEventId = Classroom_CommentDTO.ClassEventId;
            Comment.AppUserId = Classroom_CommentDTO.AppUserId;
            Comment.JobId = Classroom_CommentDTO.JobId;
            Comment.Description = Classroom_CommentDTO.Description;

            return Comment;
        }
    }
}
