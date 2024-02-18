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
    }
}
