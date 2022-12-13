using LearningPortal.Data.Abstractions.BaseRequestObjects;

namespace LearningPortal.Data.DataRequestObjects.UserRequests
{
    public class IsUserIdentityRegistered : StringBasedRequest
    {
        public IsUserIdentityRegistered(string userIdentity) => _string = userIdentity;

        public override string GenerateSql() => Fetch.Exists(Table.Users_NoLock, "IdentityIdentifier = @_string");
    }
}