using MediatR;

namespace SampleProject.Application.Products
{
    public partial class Delete
    {
        public class Request : IRequest<bool>
        {
            public Request(Guid id)
            {
                Id = id;
            }
            public Guid Id { get; set; }
        }
    }
}
