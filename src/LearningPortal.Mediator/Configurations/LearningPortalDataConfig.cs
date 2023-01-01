using LearningPortal.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace LearningPortal.Mediator.Configurations
{
    internal class LearningPortalDataConfig : IDataConfig
    {
        private const string _configKey = "ConnectionStrings:LearningPortalDatabase";

        private static IConfigurationRoot GetConfigRoot() => new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        public string GetConfiguration() => GetConfigRoot()[_configKey]!;
    }
}
