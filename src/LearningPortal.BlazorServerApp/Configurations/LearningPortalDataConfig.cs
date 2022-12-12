using LearningPortal.Domain.Interfaces;

namespace LearningPortal.BlazorServerApp.Configurations
{
    public class LearningPortalDataConfig : IDataConfig
    {
        private const string _configKey = "ConnectionStrings:LearningPortalDatabase";

        private static IConfigurationRoot GetConfigRoot() => new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        public string GetConfiguration() => GetConfigRoot()[_configKey];
    }
}
