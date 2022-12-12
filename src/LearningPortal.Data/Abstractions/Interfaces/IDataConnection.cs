namespace LearningPortal.Data.Abstractions.Interfaces
{
    public interface IDataConnection
    {
        public Task<IEnumerable<TOutput>> FetchListAsync<TOutput>(IDataRequestObject request);

        public Task<TOutput?> FetchAsync<TOutput>(IDataRequestObject request);

        public Task<int> ExecuteAsync(IDataRequestObject request);
    }
}
