namespace LearningPortal.Api.Configurations
{
    public class LearningPortalDbConfig
    {
        private const string _configKey = "ConnectionStrings:LearningPortalDatabase";

        private static IConfigurationRoot GetConfigRoot() => new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        public string GetConfiguration() => GetConfigRoot()[_configKey];
    }
}
