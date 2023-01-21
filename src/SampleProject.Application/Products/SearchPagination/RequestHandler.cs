using SampleProject.Application.Common.Mappers;
using SampleProject.Application.DTO;
using SampleProject.Domain.Enums;
using SampleProject.Domain.Repositories.Commands;
using SampleProject.Domain.Repositories.Queries;

namespace SampleProject.Application.Products
{
    public partial class SearchPagination
    {
        public class GetPaginationHandler : Base<Request, Response, IProductCommandRepository, IProductQueryRepository>
        {
            public GetPaginationHandler(IProductCommandRepository commandRepository, IProductQueryRepository queryRepository) : base(commandRepository, queryRepository)
            {

            }

            public override async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
            {
                int skip = (request.PageNumber - 1) * request.PageSize;

                var ret = await _queryRepository.GetAsync((ProductType)request.Type, (ProductColorType)request.Color, request.PageSize, skip, cancellationToken);

                var entities = AppMapper.Mapper.Map<List<ProductResponse>>(ret.Item3);

                return new Response() { TotalRecord = ret.Item1, Page = ret.Item2, Result = entities };
            }
        }
    }
}
