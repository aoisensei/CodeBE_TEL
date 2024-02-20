using CodeBE_TEL.Entities;
using CodeBE_TEL.Repositories;

namespace CodeBE_TEL.Services.ClassroomService
{
    public partial interface IClassroomService
    {
        Task<List<Comment>> ListComment();
        Task<Comment> GetComment(long Id);
        Task<Comment> CreateComment(Comment Comment);
        Task<Comment> UpdateComment(Comment Comment);
        Task<Comment> DeleteComment(Comment Comment);
    }
    public partial class ClassroomService : IClassroomService
    {
        public async Task<Comment> CreateComment(Comment Comment)
        {
            if (!await ClassroomValidator.CreateComment(Comment))
                return Comment;

            try
            {
                await UOW.CommentRepository.Create(Comment);
                Comment = await UOW.CommentRepository.Get(Comment.Id);
                return Comment;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<Comment> DeleteComment(Comment Comment)
        {
            if (!await ClassroomValidator.DeleteComment(Comment))
                return Comment;

            try
            {
                Comment = await GetComment(Comment.Id);
                await UOW.CommentRepository.Delete(Comment);
                return Comment;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<Comment> GetComment(long Id)
        {
            Comment Comment = await UOW.CommentRepository.Get(Id);
            if (Comment == null)
                return null;
            await ClassroomValidator.GetComment(Comment);
            return Comment;
        }

        public async Task<List<Comment>> ListComment()
        {
            try
            {
                List<Comment> Comments = await UOW.CommentRepository.List();
                return Comments;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<Comment> UpdateComment(Comment Comment)
        {
            if (!await ClassroomValidator.UpdateComment(Comment))
                return Comment;
            try
            {
                var oldData = await UOW.CommentRepository.Get(Comment.Id);
                await UOW.CommentRepository.Update(Comment);
                Comment = await UOW.CommentRepository.Get(Comment.Id);
                return Comment;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

    }
}
