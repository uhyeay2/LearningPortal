using LearningPortal.Domain.Interfaces;
using System.Data.SqlClient;

namespace LearningPortal.Data
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        public DbConnectionFactory(IDataConfig sqlConfig) => _sqlConfig = sqlConfig;

        private readonly IConfig _sqlConfig;

        public System.Data.IDbConnection NewConnection()
        {
            var connection = new SqlConnection(_sqlConfig.GetConfiguration());

            connection.Open();

            return connection;
        }
    }
}
