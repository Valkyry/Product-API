using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Application.DTO;

namespace SampleProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : BaseApiController
    {
        public AuthenticateController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserDTO request, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new Application.Identity.Authenticate.Request { UserName = request.UserName, Password = request.Password }, cancellationToken));
        }

    }
}
