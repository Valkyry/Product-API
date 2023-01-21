using SampleProject.Domain.Enums;

namespace SampleProject.Application.DTO
{
    public class ProductResponse : Response<Guid>
    {
        public string Title { get; set; }
        public ProductType Type { get; set; }
        public double Price { get; set; }
        public ProductColorType Color { get; set; }
    }
}
