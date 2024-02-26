﻿using CodeBE_TEL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeBE_TEL.Controllers.ClassroomController
{
    public partial class ClassroomController
    {
        [Route(ClassroomRoute.ListClassEvent), HttpPost]
        public async Task<ActionResult<List<Classroom_ClassEventDTO>>> ListClassEvent()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<ClassEvent> ClassEvents = await ClassroomService.ListClassEvent();
            List<Classroom_ClassEventDTO> Classroom_ClassEventDTOs = ClassEvents
                .Select(c => new Classroom_ClassEventDTO(c)).ToList();

            return Classroom_ClassEventDTOs;
        }

        [Route(ClassroomRoute.GetClassEvent), HttpPost]
        public async Task<ActionResult<Classroom_ClassEventDTO>?> GetClassEvent([FromBody] Classroom_ClassEventDTO Classroom_ClassEventDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ClassEvent ClassEvent = await ClassroomService.GetClassEvent(Classroom_ClassEventDTO.Id);

            return new Classroom_ClassEventDTO(ClassEvent);
        }

        [Route(ClassroomRoute.CreateClassEvent), HttpPost]
        public async Task<ActionResult<Classroom_ClassEventDTO>?> CreateClassEvent([FromBody] Classroom_ClassEventDTO Classroom_ClassEventDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ClassEvent ClassEvent = ConvertClassEventDTOToEntity(Classroom_ClassEventDTO);

            ClassEvent = await ClassroomService.CreateClassEvent(ClassEvent);

            return new Classroom_ClassEventDTO(ClassEvent);
        }

        [Route(ClassroomRoute.UpdateClassEvent), HttpPost]
        public async Task<ActionResult<Classroom_ClassEventDTO>?> UpdateClassEvent([FromBody] Classroom_ClassEventDTO Classroom_ClassEventDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ClassEvent ClassEvent = ConvertClassEventDTOToEntity(Classroom_ClassEventDTO);

            ClassEvent = await ClassroomService.UpdateClassEvent(ClassEvent);

            return new Classroom_ClassEventDTO(ClassEvent);
        }

        [Route(ClassroomRoute.DeleteClassEvent), HttpPost]
        public async Task<ActionResult<Classroom_ClassEventDTO>?> DeleteClassEvent([FromBody] Classroom_ClassEventDTO Classroom_ClassEventDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ClassEvent ClassEvent = ConvertClassEventDTOToEntity(Classroom_ClassEventDTO);

            ClassEvent = await ClassroomService.DeleteClassEvent(ClassEvent);

            return new Classroom_ClassEventDTO(ClassEvent);
        }

        private ClassEvent ConvertClassEventDTOToEntity(Classroom_ClassEventDTO Classroom_ClassEventDTO)
        {
            ClassEvent ClassEvent = new ClassEvent();
            ClassEvent.Id = Classroom_ClassEventDTO.Id;
            ClassEvent.ClassroomId = Classroom_ClassEventDTO.ClassroomId;
            ClassEvent.Code = Classroom_ClassEventDTO.Code;
            ClassEvent.Name = Classroom_ClassEventDTO.Name;
            ClassEvent.IsNotification = Classroom_ClassEventDTO.IsNotification;
            ClassEvent.Description = Classroom_ClassEventDTO.Description;
            ClassEvent.Order = Classroom_ClassEventDTO.Order;
            ClassEvent.CreatedAt = Classroom_ClassEventDTO.CreatedAt;
            ClassEvent.EndAt = Classroom_ClassEventDTO.EndAt;
            ClassEvent.DeletedAt = Classroom_ClassEventDTO.DeletedAt;
            ClassEvent.UpdatedAt = Classroom_ClassEventDTO.UpdatedAt;

            ClassEvent.Comments = Classroom_ClassEventDTO.Comments?
                .Select(x => new Comment
                {
                    Id = x.Id,
                    ClassEventId = x.ClassEventId,
                    Description = x.Description,
                }).ToList();

            ClassEvent.Questions = Classroom_ClassEventDTO.Questions?
                .Select(x => new Question
                {
                    Id = x.Id,
                    ClassEventId = x.ClassEventId,
                    Description = x.Description,
                    Name = x.Name,
                    QuestionAnswer = x.QuestionAnswer,
                    StudentAnswer = x.StudentAnswer,
                }).ToList();

            return ClassEvent;
        }
    }
}