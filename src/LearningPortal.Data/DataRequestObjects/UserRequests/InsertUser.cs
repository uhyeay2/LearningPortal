using LearningPortal.Data.Abstractions.BaseRequestObjects;

namespace LearningPortal.Data.DataRequestObjects.UserRequests
{
    public class InsertUser : StringBasedRequest 
    {
        public InsertUser(string identityIdentifier) => _string = identityIdentifier;

        public override string GenerateSql() => "IF NOT EXISTS( SELECT * FROM Users WITH(NOLOCK) WHERE Users.IdentityIdentifier = @_string )" + 
            Insert.Command(Table.Users, "IdentityIdentifier", "@_string");
    }
}
