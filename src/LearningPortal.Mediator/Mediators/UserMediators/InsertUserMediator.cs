using LearningPortal.Data.DataRequestObjects.UserRequests;

namespace LearningPortal.Mediator.Mediators.UserMediators
{
    public class InsertUserRequest : RequiredIdentityRequest
    {
        public InsertUserRequest(string identity) : base(identity) { }
    }
    
    internal class InsertUserMediator : DataMediator<InsertUserRequest>
    {
        public InsertUserMediator(IDataConnection data) : base(data) { }

        protected override async Task<BaseResponse> Mediate(InsertUserRequest request, CancellationToken cancellationToken = default)
        {
            if (await _data.FetchAsync<bool>(new IsUserIdentityRegistered(request.Identity)))
            {
                return Response.AlreadyExists("User", $"Identity {request.Identity}");
            }

            await _data.ExecuteAsync(new InsertUser(request.Identity));

            return Response.Success();
        }
    }
}
