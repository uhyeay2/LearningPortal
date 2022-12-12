using LearningPortal.Domain.Exceptions;
using LearningPortal.Mediator.Constants;

namespace LearningPortal.Mediator.Abstractions.Requests
{
    public abstract class RequiredIdentityRequest : BaseValidatableRequest
    {
        public RequiredIdentityRequest(string identity) => Identity = identity;

        public string Identity { get; set; } = null!;

        public override bool IsValid(out List<ValidationFailedMessage> validationFailures)
        {
            validationFailures = new List<ValidationFailedMessage>();
            var isValid = true;

            if (string.IsNullOrWhiteSpace(Identity))
            {
                isValid = false;
                validationFailures.Add(new(nameof(Identity), ValidationFailureMessage.RequiredString));
            }

            return isValid;
        }
    }
}
