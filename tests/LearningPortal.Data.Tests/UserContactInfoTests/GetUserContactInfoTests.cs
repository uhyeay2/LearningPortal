using LearningPortal.Data.DataRequestObjects.UsersContactInfo;
using LearningPortal.Data.DataTransferObjects;

namespace LearningPortal.Data.Tests.UserContactInfoTests
{
    public class GetUserContactInfoTests : BaseDataTest
    {
        #region Given User Identity When Exists / Not Exists

        [Fact]
        public async Task GetUserContactInfo_Given_UserIdentity_OfExistingContactInfo_Should_NotReturnNull()
        {
            var identity = "GetExistingContactInfoByIdentity";

            await _seeder.SeedUserAndContactInfo(identity);

            var result = await _data.FetchAsync<UserContactInfoDTO>(new GetUserContactInfo(identity));

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetUserContactInfo_Given_UserIdentity_OfNonExistingContactInfo_Should_ReturnNull() =>
            Assert.Null(await _data.FetchAsync<UserContactInfoDTO>(new GetUserContactInfo("NonExistingIdentity")));

        #endregion

        #region Given User Guid When Exists / Not Exists

        [Fact]
        public async Task GetUserContactInfo_Given_UserGuid_OfExistingContactInfo_Should_NotReturnNull()
        {
            var userGuid = Guid.NewGuid();
            var identity = "GetExistingContactInfoByGuid";

            await _seeder.SeedUserAndContactInfo(identity, userGuid);

            var result = await _data.FetchAsync<UserContactInfoDTO>(new GetUserContactInfo(userGuid));

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetUserContactInfo_Given_UserGuid_OfNonExistingContactInfo_Should_ReturnNull() =>
            Assert.Null(await _data.FetchAsync<UserContactInfoDTO>(new GetUserContactInfo(Guid.NewGuid())));

        #endregion

        #region Given UserId When Exists / Not Exists

        [Fact]
        public async Task GetUserContactInfo_Given_UserId_OfExistingContactInfo_Should_NotReturnNull()
        {
            var identity = "GetExistingContactInfoByUserId";

            await _seeder.SeedUserAndContactInfo(identity);

            var userId = await _fetcher.Fetch<int>("Users", "Id", where: $"IdentityIdentifier = '{identity}'");

            var result = await _data.FetchAsync<UserContactInfoDTO>(new GetUserContactInfo(userId));

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetUserContactInfo_Given_UserId_OfNonExistingContactInfo_Should_ReturnNull() =>
            Assert.Null(await _data.FetchAsync<UserContactInfoDTO>(new GetUserContactInfo(0)));

        #endregion

        #region Given Contact Info Exists Should Return Properties

        [Fact]
        public async Task GetUserContactInfo_Given_ContactInfoExists_Should_ReturnFirstName()
        {
            var identity = "GetExistingContactInfoReturnsFirstName";

            var expectedFirstName = "InsertedFirstName";

            await _seeder.SeedUserAndContactInfo(identity, firstName: expectedFirstName);

            var dto = await _data.FetchAsync<UserContactInfoDTO>(new GetUserContactInfo(identity));

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(expectedFirstName, dto?.FirstName);
        }

        [Fact]
        public async Task GetUserContactInfo_Given_ContactInfoExists_Should_ReturnLastName()
        {
            var identity = "GetExistingContactInfoReturnsLastName";

            var expectedLastName = "InsertedLastName";

            await _seeder.SeedUserAndContactInfo(identity, lastName: expectedLastName);

            var dto = await _data.FetchAsync<UserContactInfoDTO>(new GetUserContactInfo(identity));

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(expectedLastName, dto?.LastName);
        }

        [Fact]
        public async Task GetUserContactInfo_Given_ContactInfoExists_Should_ReturnPreferredName()
        {
            var identity = "GetExistingContactInfoReturnsPreferredName";

            var expectedPreferredName = "InsertedPreferredName";

            await _seeder.SeedUserAndContactInfo(identity, preferredName: expectedPreferredName);

            var dto = await _data.FetchAsync<UserContactInfoDTO>(new GetUserContactInfo(identity));

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(expectedPreferredName, dto?.PreferredName);
        }

        [Fact]
        public async Task GetUserContactInfo_Given_ContactInfoExists_Should_ReturnEmail()
        {
            var identity = "GetExistingContactInfoReturnsPreferredName";

            var expectedEmail = "InsertedEmail";

            await _seeder.SeedUserAndContactInfo(identity, email: expectedEmail);

            var dto = await _data.FetchAsync<UserContactInfoDTO>(new GetUserContactInfo(identity));

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(expectedEmail, dto?.Email);
        }

        #endregion
    }
}
