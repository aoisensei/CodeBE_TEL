using CodeBE_TEL.Entities;
using CodeBE_TEL.Repositories;

namespace CodeBE_TEL.Services.CommentService
{
    public interface ICommentValidator
    {
        Task Get(Comment Comment);
        Task<bool> Create(Comment Comment);
        Task<bool> Update(Comment Comment);
        Task<bool> Delete(Comment Comment);
    }
    public class CommentValidator : ICommentValidator
    {
        private IUOW UOW;

        public CommentValidator(IUOW UOW)
        {
            this.UOW = UOW;
        }
        public async Task<bool> Create(Comment Comment)
        {
            return true;
        }

        public async Task<bool> Delete(Comment Comment)
        {
            return true;
        }

        public async Task Get(Comment Comment)
        {

        }

        public async Task<bool> Update(Comment Comment)
        {
            return true;
        }
    }
}
