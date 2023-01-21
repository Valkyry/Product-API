using Microsoft.EntityFrameworkCore;
using SampleProject.Domain.Repositories.Commands;
using SampleProject.Domain.Entities;

namespace SampleProject.Infrastructure.Repositories.Commands
{
    public class CommandRepository<TEntity, TStruct> : ICommandRepository<TEntity, TStruct> where TEntity : BaseEntity<TStruct> where TStruct : struct
    {
        protected readonly EFContext _context;

        public CommandRepository(EFContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            entity.CreateDate = DateTime.Now;

            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _context.Set<TEntity>().Remove(entity);
            var rowChanged = await _context.SaveChangesAsync(cancellationToken);
            return rowChanged > 0;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            entity.LastModifiedDate = DateTime.Now;

            _context.Entry(entity).State = EntityState.Modified;
            var rowChanged = await _context.SaveChangesAsync(cancellationToken);
            return rowChanged > 0;
        }
    }
}
