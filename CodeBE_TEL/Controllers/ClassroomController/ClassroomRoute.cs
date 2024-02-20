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
    }
}
