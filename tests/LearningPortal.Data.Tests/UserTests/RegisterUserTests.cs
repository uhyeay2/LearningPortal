using LearningPortal.Data.DataRequestObjects.UserRequests;

namespace LearningPortal.Data.Tests.UserTests
{
    public class RegisterUserTests : BaseDataTest
    {
        [Fact]
        public async Task RegisterUser_Given_IdentityIdentifierIsUnique_Should_InsertRecordWithIdentityProvided()
        {
            var identity = "UniqueIdentity";
            await _data.ExecuteAsync(new InsertUser(identity));

            var insertedIdentity = await _fetcher.Fetch<string>(table: "Users", columns: "IdentityIdentifier", where: $"IdentityIdentifier = '{identity}'");

            await _remover.RemoveUsers(where: $"IdentityIdentifier = '{identity}'");

            Assert.Equal(identity, insertedIdentity);
        }

        [Fact]
        public async Task RegisterUser_Given_RecordIsInserted_Should_ReturnOne()
        {
            var identity = "InsertedIdentityReturnsOne";
            var affectedRows = await _data.ExecuteAsync(new InsertUser(identity));

            await _remover.RemoveUsers(where: $"IdentityIdentifier = '{identity}'");

            Assert.Equal(1, affectedRows);
        }

        [Fact]
        public async Task RegisterUser_Given_RecordIsNotInserted_Should_ReturnNegativeOne()
        {
            var identity = "RepeatedIdentityReturnsNegOne";
            await _data.ExecuteAsync(new InsertUser(identity));
            
            var affectedRows = await _data.ExecuteAsync(new InsertUser(identity));

            await _remover.RemoveUsers(where: $"IdentityIdentifier = '{identity}'");

            Assert.Equal(-1, affectedRows);
        }
    }
}
