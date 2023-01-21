using MediatR;

namespace SampleProject.Application.Products
{
    public partial class SearchPagination
    {
        public class Request : IRequest<Response>
        {
            public int Type { get; set; }
            public int Color { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
        }
    }
}
