namespace LearningPortal.Data.Tests._DataTestingObjects
{
    internal class DataRemover : DataEnvironmentModifier
    {
        public DataRemover(DataConnection data) : base(data) { }

        public async Task RemoveUserByIdentity(string identity) =>
            await _data.ExecuteAsync(new InlineSqlRequest($"DELETE FROM Users WHERE IdentityIdentifier = '{identity}'"));

        public async Task RemoveUserAndContactInfoByIdentity(string identity)
        {
            await _data.ExecuteAsync(new InlineSqlRequest($@"
                DECLARE @UserId int = (SELECT Id from Users where IdentityIdentifier = '{identity}')
                DELETE FROM UsersContactInfo WHERE UserId = @UserId
            "));

            await RemoveUserByIdentity(identity);
        }
    }
}
