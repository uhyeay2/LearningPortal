namespace LearningPortal.Data.Tests._DataTestingObjects
{
    internal class DataSeeder : DataEnvironmentModifier
    {
        public DataSeeder(DataConnection data) : base(data) { }

        public async Task SeedUser(string identityIdentifier, Guid? guid = null, DateTime? createdAtDateTimeUTC = null) =>
            await _data.ExecuteAsync(new InlineSqlRequest(
                $@"
                    INSERT INTO Users (IdentityIdentifier, Guid, CreatedAtDateTimeUTC )
                    VALUES ('{identityIdentifier}', '{guid ?? Guid.NewGuid()}', '{createdAtDateTimeUTC ?? DateTime.UtcNow}' )
                "));

        public async Task SeedUserAndContactInfo(string identity, Guid? userGuid = null, string firstName = "FirstName", string lastName = "LastName", 
            string preferredName = "PreferredName", string email = "email")
        {
            await SeedUser(identity, userGuid);

            await _data.ExecuteAsync(new InlineSqlRequest(
            $@"
                INSERT INTO UsersContactInfo ( FirstName, LastName, PreferredName, Email, UserId )
                VALUES ( '{firstName}', '{lastName}', '{preferredName}', '{email}', (SELECT Id FROM Users WHERE IdentityIdentifier = '{identity}') )
            "));
        }
    }
}
