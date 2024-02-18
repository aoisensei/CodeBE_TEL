using CodeBE_TEL.Entities;
using CodeBE_TEL.Repositories;
using CodeBE_TEL.Services.ClassEventService;

namespace CodeBE_TEL.Services.ClassEventService
{
    public interface IClassEventService
    {
        Task<List<ClassEvent>> List();
        Task<ClassEvent> Get(long Id);
        Task<ClassEvent> Create(ClassEvent ClassEvent);
        Task<ClassEvent> Update(ClassEvent ClassEvent);
        Task<ClassEvent> Delete(ClassEvent ClassEvent);
    }
    public class ClassEventService : IClassEventService
    {
        private IUOW UOW;
        private IClassEventValidator ClassEventValidator;
        public ClassEventService(
            IUOW UOW,
            IClassEventValidator ClassEventValidator
        )
        {
            this.UOW = UOW;
            this.ClassEventValidator = ClassEventValidator;
        }
        public async Task<ClassEvent> Create(ClassEvent ClassEvent)
        {
            if (!await ClassEventValidator.Create(ClassEvent))
                return ClassEvent;

            try
            {
                ClassEvent.Code = string.Empty;
                await UOW.ClassEventRepository.Create(ClassEvent);
                await BuildCode(ClassEvent);
                ClassEvent = await UOW.ClassEventRepository.Get(ClassEvent.Id);
                return ClassEvent;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<ClassEvent> Delete(ClassEvent ClassEvent)
        {
            if (!await ClassEventValidator.Delete(ClassEvent))
                return ClassEvent;

            try
            {
                ClassEvent = await Get(ClassEvent.Id);
                await UOW.ClassEventRepository.Delete(ClassEvent);
                return ClassEvent;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<ClassEvent> Get(long Id)
        {
            ClassEvent ClassEvent = await UOW.ClassEventRepository.Get(Id);
            if (ClassEvent == null)
                return null;
            await ClassEventValidator.Get(ClassEvent);
            return ClassEvent;
        }

        public async Task<List<ClassEvent>> List()
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

        public async Task<ClassEvent> Update(ClassEvent ClassEvent)
        {
            if (!await ClassEventValidator.Update(ClassEvent))
                return ClassEvent;
            try
            {
                var oldData = await UOW.ClassEventRepository.Get(ClassEvent.Id);
                await UOW.ClassEventRepository.Update(ClassEvent);
                await BuildCode(ClassEvent);
                ClassEvent = await UOW.ClassEventRepository.Get(ClassEvent.Id);
                return ClassEvent;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        private async Task BuildCode(ClassEvent ClassEvent)
        {
            ClassEvent.Code = "CE" + ClassEvent.Id;
            await UOW.ClassEventRepository.UpdateCode(ClassEvent);
        }
    }
}
