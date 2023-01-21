using FluentValidation;

namespace SampleProject.Application.Identity
{
    public partial class Authenticate
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
            }
        }
    }
}
