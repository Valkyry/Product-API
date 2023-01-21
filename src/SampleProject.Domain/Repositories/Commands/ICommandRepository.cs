namespace SampleProject.Domain.Repositories.Commands
{
    public interface ICommandRepository<TEntity, TStruct> where TEntity : class where TStruct : struct
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
