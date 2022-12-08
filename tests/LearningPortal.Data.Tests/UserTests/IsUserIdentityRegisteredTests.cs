using LearningPortal.Data.DataRequestObjects.UserRequests;

namespace LearningPortal.Data.Tests.UserTests
{
    public class IsUserIdentityRegisteredTests : BaseDataTest
    {
        [Fact]
        public async Task IsUserIdentityRegistered_Given_IdentityIsNotRegistered_Should_ReturnFalse() => 
            Assert.False(await _data.FetchAsync<IsUserIdentityRegistered, bool>(new("NotRegistered")));

        [Fact]
        public async Task IsUserIdentityRegistered_Given_IdentityRegistered_Should_ReturnTrue()
        {
            var identity = "RegisteredIdentity";

            await _seeder.SeedUser(identityIdentifier: identity);

            var isRegistered = await _data.FetchAsync<IsUserIdentityRegistered, bool>(new(identity));

            await _remover.RemoveUsers(where: $"IdentityIdentifier = '{identity}'");

            Assert.True(isRegistered);
        }
    }
}
