namespace LearningPortal.Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationFailedMessage> validationFailures)
        {
            ValidationFailures = validationFailures;
        }

        public IEnumerable<ValidationFailedMessage> ValidationFailures { get; set; }
    }
}
