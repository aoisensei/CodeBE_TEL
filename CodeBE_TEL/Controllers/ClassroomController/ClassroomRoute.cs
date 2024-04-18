using System.ComponentModel;

namespace CodeBE_TEL.Controllers.ClassroomController
{
    [DisplayName("Classroom")]
    public class ClassroomRoute
    {
        public const string Module = "/tel/classroom";
        public const string Create = Module + "/create";
        public const string Get = Module + "/get";
        public const string List = Module + "/list";
        public const string Update = Module + "/update";
        public const string Delete = Module + "/delete";

        public const string CreateClassEvent = Module + "/create-class-event";
        public const string GetClassEvent = Module + "/get-class-event";
        public const string ListClassEvent = Module + "/list-class-event";
        public const string UpdateClassEvent = Module + "/update-class-event";
        public const string DeleteClassEvent = Module + "/delete-class-event";

        public const string CreateComment = Module + "/create-comment";
        public const string UpdateComment = Module + "/update-comment";
        public const string DeleteComment = Module + "/delete-comment";

        public const string CreateQuestion = Module + "/create-question";
        public const string UpdateQuestion = Module + "/update-question";
        public const string DeleteQuestion = Module + "/delete-question";

        public const string CreateStudentAnswer = Module + "/create-student-answer";
        public const string UpdateStudentAnswer = Module + "/update-student-answer";

    }
}
