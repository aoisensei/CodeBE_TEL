using CodeBE_TEL.Entities;
using CodeBE_TEL.Repositories;

namespace CodeBE_TEL.Services.ClassroomService
{
    public partial interface IClassroomService
    {
        Task<List<ClassEvent>> ListClassEvent();
        Task<ClassEvent> GetClassEvent(long Id);
        Task<ClassEvent> CreateClassEvent(ClassEvent ClassEvent);
        Task<ClassEvent> UpdateClassEvent(ClassEvent ClassEvent);
        Task<ClassEvent> DeleteClassEvent(ClassEvent ClassEvent);
    }
    public partial class ClassroomService : IClassroomService
    {
        public async Task<ClassEvent> CreateClassEvent(ClassEvent ClassEvent)
        {
            if (!await ClassroomValidator.CreateClassEvent(ClassEvent))
                return ClassEvent;

            try
            {
                ClassEvent.Code = string.Empty;
                await UOW.ClassEventRepository.Create(ClassEvent);
                await BuildCodeClassEvent(ClassEvent);
                ClassEvent = await UOW.ClassEventRepository.Get(ClassEvent.Id);
                return ClassEvent;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<ClassEvent> DeleteClassEvent(ClassEvent ClassEvent)
        {
            if (!await ClassroomValidator.DeleteClassEvent(ClassEvent))
                return ClassEvent;

            try
            {
                ClassEvent = await GetClassEvent(ClassEvent.Id);
                await UOW.ClassEventRepository.Delete(ClassEvent);
                return ClassEvent;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<ClassEvent> GetClassEvent(long Id)
        {
            ClassEvent ClassEvent = await UOW.ClassEventRepository.Get(Id);
            if (ClassEvent == null)
                return null;
            await ClassroomValidator.GetClassEvent(ClassEvent);
            return ClassEvent;
        }

        public async Task<List<ClassEvent>> ListClassEvent()
        {
            try
            {
                List<ClassEvent> ClassEvents = await UOW.ClassEventRepository.List();
                return ClassEvents;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<ClassEvent> UpdateClassEvent(ClassEvent ClassEvent)
        {
            if (!await ClassroomValidator.UpdateClassEvent(ClassEvent))
                return ClassEvent;
            try
            {
                var oldData = await UOW.ClassEventRepository.Get(ClassEvent.Id);
                await UOW.ClassEventRepository.Update(ClassEvent);
                await BuildCodeClassEvent(ClassEvent);
                ClassEvent = await UOW.ClassEventRepository.Get(ClassEvent.Id);
                return ClassEvent;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        private async Task BuildCodeClassEvent(ClassEvent ClassEvent)
        {
            ClassEvent.Code = "CE" + ClassEvent.Id;
            await UOW.ClassEventRepository.UpdateCode(ClassEvent);
        }
    }
}
