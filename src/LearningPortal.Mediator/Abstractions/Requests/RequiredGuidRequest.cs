using LearningPortal.Domain.Extensions;
using LearningPortal.Domain.Models;

namespace LearningPortal.Mediator.Abstractions.Requests
{
    public class RequiredGuidRequest : BaseValidatableRequest
    {
        public Guid? Guid { get; set; }

        public override bool IsValid(out List<ValidationFailedMessage> validationFailures)
        {
            validationFailures = new List<ValidationFailedMessage>();

            validationFailures.AddIfGuidIsNullOrEmpty(nameof(Guid), Guid);

            return !validationFailures.Any();
        }
    }
}
