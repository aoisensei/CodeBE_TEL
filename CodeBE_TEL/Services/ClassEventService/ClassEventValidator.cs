﻿using CodeBE_TEL.Entities;
using CodeBE_TEL.Repositories;

namespace CodeBE_TEL.Services.ClassEventService
{
    public interface IClassEventValidator
    {
        Task Get(ClassEvent ClassEvent);
        Task<bool> Create(ClassEvent ClassEvent);
        Task<bool> Update(ClassEvent ClassEvent);
        Task<bool> Delete(ClassEvent ClassEvent);
    }
    public class ClassEventValidator : IClassEventValidator
    {
        private IUOW UOW;

        public ClassEventValidator(IUOW UOW)
        {
            this.UOW = UOW;
        }
        public async Task<bool> Create(ClassEvent ClassEvent)
        {
            return true;
        }

        public async Task<bool> Delete(ClassEvent ClassEvent)
        {
            return true;
        }

        public async Task Get(ClassEvent ClassEvent)
        {

        }

        public async Task<bool> Update(ClassEvent ClassEvent)
        {
            return true;
        }
    }
}
