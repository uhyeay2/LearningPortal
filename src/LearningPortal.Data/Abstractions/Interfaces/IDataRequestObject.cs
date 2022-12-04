namespace LearningPortal.Data.Abstractions.Interfaces
{
    public interface IDataRequestObject
    {
        public object? GenerateParameters();

        public string GenerateSql();
    }
}
