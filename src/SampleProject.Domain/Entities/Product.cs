using SampleProject.Domain.Enums;

namespace SampleProject.Domain.Entities
{
    public class Product : BaseEntity<Guid>
    {
        public string Title { get; set; }
        public ProductType Type { get; set; }
        public double Price { get; set; } // decimal seems a better datatype but as u wish
        public ProductColorType Color { get; set; }

    }
}
