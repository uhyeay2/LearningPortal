namespace LearningPortal.Domain.Exceptions
{
    public class ValidationFailedMessage
    {
        public ValidationFailedMessage(string sourceOfValidationFailure, string validationFailureMessage)
        {
            SourceOfValidationFailure = sourceOfValidationFailure;
            ValidationFailureMessage = validationFailureMessage;
        }

        public string SourceOfValidationFailure { get; set; }

        public string ValidationFailureMessage { get; set; }
    }
}
