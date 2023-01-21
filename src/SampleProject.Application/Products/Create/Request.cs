using MediatR;
using SampleProject.Application.DTO;
using SampleProject.Domain.Enums;

namespace SampleProject.Application.Products
{
    public partial class Create
    {
        public class Request : ProductDTO, IRequest<Response>
        {
            public Request(string title, ProductType type, double price, ProductColorType color)
            {
                this.Title = title;
                this.Price = price;
                this.Type = type;
                this.Color = color;
            }
        }
    }
}
