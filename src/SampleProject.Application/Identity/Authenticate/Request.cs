using MediatR;

namespace SampleProject.Application.Identity
{
    public partial class Authenticate
    {
        public class Request : IRequest<Response>
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
