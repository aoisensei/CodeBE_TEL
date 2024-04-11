using CodeBE_TEL.Common;
using CodeBE_TEL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeBE_TEL.Controllers.ClassroomController
{
    public partial class ClassroomController
    {

        [Route(ClassroomRoute.CreateQuestion), HttpPost]
        public async Task<ActionResult<Classroom_QuestionDTO>?> CreateQuestion([FromBody] Classroom_QuestionDTO Classroom_QuestionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Question Question = ConvertQuestionDTOToEntity(Classroom_QuestionDTO);

            Question = await ClassEventService.CreateQuestion(Question);

            return new Classroom_QuestionDTO(Question);
        }

        [Route(ClassroomRoute.UpdateQuestion), HttpPost]
        public async Task<ActionResult<Classroom_QuestionDTO>?> UpdateQuestion([FromBody] Classroom_QuestionDTO Classroom_QuestionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Question Question = ConvertQuestionDTOToEntity(Classroom_QuestionDTO);

            Question = await ClassEventService.UpdateQuestion(Question);

            return new Classroom_QuestionDTO(Question);
        }

        [Route(ClassroomRoute.DeleteQuestion), HttpPost]
        public async Task<ActionResult<Classroom_QuestionDTO>?> DeleteQuestion([FromBody] Classroom_QuestionDTO Classroom_QuestionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Question Question = ConvertQuestionDTOToEntity(Classroom_QuestionDTO);

            Question = await ClassEventService.DeleteQuestion(Question);

            return new Classroom_QuestionDTO(Question);
        }

        private Question ConvertQuestionDTOToEntity(Classroom_QuestionDTO Classroom_QuestionDTO)
        {
            Question Question = new Question();
            Question.Id = Classroom_QuestionDTO.Id;
            Question.ClassEventId = Classroom_QuestionDTO.ClassEventId;
            Question.Description = Classroom_QuestionDTO.Description;

            return Question;
        }
    }
}
