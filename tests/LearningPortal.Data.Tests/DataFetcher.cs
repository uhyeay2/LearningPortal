namespace LearningPortal.Data.Tests
{
    internal class DataFetcher : DataEnvironmentModifier
    {
        public DataFetcher(DataConnection data) : base(data) { }

        public async Task<TContent?> Fetch<TContent>(string table, string columns = "*", string where = "1 = 1") =>
            await _data.FetchAsync<InlineSqlRequest, TContent>(new($"SELECT {columns} FROM {table} WHERE {where}"));
    }
}
