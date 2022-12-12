using LearningPortal.Domain.Exceptions;

namespace LearningPortal.Domain.Interfaces
{
    public interface IValidatable
    {
        public bool IsValid(out List<ValidationFailedMessage> validationFailures);
    }
}
