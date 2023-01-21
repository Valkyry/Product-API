using MediatR;

namespace SampleProject.Application.Identity
{
    public partial class Register
    {
        public class Request : IRequest<bool>
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
