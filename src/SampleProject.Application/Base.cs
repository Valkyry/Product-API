using MediatR;

namespace SampleProject.Application
{
    public abstract class Base<TRequest, TResponse, TCommandRepository, TQueryRepository> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly TCommandRepository _commandRepository;
        protected readonly TQueryRepository _queryRepository;

        public Base(TCommandRepository commandRepository, TQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public virtual Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken = default)
        {
            return null;
        }

    }
}
