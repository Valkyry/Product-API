using MediatR;
using SampleProject.Application.Common.Interfaces;

namespace SampleProject.Application.Identity
{
    public partial class Register
    {
        public class RegisterHandler : IRequestHandler<Request, bool>
        {
            private readonly IIdentityService _identityService;

            public RegisterHandler(IIdentityService identityService)
            {
                _identityService = identityService;
            }

            public async Task<bool> Handle(Request request, CancellationToken cancellationToken)
            {
                var result = await _identityService.CreateUserAsync(request.UserName, request.Password);
                return result.isSucceed;
            }
        }
    }
}
