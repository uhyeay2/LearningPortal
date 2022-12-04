using Dapper;

namespace LearningPortal.Data
{
    public class DataConnection : IDataConnection
    {
        public DataConnection(IDbConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;

        private readonly IDbConnectionFactory _connectionFactory;

        public async Task<int> ExecuteAsync<TInput>(TInput request) where TInput : IDataRequestObject
        {
            using var connection = _connectionFactory.NewConnection();

            return await connection.ExecuteAsync(request.GenerateSql(), request.GenerateParameters());
        }

        public async Task<TOutput?> FetchAsync<TInput, TOutput>(TInput request) where TInput : IDataRequestObject
        {
            using var connection = _connectionFactory.NewConnection();

            return (await connection.QueryAsync<TOutput>(request.GenerateSql(), request.GenerateParameters())).FirstOrDefault();
        }

        public async Task<IEnumerable<TOutput>> FetchListAsync<TInput, TOutput>(TInput request) where TInput : IDataRequestObject
        {
            using var connection = _connectionFactory.NewConnection();

            return await connection.QueryAsync<TOutput>(request.GenerateSql(), request.GenerateParameters());
        }
    }
}