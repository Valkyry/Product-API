using MediatR;

namespace SampleProject.Application.Products
{
    public partial class GetPagination
    {
        public class Request : IRequest<Response>
        {
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
        }
    }
}
