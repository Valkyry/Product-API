using SampleProject.Domain.Entities;

namespace SampleProject.Domain.Repositories.Commands
{
    public interface IProductCommandRepository : ICommandRepository<Product, Guid>
    {
    }
}
