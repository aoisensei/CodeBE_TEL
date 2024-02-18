using CodeBE_TEL.Entities;
using CodeBE_TEL.Repositories;

namespace CodeBE_TEL.Services.QuestionService
{
    public interface IQuestionValidator
    {
        Task Get(Question Question);
        Task<bool> Create(Question Question);
        Task<bool> Update(Question Question);
        Task<bool> Delete(Question Question);
    }
    public class QuestionValidator : IQuestionValidator
    {
        private IUOW UOW;

        public QuestionValidator(IUOW UOW)
        {
            this.UOW = UOW;
        }
        public async Task<bool> Create(Question Question)
        {
            return true;
        }

        public async Task<bool> Delete(Question Question)
        {
            return true;
        }

        public async Task Get(Question Question)
        {

        }

        public async Task<bool> Update(Question Question)
        {
            return true;
        }
    }
}
