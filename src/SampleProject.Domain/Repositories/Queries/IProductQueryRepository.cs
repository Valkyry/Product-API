using SampleProject.Domain.Entities;
using SampleProject.Domain.Enums;

namespace SampleProject.Domain.Repositories.Queries
{
    public interface IProductQueryRepository : IQueryRepository<Product, Guid>
    {
        Task<(int, int, IReadOnlyCollection<Product>)> GetAsync(ProductType type, int take, int skip, CancellationToken cancellationToken);
        Task<(int, int, IReadOnlyCollection<Product>)> GetAsync(ProductColorType productColorType, int take, int skip, CancellationToken cancellationToken);
        Task<(int, int, IReadOnlyCollection<Product>)> GetAsync(ProductType type, ProductColorType productColorType, int take, int skip, CancellationToken cancellationToken);
    }
}
