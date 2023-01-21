using Dapper;
using Microsoft.Extensions.Configuration;
using SampleProject.Domain.Repositories.Queries;
using SampleProject.Domain.Entities;
using SampleProject.Domain.Enums;

namespace SampleProject.Infrastructure.Repositories.Queries
{
    public class ProductQueryRepository : QueryRepository<Product, Guid>, IProductQueryRepository
    {
        public ProductQueryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<(int, int, IReadOnlyCollection<Product>)> GetAsync(ProductType type, ProductColorType productColorType, int take, int skip, CancellationToken cancellationToken)
        {
            try
            {
                var query = "SELECT * FROM Product WHERE Type = @Type AND Color = @Color ORDER BY CreateDate OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY; SELECT COUNT(*) FROM Product WHERE Type = @Type AND Color = @Color";

                var parameters = new DynamicParameters();
                parameters.Add("@Skip", skip);
                parameters.Add("@Take", take);
                parameters.Add("@Type", (int)type);
                parameters.Add("@Color", (int)productColorType);

                using (var connection = CreateConnection())
                {
                    var cmd = new CommandDefinition(query, parameters: parameters, cancellationToken: cancellationToken);

                    var raw = await connection.QueryMultipleAsync(cmd);

                    var entities = (await raw.ReadAsync<Product>()).ToList();
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

        public async Task<(int, int, IReadOnlyCollection<Product>)> GetAsync(ProductType type, int take, int skip, CancellationToken cancellationToken)
        {
            try
            {
                var query = "SELECT * FROM Product WHERE Type = @Type ORDER BY CreateDate OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY; SELECT COUNT(*) FROM Product WHERE Type = @Type";

                var parameters = new DynamicParameters();
                parameters.Add("@Skip", skip);
                parameters.Add("@Take", take);
                parameters.Add("@Type", (int)type);

                using (var connection = CreateConnection())
                {
                    var cmd = new CommandDefinition(query, parameters: parameters, cancellationToken: cancellationToken);

                    var raw = await connection.QueryMultipleAsync(cmd);

                    var entities = (await raw.ReadAsync<Product>()).ToList();
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

        public async Task<(int, int, IReadOnlyCollection<Product>)> GetAsync(ProductColorType productColorType, int take, int skip, CancellationToken cancellationToken)
        {
            try
            {
                var query = "SELECT * FROM Product WHERE Color = @Color ORDER BY CreateDate OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY; SELECT COUNT(*) FROM Product WHERE Color = @Color";

                var parameters = new DynamicParameters();
                parameters.Add("@Skip", skip);
                parameters.Add("@Take", take);
                parameters.Add("@Color", (int)productColorType);

                using (var connection = CreateConnection())
                {
                    var cmd = new CommandDefinition(query, parameters: parameters, cancellationToken: cancellationToken);

                    var raw = await connection.QueryMultipleAsync(cmd);

                    var entities = (await raw.ReadAsync<Product>()).ToList();
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
    }
}
