using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skunkworks.Application.Features.StudentRequests.Command;

namespace SomeService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRequestController : ControllerBase
    {
        private readonly ISender sender;
        private CancellationToken cancellationToken;

        [HttpPost]
        public async Task<ActionResult> Create(CreateStudentCourse comand)
        {
            var result = await sender.Send(new CreateStudentCourseRequestCommand(comand), cancellationToken);
            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(UpdateStudentCourse command)
        {
            var result = await sender.Send(new UpdateStudentCourseRequestCommand(command), cancellationToken);
            return Ok(result);
        }
    }
}
