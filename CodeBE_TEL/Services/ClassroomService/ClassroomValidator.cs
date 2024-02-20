using CodeBE_TEL.Entities;
using CodeBE_TEL.Repositories;

namespace CodeBE_TEL.Services.ClassroomService
{
    public interface IClassroomValidator
    {
        Task Get(Classroom Classroom);
        Task<bool> Create(Classroom Classroom);
        Task<bool> Update(Classroom Classroom);
        Task<bool> Delete(Classroom Classroom);
        Task GetClassEvent(ClassEvent ClassEvent);
        Task<bool> CreateClassEvent(ClassEvent ClassEvent);
        Task<bool> UpdateClassEvent(ClassEvent ClassEvent);
        Task<bool> DeleteClassEvent(ClassEvent ClassEvent);
        Task GetComment(Comment Comment);
        Task<bool> CreateComment(Comment Comment);
        Task<bool> UpdateComment(Comment Comment);
        Task<bool> DeleteComment(Comment Comment);
        Task GetQuestion(Question Question);
        Task<bool> CreateQuestion(Question Question);
        Task<bool> UpdateQuestion(Question Question);
        Task<bool> DeleteQuestion(Question Question);
    }
    public class ClassroomValidator : IClassroomValidator
    {
        private IUOW UOW;

        public ClassroomValidator(IUOW UOW)
        {
            this.UOW = UOW;
        }
        public async Task<bool> Create(Classroom Classroom)
        {
            return true;
        }

        public async Task<bool> Delete(Classroom Classroom)
        {
            return true;
        }

        public async Task Get(Classroom Classroom)
        {
            
        }

        public async Task<bool> Update(Classroom Classroom)
        {
            return true;
        }

        public async Task<bool> CreateClassEvent(ClassEvent ClassEvent)
        {
            return true;
        }

        public async Task<bool> DeleteClassEvent(ClassEvent ClassEvent)
        {
            return true;
        }

        public async Task GetClassEvent(ClassEvent ClassEvent)
        {

        }

        public async Task<bool> UpdateClassEvent(ClassEvent ClassEvent)
        {
            return true;
        }

        public async Task<bool> CreateComment(Comment Comment)
        {
            return true;
        }

        public async Task<bool> DeleteComment(Comment Comment)
        {
            return true;
        }

        public async Task GetComment(Comment Comment)
        {

        }

        public async Task<bool> UpdateComment(Comment Comment)
        {
            return true;
        }

        public async Task<bool> CreateQuestion(Question Question)
        {
            return true;
        }

        public async Task<bool> DeleteQuestion(Question Question)
        {
            return true;
        }

        public async Task GetQuestion(Question Question)
        {

        }

        public async Task<bool> UpdateQuestion(Question Question)
        {
            return true;
        }
    }
}
