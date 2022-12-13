using LearningPortal.Data.DataRequestObjects.UserRequests;

namespace LearningPortal.Data.Tests.UserTests
{
    public class IsUserIdentityRegisteredTests : BaseDataTest
    {
        [Fact]
        public async Task IsUserIdentityRegistered_Given_IdentityIsNotRegistered_Should_ReturnFalse() => 
            Assert.False(await _data.FetchAsync<bool>(new IsUserIdentityRegistered("NotRegistered")));

        [Fact]
        public async Task IsUserIdentityRegistered_Given_IdentityRegistered_Should_ReturnTrue()
        {
            var identity = "RegisteredIdentity";

            await _seeder.SeedUser(identityIdentifier: identity);

            var isRegistered = await _data.FetchAsync<bool>(new IsUserIdentityRegistered(identity));

            await _remover.RemoveUserByIdentity(identity);

            Assert.True(isRegistered);
        }
    }
}
