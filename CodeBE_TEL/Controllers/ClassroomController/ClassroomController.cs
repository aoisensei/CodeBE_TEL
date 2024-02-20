
using CodeBE_TEL.Services.ClassroomService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeBE_TEL.Controllers.ClassroomController
{
    [ApiController]
    public partial class ClassroomController : ControllerBase
    {
        private IClassroomService ClassroomService;

        public ClassroomController(
            IClassroomService ClassroomService
        )
        {
            this.ClassroomService = ClassroomService;
        }

        [Route(ClassroomRoute.List), HttpPost]

    }
}
