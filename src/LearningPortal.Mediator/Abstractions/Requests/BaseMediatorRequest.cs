using LearningPortal.Domain.Exceptions;
using LearningPortal.Domain.Interfaces;
using LearningPortal.Mediator.Abstractions.Responses;

namespace LearningPortal.Mediator.Abstractions.Requests
{
    public abstract class BaseMediatorRequest : MediatR.IRequest<BaseResponse>
    {
    }

    public abstract class BaseValidatableRequest : BaseMediatorRequest, IValidatable
    {
        public abstract bool IsValid(out List<ValidationFailedMessage> validationFailures);
    }
}
