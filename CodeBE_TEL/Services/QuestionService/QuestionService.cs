using CodeBE_TEL.Entities;
using CodeBE_TEL.Repositories;
using CodeBE_TEL.Services.QuestionService;

namespace CodeBE_TEL.Services.QuestionService
{
    public interface IQuestionService
    {
        Task<List<Question>> List();
        Task<Question> Get(long Id);
        Task<Question> Create(Question Question);
        Task<Question> Update(Question Question);
        Task<Question> Delete(Question Question);
    }
    public class QuestionService : IQuestionService
    {
        private IUOW UOW;
        private IQuestionValidator QuestionValidator;
        public QuestionService(
            IUOW UOW,
            IQuestionValidator QuestionValidator
        )
        {
            this.UOW = UOW;
            this.QuestionValidator = QuestionValidator;
        }
        public async Task<Question> Create(Question Question)
        {
            if (!await QuestionValidator.Create(Question))
                return Question;

            try
            {
                await UOW.QuestionRepository.Create(Question);
                Question = await UOW.QuestionRepository.Get(Question.Id);
                return Question;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<Question> Delete(Question Question)
        {
            if (!await QuestionValidator.Delete(Question))
                return Question;

            try
            {
                Question = await Get(Question.Id);
                await UOW.QuestionRepository.Delete(Question);
                return Question;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<Question> Get(long Id)
        {
            Question Question = await UOW.QuestionRepository.Get(Id);
            if (Question == null)
                return null;
            await QuestionValidator.Get(Question);
            return Question;
        }

        public async Task<List<Question>> List()
        {
            try
            {
                List<Question> Questions = await UOW.QuestionRepository.List();
                return Questions;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<Question> Update(Question Question)
        {
            if (!await QuestionValidator.Update(Question))
                return Question;
            try
            {
                var oldData = await UOW.QuestionRepository.Get(Question.Id);
                await UOW.QuestionRepository.Update(Question);
                Question = await UOW.QuestionRepository.Get(Question.Id);
                return Question;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

    }
}
