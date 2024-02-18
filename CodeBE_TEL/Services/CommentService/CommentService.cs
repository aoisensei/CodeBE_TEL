using CodeBE_TEL.Entities;
using CodeBE_TEL.Repositories;
using CodeBE_TEL.Services.CommentService;

namespace CodeBE_TEL.Services.CommentService
{
    public interface ICommentService
    {
        Task<List<Comment>> List();
        Task<Comment> Get(long Id);
        Task<Comment> Create(Comment Comment);
        Task<Comment> Update(Comment Comment);
        Task<Comment> Delete(Comment Comment);
    }
    public class CommentService : ICommentService
    {
        private IUOW UOW;
        private ICommentValidator CommentValidator;
        public CommentService(
            IUOW UOW,
            ICommentValidator CommentValidator
        )
        {
            this.UOW = UOW;
            this.CommentValidator = CommentValidator;
        }
        public async Task<Comment> Create(Comment Comment)
        {
            if (!await CommentValidator.Create(Comment))
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

        public async Task<Comment> Delete(Comment Comment)
        {
            if (!await CommentValidator.Delete(Comment))
                return Comment;

            try
            {
                Comment = await Get(Comment.Id);
                await UOW.CommentRepository.Delete(Comment);
                return Comment;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<Comment> Get(long Id)
        {
            Comment Comment = await UOW.CommentRepository.Get(Id);
            if (Comment == null)
                return null;
            await CommentValidator.Get(Comment);
            return Comment;
        }

        public async Task<List<Comment>> List()
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

        public async Task<Comment> Update(Comment Comment)
        {
            if (!await CommentValidator.Update(Comment))
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
