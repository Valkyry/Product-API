using SampleProject.Application.Common.Mappers;
using SampleProject.Domain.Repositories.Commands;
using SampleProject.Domain.Repositories.Queries;

namespace SampleProject.Application.Products
{
    public partial class Create
    {
        public class CreateHandler : Base<Request, Response, IProductCommandRepository, IProductQueryRepository>
        {
            public CreateHandler(IProductCommandRepository commandRepository, IProductQueryRepository queryRepository) : base(commandRepository, queryRepository)
            {

            }

            public override async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
            {
                var entity = AppMapper.Mapper.Map<Domain.Entities.Product>(request);

                if (entity is null)
                {
                    throw new ApplicationException("Mapper issue");
                }

                try
                {
                    var result = await _commandRepository.AddAsync(entity, cancellationToken);
                    return AppMapper.Mapper.Map<Response>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
