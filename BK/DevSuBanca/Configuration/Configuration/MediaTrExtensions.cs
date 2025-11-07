using MediatR;

namespace Configuracion
{
    public class MediatRTransaccionHandler<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
                                                                  where TRequest : IRequest<TResponse>
    {
        private readonly IUnitOfWork _unit;
        public MediatRTransaccionHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _unit.BeginTransaction();

            try
            {
                await next();

                _unit.SaveChanges();
                _unit.Commit();

            }
            catch (Exception ex)
            {
                _unit.Rollback();

                throw ex;

            }

            return await next();
        }
    }
}
