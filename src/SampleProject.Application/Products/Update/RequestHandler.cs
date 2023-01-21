using SampleProject.Application.Common.Mappers;
using SampleProject.Domain.Repositories.Commands;
using SampleProject.Domain.Repositories.Queries;

namespace SampleProject.Application.Products
{
    public partial class Update
    {
        public class UpdateHandler : Base<Request, Response, IProductCommandRepository, IProductQueryRepository>
        {
            public UpdateHandler(IProductCommandRepository commandRepository, IProductQueryRepository queryRepository) : base(commandRepository, queryRepository)
            {

            }

            public override async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
            {

                try
                {
                    var entity = await _queryRepository.GetAsync(request.Id, cancellationToken);

                    var modified = AppMapper.Mapper.Map<Request, Domain.Entities.Product>(request, entity);

                    await _commandRepository.UpdateAsync(modified, cancellationToken);

                    return AppMapper.Mapper.Map<Response>(modified);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }


            }
        }
    }
}
