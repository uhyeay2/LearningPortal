using LearningPortal.Data.DataRequestObjects.UserRequests;

namespace LearningPortal.Mediator.Mediators.UserMediators
{
    public class IsUserIdentityRegisteredRequest : RequiredIdentityRequest
    {
        public IsUserIdentityRegisteredRequest(string identity) : base(identity) { }
    }

    internal class IsUserIdentityRegisteredMediator : DataMediator<IsUserIdentityRegisteredRequest>
    {
        public IsUserIdentityRegisteredMediator(IDataConnection data) : base(data) { }

        protected override async Task<BaseResponse> Mediate(IsUserIdentityRegisteredRequest request, CancellationToken cancellationToken = default) =>
            Response.Success(await _data.FetchAsync<bool>(new IsUserIdentityRegistered(request.Identity)));
    }
}
