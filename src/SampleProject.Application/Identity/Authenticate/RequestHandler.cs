using MediatR;
using SampleProject.Application.Common.Exceptions;
using SampleProject.Application.Common.Interfaces;

namespace SampleProject.Application.Identity
{
    public partial class Authenticate
    {
        public class AuthenticateHandler : IRequestHandler<Request, Response>
        {
            private readonly ITokenGenerator _tokenGenerator;
            private readonly IIdentityService _identityService;

            public AuthenticateHandler(IIdentityService identityService, ITokenGenerator tokenGenerator)
            {
                _identityService = identityService;
                _tokenGenerator = tokenGenerator;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var result = await _identityService.SigninUserAsync(request.UserName, request.Password);

                if (!result)
                {
                    throw new BadRequestException("Invalid username or password");
                }

                var userId = await _identityService.GetUserIdAsync(request.UserName);

                string token = _tokenGenerator.GenerateToken(userId, request.UserName);

                return new Response()
                {
                    UserId = userId,
                    Name = request.UserName,
                    Token = token
                };
            }
        }
    }
}
