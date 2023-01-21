using FluentValidation;

namespace SampleProject.Application.Products
{
    public partial class GetPagination
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
            }
        }
    }
}
