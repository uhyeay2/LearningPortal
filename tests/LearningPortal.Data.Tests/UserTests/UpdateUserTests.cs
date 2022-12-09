using LearningPortal.Data.DataRequestObjects.UserRequests;

namespace LearningPortal.Data.Tests.UserTests
{
    public class UpdateUserTests : BaseDataTest
    {
        [Fact]
        public async Task UpdateUser_Given_PreferredNameIsNotNull_Should_UpdatePreferredName()
        {
            var identity = "UpdatePreferredName";
            var newName = "NewPreferredName";
            await _seeder.SeedUser(identityIdentifier: identity, preferredName: "OriginalPreferredName");

            await _data.ExecuteAsync(new UpdateUser(identity, newName));

            var updatedPreferredName = await _fetcher.Fetch<string>("Users", "PreferredName", where: $"IdentityIdentifier = '{identity}'");

            await _remover.RemoveUsers(where: $"IdentityIdentifier = '{identity}'");

            Assert.Equal(newName, updatedPreferredName);
        }

        [Fact]
        public async Task UpdateUser_Given_PreferredNameIsNull_Should_NotChangePreferredName()
        {
            var identity = "UpdateNullPreferredNameMakesNoChange";
            var originalPreferredName = "UnchangedName";
            await _seeder.SeedUser(identityIdentifier: identity, preferredName: originalPreferredName);

            await _data.ExecuteAsync(new UpdateUser(identity, null));

            var unchangedPreferredName = await _fetcher.Fetch<string>("Users", "PreferredName", where: $"IdentityIdentifier = '{identity}'");

            await _remover.RemoveUsers(where: $"IdentityIdentifier = '{identity}'");

            Assert.Equal(originalPreferredName, unchangedPreferredName);
        }

        [Fact]
        public async Task UpdateUser_Given_IdentityIsNull_Should_ReturnZero() =>
            Assert.Equal(0, await _data.ExecuteAsync(new UpdateUser(null!, string.Empty)));

        [Fact]
        public async Task UpdateUser_Given_IdentityFindsNoMatch_Should_ReturnZero() =>
            Assert.Equal(0, await _data.ExecuteAsync(new UpdateUser(null!, string.Empty)));
    }
}
