namespace LearningPortal.Data.Abstractions.Interfaces
{
    internal interface IDataConnection
    {
        public Task<IEnumerable<TOutput>> FetchListAsync<TInput, TOutput>(TInput request) where TInput : IDataRequestObject;

        public Task<TOutput?> FetchAsync<TInput, TOutput>(TInput request) where TInput : IDataRequestObject;

        public Task<int> ExecuteAsync<TInput>(TInput request) where TInput : IDataRequestObject;
    }
}
