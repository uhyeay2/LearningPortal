using LearningPortal.Data.DataRequestObjects.UsersContactInfo;

namespace LearningPortal.Data.Tests.UserContactInfoTests
{    
    public class UpdateUserContactInfoTests : BaseDataTest
    {
        #region User Exists / DoesNotExist 

        [Fact]
        public async Task UpdateUserContactInfo_Given_UserDoesNotExistWithGuid_Should_ReturnZero() =>
            Assert.Equal(0, await _data.ExecuteAsync(new UpdateUserContactInfo(Guid.NewGuid())));

        [Fact]
        public async Task UpdateUserContactInfo_Given_UserExistsWithGuid_Should_ReturnOne() 
        {
            var identity = "UpdateUserContactInfoUserExistsReturnsOne";
            var userGuid = Guid.NewGuid();

            await _seeder.SeedUserAndContactInfo(identity, userGuid);

            var result = await _data.ExecuteAsync(new UpdateUserContactInfo(userGuid));

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(1, result);
        }

        #endregion

        #region FirstName Is Null / Has Value

        [Fact]
        public async Task UpdateUserContactInfo_Given_FirstNameIsProvided_Should_UpdateFirstName()
        {
            var identity = "UpdateUserContactInfoGivenFirstName";
            var userGuid = Guid.NewGuid();
            var expectedFirstName = "ExpectedFirstName";

            await _seeder.SeedUserAndContactInfo(identity, userGuid, firstName: "OriginalFirstName");

            await _data.ExecuteAsync(new UpdateUserContactInfo(userGuid, firstName: expectedFirstName));

            var updatedName = await _fetcher.Fetch<string>("UsersContactInfo", "FirstName", $"Guid = '{userGuid}'", "Join Users on Users.Id = UsersContactInfo.UserId");

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(expectedFirstName, updatedName);
        }

        [Fact]
        public async Task UpdateUserContactInfo_Given_FirstNameIsNull_Should_NotChangeFirstName()
        {
            var identity = "UpdateUserContactInfoGivenNullFirstName";
            var userGuid = Guid.NewGuid();
            var originalFirstName = "ExpectedFirstName";

            await _seeder.SeedUserAndContactInfo(identity, userGuid, firstName: originalFirstName);

            await _data.ExecuteAsync(new UpdateUserContactInfo(userGuid, firstName: null));

            var updatedName = await _fetcher.Fetch<string>("UsersContactInfo", "FirstName", $"Guid = '{userGuid}'", "Join Users on Users.Id = UsersContactInfo.UserId");

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(originalFirstName, updatedName);
        }

        #endregion

        #region LastName Is Null / Has Value

        [Fact]
        public async Task UpdateUserContactInfo_Given_LastNameIsProvided_Should_UpdateLastName()
        {
            var identity = "UpdateUserContactInfoGivenLastName";
            var userGuid = Guid.NewGuid();
            var expectedLastName = "ExpectedLastName";

            await _seeder.SeedUserAndContactInfo(identity, userGuid, lastName: "OriginalLastName");

            await _data.ExecuteAsync(new UpdateUserContactInfo(userGuid, lastName: expectedLastName));

            var updatedName = await _fetcher.Fetch<string>("UsersContactInfo", "LastName", $"Guid = '{userGuid}'", "Join Users on Users.Id = UsersContactInfo.UserId");

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(expectedLastName, updatedName);
        }

        [Fact]
        public async Task UpdateUserContactInfo_Given_LastNameIsNull_Should_NotChangeLastName()
        {
            var identity = "UpdateUserContactInfoGivenNullLastName";
            var userGuid = Guid.NewGuid();
            var originalLastName = "ExpectedLastName";

            await _seeder.SeedUserAndContactInfo(identity, userGuid, lastName: originalLastName);

            await _data.ExecuteAsync(new UpdateUserContactInfo(userGuid, lastName: null));

            var updatedName = await _fetcher.Fetch<string>("UsersContactInfo", "LastName", $"Guid = '{userGuid}'", "Join Users on Users.Id = UsersContactInfo.UserId");

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(originalLastName, updatedName);
        }

        #endregion

        #region PreferredName Is Null / Has Value

        [Fact]
        public async Task UpdateUserContactInfo_Given_PreferredNameIsProvided_Should_UpdateLastName()
        {
            var identity = "UpdateUserContactInfoGivenPreferredName";
            var userGuid = Guid.NewGuid();
            var expectedPreferredName = "ExpectedPreferredName";

            await _seeder.SeedUserAndContactInfo(identity, userGuid, preferredName: "OriginalPreferredName");

            await _data.ExecuteAsync(new UpdateUserContactInfo(userGuid, preferredName: expectedPreferredName));

            var updatedName = await _fetcher.Fetch<string>("UsersContactInfo", "PreferredName", $"Guid = '{userGuid}'", "Join Users on Users.Id = UsersContactInfo.UserId");

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(expectedPreferredName, updatedName);
        }

        [Fact]
        public async Task UpdateUserContactInfo_Given_PrefferedNameIsNull_Should_NotChangePreferredName()
        {
            var identity = "UpdateUserContactInfoGivenNullPreferredName";
            var userGuid = Guid.NewGuid();
            var originalPreferredName = "ExpectedPreferredName";

            await _seeder.SeedUserAndContactInfo(identity, userGuid, preferredName: originalPreferredName);

            await _data.ExecuteAsync(new UpdateUserContactInfo(userGuid, preferredName: null));

            var updatedName = await _fetcher.Fetch<string>("UsersContactInfo", "PreferredName", $"Guid = '{userGuid}'", "Join Users on Users.Id = UsersContactInfo.UserId");

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(originalPreferredName, updatedName);
        }

        #endregion

        #region Email Is Null / Has Value

        [Fact]
        public async Task UpdateUserContactInfo_Given_EmailIsProvided_Should_UpdateEmail()
        {
            var identity = "UpdateUserContactInfoGivenEmail";
            var userGuid = Guid.NewGuid();
            var expectedEmail = "ExpectedEmail";

            await _seeder.SeedUserAndContactInfo(identity, userGuid, email: "OriginalEmail");

            await _data.ExecuteAsync(new UpdateUserContactInfo(userGuid, email: expectedEmail));

            var updatedName = await _fetcher.Fetch<string>("UsersContactInfo", "Email", $"Guid = '{userGuid}'", "Join Users on Users.Id = UsersContactInfo.UserId");

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(expectedEmail, updatedName);
        }

        [Fact]
        public async Task UpdateUserContactInfo_Given_EmailIsNull_Should_NotChangeEmail()
        {
            var identity = "UpdateUserContactInfoGivenNullEmail";
            var userGuid = Guid.NewGuid();
            var originalEmail = "ExpectedEmail";

            await _seeder.SeedUserAndContactInfo(identity, userGuid, email: originalEmail);

            await _data.ExecuteAsync(new UpdateUserContactInfo(userGuid, email: null));

            var updatedEmail = await _fetcher.Fetch<string>("UsersContactInfo", "Email", $"Guid = '{userGuid}'", "Join Users on Users.Id = UsersContactInfo.UserId");

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(originalEmail, updatedEmail);
        }

        #endregion
    }
}
