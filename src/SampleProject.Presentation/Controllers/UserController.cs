using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Application.DTO;

namespace SampleProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(UserDTO request, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new Application.Identity.Register.Request { UserName = request.UserName, Password = request.Password }, cancellationToken));
        }

    }
}
