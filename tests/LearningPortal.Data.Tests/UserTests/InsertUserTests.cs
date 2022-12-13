using LearningPortal.Data.DataRequestObjects.UserRequests;

namespace LearningPortal.Data.Tests.UserTests
{
    public class InsertUserTests : BaseDataTest
    {
        [Fact]
        public async Task InsertUser_Given_IdentityIdentifierIsUnique_Should_InsertRecordWithIdentityProvided()
        {
            var identity = "UniqueIdentityInsertsRecord";
            await _data.ExecuteAsync(new InsertUser(identity));

            var insertedIdentity = await _fetcher.Fetch<string>(table: "Users", columns: "IdentityIdentifier", where: $"IdentityIdentifier = '{identity}'");

            await _remover.RemoveUsers(where: $"IdentityIdentifier = '{identity}'");

            Assert.Equal(identity, insertedIdentity);
        }

        [Fact]
        public async Task InsertUser_Given_IdentityIdentifierIsNotUnique_Should_NotInsertRecord()
        {
            var identity = "NonUniqueIdentityDoesNotInsertRecord";

            await _data.ExecuteAsync(new InsertUser(identity));

            var countAfterFirstInsert = await _fetcher.Count("Users", $"IdentityIdentifier = '{identity}'");

            Assert.Equal(1, countAfterFirstInsert);

            await _data.ExecuteAsync(new InsertUser(identity));
            
            var countAfterSecondInsert = await _fetcher.Count("Users", $"IdentityIdentifier = '{identity}'");

            await _remover.RemoveUsers(where: $"IdentityIdentifier = '{identity}'");

            Assert.Equal(countAfterFirstInsert, countAfterSecondInsert);
        }

        [Fact]
        public async Task InsertUser_Given_UserIsRegistered_Should_GenerateNewGuid()
        {
            var identity = "NewUserGeneratesGuid";
            await _data.ExecuteAsync(new InsertUser(identity));

            var insertedGuid = await _fetcher.Fetch<Guid?>(table: "Users", columns: "Guid", where: $"IdentityIdentifier = '{identity}'");

            await _remover.RemoveUsers(where: $"IdentityIdentifier = '{identity}'");

            Assert.NotNull(insertedGuid);
            Assert.True(insertedGuid != Guid.Empty);
        }

        [Fact]
        public async Task InsertUser_Given_UserIsRegistered_Should_GenerateCreatedAtDateUTC()
        {
            var identity = "NewUserGeneratesCreatedAtDateTimeUTC";
            await _data.ExecuteAsync(new InsertUser(identity));

            var insertedCreatedAtDateTimeUTC = await _fetcher.Fetch<DateTime?>(table: "Users", columns: "CreatedAtDateTimeUTC", where: $"IdentityIdentifier = '{identity}'");

            await _remover.RemoveUsers(where: $"IdentityIdentifier = '{identity}'");

            Assert.NotNull(insertedCreatedAtDateTimeUTC);
        }

        [Fact]
        public async Task InsertUser_Given_RecordIsInserted_Should_ReturnOne()
        {
            var identity = "InsertedIdentityReturnsOne";
            var affectedRows = await _data.ExecuteAsync(new InsertUser(identity));

            await _remover.RemoveUsers(where: $"IdentityIdentifier = '{identity}'");

            Assert.Equal(1, affectedRows);
        }

        [Fact]
        public async Task InsertUser_Given_RecordIsNotInserted_Should_ReturnNegativeOne()
        {
            var identity = "UserNotInsertedReturnsNegativeOne";
            await _data.ExecuteAsync(new InsertUser(identity));
            
            var affectedRows = await _data.ExecuteAsync(new InsertUser(identity));

            await _remover.RemoveUsers(where: $"IdentityIdentifier = '{identity}'");

            Assert.Equal(-1, affectedRows);
        }

        [Fact]
        public async Task InsertUser_Given_IdentityIdentifierProvidedIsNull_Should_ThrowSqlException() =>
            Assert.IsType<System.Data.SqlClient.SqlException>(await Record.ExceptionAsync(async () => 
                await _data.ExecuteAsync(new InsertUser(null!))));
    }
}
