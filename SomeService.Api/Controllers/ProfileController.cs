using MassTransit.Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skunkworks.Application.Features.Profiles.Command;
using Skunkworks.Shared;
using System.Threading;
using MediatR;

namespace SomeService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ISender sender;
        private CancellationToken cancellationToken;

        [HttpPost]
        public async Task<ActionResult> Create(CreateProfileRequest comand)
        {
           var result = await sender.Send(new CreateProfileCommand(comand),  cancellationToken);
            return Ok(result);
                 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(UpdateProfileRequest command)
        {
            var result = await sender.Send(new UpdateProfileCommand(command), cancellationToken);
            return Ok(result);
        }
    }
}
