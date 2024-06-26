﻿
using CodeBE_TEL.Common;
using CodeBE_TEL.Entities;
using CodeBE_TEL.Services.ClassroomService;
using Microsoft.AspNetCore.Mvc;

namespace CodeBE_TEL.Controllers.ClassroomController
{
    [ApiController]
    public partial class ClassroomController : ControllerBase
    {
        private IClassroomService ClassroomService;
        private IClassEventService ClassEventService;

        public ClassroomController(
            IClassroomService ClassroomService,
            IClassEventService ClassEventService
        )
        {
            this.ClassroomService = ClassroomService;
            this.ClassEventService = ClassEventService;
        }

        [Route(ClassroomRoute.List), HttpPost]
        public async Task<ActionResult<List<Classroom_ClassroomDTO>>> List(FilterDTO FilterDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Classroom> Classrooms = await ClassroomService.List(FilterDTO);
            List<Classroom_ClassroomDTO> Classroom_ClassroomDTOs = Classrooms
                .Select(c => new Classroom_ClassroomDTO(c)).ToList();

            return Classroom_ClassroomDTOs;
        }

        [Route(ClassroomRoute.Get), HttpPost]
        public async Task<ActionResult<Classroom_ClassroomDTO>?> Get([FromBody] Classroom_ClassroomDTO Classroom_ClassroomDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Classroom Classroom = await ClassroomService.Get(Classroom_ClassroomDTO.Id);

            return new Classroom_ClassroomDTO(Classroom);
        }

        [Route(ClassroomRoute.Create), HttpPost]
        public async Task<ActionResult<Classroom_ClassroomDTO>?> Create([FromBody] Classroom_ClassroomDTO Classroom_ClassroomDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Classroom Classroom = ConvertDTOToEntity(Classroom_ClassroomDTO);

            Classroom = await ClassroomService.Create(Classroom);

            return new Classroom_ClassroomDTO(Classroom);
        }

        [Route(ClassroomRoute.Update), HttpPost]
        public async Task<ActionResult<Classroom_ClassroomDTO>?> Update([FromBody] Classroom_ClassroomDTO Classroom_ClassroomDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Classroom Classroom = ConvertDTOToEntity(Classroom_ClassroomDTO);

            Classroom = await ClassroomService.Update(Classroom);

            return new Classroom_ClassroomDTO(Classroom);
        }

        [Route(ClassroomRoute.Delete), HttpPost]
        public async Task<ActionResult<Classroom_ClassroomDTO>?> Delete([FromBody] Classroom_ClassroomDTO Classroom_ClassroomDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Classroom Classroom = ConvertDTOToEntity(Classroom_ClassroomDTO);

            Classroom = await ClassroomService.Delete(Classroom);

            return new Classroom_ClassroomDTO(Classroom);
        }

        private Classroom ConvertDTOToEntity(Classroom_ClassroomDTO Classroom_ClassroomDTO)
        {
            Classroom Classroom = new Classroom();
            Classroom.Id = Classroom_ClassroomDTO.Id;
            Classroom.Code = Classroom_ClassroomDTO.Code;
            Classroom.Description = Classroom_ClassroomDTO.Description;
            Classroom.CreatedAt = Classroom_ClassroomDTO.CreatedAt;
            Classroom.Name = Classroom_ClassroomDTO.Name;
            Classroom.UpdatedAt = Classroom_ClassroomDTO.UpdatedAt;
            Classroom.DeletedAt = Classroom_ClassroomDTO.DeletedAt;
            Classroom.ClassEvents = Classroom_ClassroomDTO.ClassEvents?
                .Select(x => new ClassEvent
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsClassWork = x.IsClassWork,
                    Description = x.Description,
                    Pinned = x.Pinned,
                    CreatedAt = x.CreatedAt,
                    EndAt = x.EndAt,
                    UpdatedAt = x.UpdatedAt,
                    DeletedAt = x.DeletedAt,
                    Comments = x.Comments?.Select(y => new Comment
                    {
                        Id= y.Id,
                        Description = y.Description,
                        ClassEventId = y.ClassEventId,
                    }).ToList(),
                    Questions = x.Questions?.Select(y => new Question
                    {
                        Id = y.Id,
                        Description = y.Description,
                        ClassEventId = y.ClassEventId,
                        Name = y.Name,
                        CorrectAnswer = y.CorrectAnswer,
                    }).ToList(),
                }).ToList();

            return Classroom;
        }
    }
}
