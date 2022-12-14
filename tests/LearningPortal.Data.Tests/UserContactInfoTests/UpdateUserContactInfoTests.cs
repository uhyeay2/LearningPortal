using LearningPortal.Data.DataRequestObjects.UsersContactInfo;

namespace LearningPortal.Data.Tests.UserContactInfoTests
{    
    public class UpdateUserContactInfoTests : BaseDataTest
    {
        [Fact]
        public async Task UpdateUserContactInfo_Given_NoUserExistsWithGuid_Should_ReturnZero() =>
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
    }
}
