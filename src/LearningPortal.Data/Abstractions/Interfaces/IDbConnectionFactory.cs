namespace LearningPortal.Data.Abstractions.Interfaces
{
    public interface IDbConnectionFactory
    {
        System.Data.IDbConnection NewConnection();
    }
}
