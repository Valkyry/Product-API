using SampleProject.Domain.Repositories.Commands;
using SampleProject.Domain.Repositories.Queries;

namespace SampleProject.Application.Products
{
    public partial class Delete
    {
        public class DeleteHandler : Base<Request, bool, IProductCommandRepository, IProductQueryRepository>
        {
            public DeleteHandler(IProductCommandRepository commandRepository, IProductQueryRepository queryRepository) : base(commandRepository, queryRepository)
            {

            }

            public override async Task<bool> Handle(Request request, CancellationToken cancellationToken = default)
            {

                try
                {
                    var entity = await _queryRepository.GetAsync(request.Id, cancellationToken);
                    var result = await _commandRepository.DeleteAsync(entity, cancellationToken);

                    return result;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
            }
        }
    }
}
