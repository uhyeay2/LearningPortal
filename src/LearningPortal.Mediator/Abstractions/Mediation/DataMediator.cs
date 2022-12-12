using LearningPortal.Data.Abstractions.Interfaces;
using LearningPortal.Mediator.Abstractions.Requests;

namespace LearningPortal.Mediator.Abstractions.Mediation
{
    internal abstract class DataMediator<TRequest> : BaseMediator<TRequest> where TRequest : BaseMediatorRequest
    {
        protected readonly IDataConnection _data;

        public DataMediator(IDataConnection data)
        {
            _data = data;
        }
    }
}
