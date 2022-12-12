namespace LearningPortal.Data.Tests._DataTestingObjects
{
    internal class DataSeeder : DataEnvironmentModifier
    {
        public DataSeeder(DataConnection data) : base(data) { }

        public async Task SeedUser(string identityIdentifier = "IdentityIdentifier", Guid? guid = null, DateTime? createdAtDateTimeUTC = null) =>
            await _data.ExecuteAsync(new InlineSqlRequest(
                $"INSERT INTO Users (IdentityIdentifier, Guid, CreatedAtDateTimeUTC ) " +
                $"VALUES ('{identityIdentifier}', '{guid ?? Guid.NewGuid()}', '{createdAtDateTimeUTC ?? DateTime.UtcNow}' )"));
    }
}
