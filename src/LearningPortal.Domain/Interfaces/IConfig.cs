namespace LearningPortal.Domain.Interfaces
{
    public interface IDataConfig : IConfig { }

    public interface IConfig
    {
        string GetConfiguration();
    }
}
