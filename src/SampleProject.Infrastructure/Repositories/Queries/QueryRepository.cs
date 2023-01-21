using Dapper;
using Microsoft.Extensions.Configuration;
using SampleProject.Domain.Repositories.Queries;
using SampleProject.Domain.Entities;

namespace SampleProject.Infrastructure.Repositories.Queries
{
    public class QueryRepository<TEntity, TStruct> : DapperContext, IQueryRepository<TEntity, TStruct> where TEntity : BaseEntity<TStruct> where TStruct : struct
    {
        public QueryRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public virtual async Task<(int, int, IReadOnlyCollection<TEntity>)> GetAsync(int take, int skip, CancellationToken cancellationToken)
        {
            try
            {
                var query = $"SELECT * FROM {typeof(TEntity).Name} ORDER BY CreateDate OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY; SELECT COUNT(*) FROM {typeof(TEntity).Name}";

                var parameters = new DynamicParameters();
                parameters.Add("@Skip", skip);
                parameters.Add("@Take", take);

                var cmd = new CommandDefinition(query, parameters: parameters, cancellationToken: cancellationToken);

                using (var connection = CreateConnection())
                {
                    var raw = await connection.QueryMultipleAsync(cmd);

                    var entities = (await raw.ReadAsync<TEntity>()).ToList();
                    var totalCount = await raw.ReadFirstOrDefaultAsync<int>();

                    var pageCount = (totalCount + take - 1) / take;

                    return (totalCount, pageCount, entities);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<TEntity> GetAsync(TStruct id, CancellationToken cancellationToken)
        {
            try
            {
                var query = $"SELECT * FROM {typeof(TEntity).Name} WHERE Id = @Id";

                using (var connection = CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);

                    var cmd = new CommandDefinition(query, parameters, cancellationToken: cancellationToken);
                    return (await connection.QueryAsync<TEntity>(cmd)).FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
