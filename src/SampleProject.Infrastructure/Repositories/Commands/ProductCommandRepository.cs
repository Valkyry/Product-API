using SampleProject.Domain.Repositories.Commands;
using SampleProject.Domain.Entities;

namespace SampleProject.Infrastructure.Repositories.Commands
{
    public class ProductCommandRepository : CommandRepository<Product,Guid>, IProductCommandRepository
    {
        public ProductCommandRepository(EFContext context) : base(context)
        {

        }
    }
}
