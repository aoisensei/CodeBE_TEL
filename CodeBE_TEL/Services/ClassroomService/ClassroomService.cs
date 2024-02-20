using CodeBE_TEL.Entities;
using CodeBE_TEL.Repositories;

namespace CodeBE_TEL.Services.ClassroomService
{
    public partial interface IClassroomService
    {
        Task<List<Classroom>> List();
        Task<Classroom> Get(long Id);
        Task<Classroom> Create(Classroom Classroom);
        Task<Classroom> Update(Classroom Classroom);
        Task<Classroom> Delete(Classroom Classroom);
    }
    public partial class ClassroomService : IClassroomService
    {
        private IUOW UOW;
        private IClassroomValidator ClassroomValidator;
        public ClassroomService(
            IUOW UOW,
            IClassroomValidator ClassroomValidator
        )
        {
            this.UOW = UOW;
            this.ClassroomValidator = ClassroomValidator;
        }
        public async Task<Classroom> Create(Classroom Classroom)
        {
            if (!await ClassroomValidator.Create(Classroom))
                return Classroom;

            try
            {
                Classroom.Code = string.Empty;
                await UOW.ClassroomRepository.Create(Classroom);
                await BuildCode(Classroom);
                Classroom = await UOW.ClassroomRepository.Get(Classroom.Id);
                return Classroom;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<Classroom> Delete(Classroom Classroom)
        {
            if (!await ClassroomValidator.Delete(Classroom))
                return Classroom;

            try
            {
                Classroom = await Get(Classroom.Id);
                await UOW.ClassroomRepository.Delete(Classroom);
                return Classroom;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<Classroom> Get(long Id)
        {
            Classroom Classroom = await UOW.ClassroomRepository.Get(Id);
            if (Classroom == null)
                return null;
            await ClassroomValidator.Get(Classroom);
            return Classroom;
        }

        public async Task<List<Classroom>> List()
        {
            try
            {
                List<Classroom> Classrooms = await UOW.ClassroomRepository.List();
                return Classrooms;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<Classroom> Update(Classroom Classroom)
        {
            if (!await ClassroomValidator.Update(Classroom))
                return Classroom;
            try
            {
                var oldData = await UOW.ClassroomRepository.Get(Classroom.Id);
                await UOW.ClassroomRepository.Update(Classroom);
                await BuildCode(Classroom);
                Classroom = await UOW.ClassroomRepository.Get(Classroom.Id);
                return Classroom;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        private async Task BuildCode(Classroom Classroom)
        {
            Classroom.Code = "C" + Classroom.Id;
            await UOW.ClassroomRepository.UpdateCode(Classroom);
        }
    }
}
