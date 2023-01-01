namespace LearningPortal.Data.Tests._DataTestingObjects
{
    internal class DataFetcher : DataEnvironmentModifier
    {
        public DataFetcher(DataConnection data) : base(data) { }

        public async Task<int> Count(string table, string where) =>
            await _data.FetchAsync<int>(new InlineSqlRequest($"SELECT COUNT(*) FROM {table} WHERE {where} "));

        public async Task<bool> Exists(string table, string where) =>
            await _data.FetchAsync<bool>(new InlineSqlRequest($"SELECT CASE WHEN EXISTS ( SELECT * FROM {table} WHERE {where} ) THEN 1 ELSE 0 END "));

        public async Task<TContent?> Fetch<TContent>(string table, string columns = "*", string where = "1 = 1", string join = "") =>
            await _data.FetchAsync<TContent>(new InlineSqlRequest($"SELECT {columns} FROM {table} {join} WHERE {where}"));
    }
}
