namespace LearningPortal.Mediator.Abstractions.Responses
{
    public class BaseResponse
    {
        public BaseResponse(int statusCode, object? content)
        {
            StatusCode = statusCode;
            Content = content;
        }

        public int StatusCode { get; set; }

        public object? Content { get; set; }

        public TContent? ContentAs<TContent>()
        {
            if (Content == null)
            {
                return default;
            }

            return (TContent)Content;
        }

        public bool HasStatusCode200 => StatusCode == 200;
    }
}
