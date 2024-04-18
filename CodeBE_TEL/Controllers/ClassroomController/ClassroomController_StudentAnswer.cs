using CodeBE_TEL.Common;
using CodeBE_TEL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeBE_TEL.Controllers.ClassroomController
{
    public partial class ClassroomController
    {

        [Route(ClassroomRoute.CreateStudentAnswer), HttpPost]
        public async Task<ActionResult<Classroom_StudentAnswerDTO>?> CreateStudentAnswer([FromBody] Classroom_StudentAnswerDTO Classroom_StudentAnswerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StudentAnswer StudentAnswer = ConvertStudentAnswerDTOToEntity(Classroom_StudentAnswerDTO);

            StudentAnswer = await ClassEventService.CreateStudentAnswer(StudentAnswer);

            return new Classroom_StudentAnswerDTO(StudentAnswer);
        }

        [Route(ClassroomRoute.UpdateStudentAnswer), HttpPost]
        public async Task<ActionResult<Classroom_StudentAnswerDTO>?> UpdateStudentAnswer([FromBody] Classroom_StudentAnswerDTO Classroom_StudentAnswerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StudentAnswer StudentAnswer = ConvertStudentAnswerDTOToEntity(Classroom_StudentAnswerDTO);

            StudentAnswer = await ClassEventService.UpdateStudentAnswer(StudentAnswer);

            return new Classroom_StudentAnswerDTO(StudentAnswer);
        }

        private StudentAnswer ConvertStudentAnswerDTOToEntity(Classroom_StudentAnswerDTO Classroom_StudentAnswerDTO)
        {
            StudentAnswer StudentAnswer = new StudentAnswer();
            StudentAnswer.Id = Classroom_StudentAnswerDTO.Id;
            StudentAnswer.QuestionId = Classroom_StudentAnswerDTO.QuestionId;
            StudentAnswer.AppUserId = Classroom_StudentAnswerDTO.AppUserId;
            StudentAnswer.Name = Classroom_StudentAnswerDTO.Name;
            StudentAnswer.AppUserFeedbackId = Classroom_StudentAnswerDTO.AppUserFeedbackId;
            StudentAnswer.Grade = Classroom_StudentAnswerDTO.Grade;
            StudentAnswer.Feedback = Classroom_StudentAnswerDTO.Feedback;

            return StudentAnswer;
        }
    }
}
