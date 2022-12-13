using LearningPortal.Data.Abstractions.BaseRequestObjects;

namespace LearningPortal.Data.DataRequestObjects.UserRequests
{
    public class InsertUser : StringBasedRequest 
    {
        public InsertUser(string identityIdentifier) => _string = identityIdentifier;

        public override string GenerateSql() => Insert.IfNotExistsCommand(
            selectQueryToNotExist: Fetch.Query(Table.Users_NoLock, where: "IdentityIdentifier = @_string"),
            Table.Users, 
            columnNames: "IdentityIdentifier", 
            valueNames: "@_string");            
    }
}
