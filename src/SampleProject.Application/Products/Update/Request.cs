using MediatR;
using SampleProject.Application.DTO;
using SampleProject.Domain.Enums;

namespace SampleProject.Application.Products
{
    public partial class Update
    {
        public class Request : ProductDTO, IRequest<Response>
        {
            public Request(Guid id, string title, ProductType type, double price, ProductColorType color)
            {
                Id = id;
                this.Title = title;
                this.Price = price;
                this.Type = type;
                this.Color = color;
            }

            public Guid Id { get; set; }
        }
    }
}
