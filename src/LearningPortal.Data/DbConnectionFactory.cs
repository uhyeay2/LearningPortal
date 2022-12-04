using LearningPortal.Domain.Interfaces;

namespace LearningPortal.Data
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        public DbConnectionFactory(IConfig sqlConfig) => _sqlConfig = sqlConfig;

        private readonly IConfig _sqlConfig;

        public System.Data.IDbConnection NewConnection()
        {
            var connection = new System.Data.SqlClient.SqlConnection(_sqlConfig.GetConfiguration());

            connection.Open();

            return connection;
        }
    }
}
