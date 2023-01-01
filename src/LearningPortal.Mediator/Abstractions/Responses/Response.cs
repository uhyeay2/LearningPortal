namespace LearningPortal.Mediator.Abstractions.Responses
{
    public static class Response
    {
        public static BaseResponse Success(object? content = null) => new(statusCode: 200, content);

        public static BaseResponse ValidationFailed(List<Domain.Models.ValidationFailedMessage> validationFailures) =>
            new(statusCode: 400, validationFailures);

        public static BaseResponse NotFound(string nameOfObjectNotFound, string searchParameters) =>
            new(statusCode: 404, $"{nameOfObjectNotFound} was not found with {searchParameters}");

        public static BaseResponse AlreadyExists(string nameOfObjectAlreadyExisting, string conflictingItems) =>
            new(statusCode: 409, $"object ({nameOfObjectAlreadyExisting}) already exists with {conflictingItems}");

        public static BaseResponse Exception(Exception e) => new(statusCode: 500, content: e);

        public static BaseResponse Unexpected(string details) => new(statusCode: 500, content: new Exception(details));
    }
}
