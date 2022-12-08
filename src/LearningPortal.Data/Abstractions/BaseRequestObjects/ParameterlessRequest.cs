namespace LearningPortal.Data.Abstractions.BaseRequestObjects
{
    public abstract class ParameterlessRequest : IDataRequestObject
    {
        public object? GenerateParameters() => null;

        public abstract string GenerateSql();
    }
}
