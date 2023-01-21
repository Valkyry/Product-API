using SampleProject.Domain.Entities;

namespace SampleProject.Domain.Repositories.Queries
{
    public interface IQueryRepository<TEntity, TStruct> where TEntity : BaseEntity<TStruct> where TStruct : struct
    {
        Task<TEntity> GetAsync(TStruct id, CancellationToken cancellationToken);
        Task<(int, int, IReadOnlyCollection<TEntity>)> GetAsync(int take, int skip, CancellationToken cancellationToken);
    }
}
