namespace LearningPortal.Mediator.Abstractions.Mediation
{
    internal abstract class BaseMediator<TRequest> : MediatR.IRequestHandler<TRequest, BaseResponse> where TRequest : BaseMediatorRequest
    {
        protected abstract Task<BaseResponse> Mediate(TRequest request, CancellationToken cancellationToken = default);

        public async Task<BaseResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            if (request is Domain.Interfaces.IValidatable validatable && !validatable.IsValid(out var failures))
                return Response.ValidationFailed(failures);

            return await Mediate(request, cancellationToken);
        }
    }
}
