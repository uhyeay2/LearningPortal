namespace LearningPortal.Data.Abstractions.BaseRequestObjects
{
    public abstract class StringBasedRequest : IDataRequestObject
    {
        protected string? _string = null;

        public object? GenerateParameters() => new { _string };

        public abstract string GenerateSql();
    }
}
