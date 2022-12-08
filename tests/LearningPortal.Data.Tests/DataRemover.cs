namespace LearningPortal.Data.Tests
{
    internal class DataRemover : DataEnvironmentModifier
    {
        public DataRemover(DataConnection data) : base(data) { }

        public async Task RemoveUsers(string where = "1 = 1") => 
            await _data.ExecuteAsync(new InlineSqlRequest($"DELETE FROM Users WHERE {where}"));
    }
}
