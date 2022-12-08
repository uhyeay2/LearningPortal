using Moq;
using LearningPortal.Domain.Interfaces;

namespace LearningPortal.Data.Tests
{
    public abstract class BaseDataTest
    {
        private const string _testEnvConnectionString = "Data Source=DESKTOP-8SSG6EN;Initial Catalog=LearningPortal_TestEnv;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected readonly DataConnection _data;

        internal readonly DataSeeder _seeder;

        internal readonly DataRemover _remover;

        internal readonly DataFetcher _fetcher;

        public BaseDataTest()
        {
            var mockedIConfig = new Mock<IConfig>();

            mockedIConfig.Setup(_ => _.GetConfiguration()).Returns(_testEnvConnectionString);

            var connectionFactory = new DbConnectionFactory(mockedIConfig.Object);

            _data = new DataConnection(connectionFactory);

            _seeder = new(_data);

            _remover = new(_data);

            _fetcher = new(_data);
        }
    }
}
