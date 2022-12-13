using LearningPortal.Data.DataRequestObjects.UsersContactInfo;
using System.Data.SqlClient;

namespace LearningPortal.Data.Tests.UserContactInfoTests
{
    public class InsertUserContactInfoTests : BaseDataTest
    {
        #region Identity Is Valid / Null Tests

        [Fact]
        public async Task InsertUserContactInfo_Given_IdentityIsNull_Should_ReturnNegativeOne() =>
            Assert.Equal(-1, await _data.ExecuteAsync(new InsertUserContactInfo(identity: null!, "FirstName", "LastName", "Email")));
       
        [Fact]
        public async Task InsertUserContactInfo_Given_IdentityIsValid_Should_ReturnOne()
        {
            var identity = "InsertContactInfoReturnsOne";
            await _seeder.SeedUser(identity);

            var result = await _data.ExecuteAsync(new InsertUserContactInfo(identity, "FirstName", "LastName", "Email"));

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(1, result);
        }

        #endregion

        #region ContactInfo Already Exists Test

        [Fact]
        public async Task InsertUserContactInfo_Given_ContactInfoAlreadyInserted_Should_ReturnNegativeOne()
        {
            var identity = "UserContactInfoAlreadyExists";
            await _seeder.SeedUser(identity);

            var request = new InsertUserContactInfo(identity, "FirstName", "LastName", "Email");

            await _data.ExecuteAsync(request);

            var resultOnSecondInsert = await _data.ExecuteAsync(request);

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(-1, resultOnSecondInsert);
        }

        #endregion

        #region FirstName Is Valid / Null Tests

        [Fact]
        public async Task InsertUserContactInfo_Given_FirstNameIsValid_Should_InsertValueProvided()
        {
            var firstName = "ExpectedFirstName";
            var identity = "ContactInfoFirstNameInserted";
            await _seeder.SeedUser(identity);

            await _data.ExecuteAsync(new InsertUserContactInfo(identity, firstName, "LastName", email: identity));

            var firstNameInserted = await _fetcher.Fetch<string>("UsersContactInfo", "FirstName", $"Email = '{identity}'");

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(firstName, firstNameInserted);
        }

        [Fact]
        public async Task InsertUserContactInfo_Given_FirstNameIsNull_Should_ThrowSqlException()
        {
            var identity = "InsertContactInfoWithNullFirstName";
            await _seeder.SeedUser(identity);

            var e = await Record.ExceptionAsync(async() => 
                await _data.ExecuteAsync(new InsertUserContactInfo(identity, null!, "LastName", "Email")));

            await _remover.RemoveUserByIdentity(identity);

            Assert.IsType<SqlException>(e);
        }

        #endregion

        #region LastName Is Valid / Null Tests

        [Fact]
        public async Task InsertUserContactInfo_Given_LastNameIsValid_Should_InsertValueProvided()
        {
            var lastName = "ExpectedLastName";
            var identity = "ContactInfoLastNameInserted";
            await _seeder.SeedUser(identity);

            await _data.ExecuteAsync(new InsertUserContactInfo(identity, "FirstName", lastName, email: identity));

            var lastNameInserted = await _fetcher.Fetch<string>("UsersContactInfo", "LastName", $"Email = '{identity}'");

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(lastName, lastNameInserted);
        }

        [Fact]
        public async Task InsertUserContactInfo_Given_LastNameIsNull_Should_ThrowSqlException()
        {
            var identity = "InsertContactInfoWithNullLastName";
            await _seeder.SeedUser(identity);

            var e = await Record.ExceptionAsync(async () =>
                await _data.ExecuteAsync(new InsertUserContactInfo(identity, "FirstName", null!, "Email")));

            await _remover.RemoveUserByIdentity(identity);

            Assert.IsType<SqlException>(e);
        }

        #endregion

        #region Email Is Valid / Null Tests

        [Fact]
        public async Task InsertUserContactInfo_Given_EmailIsValid_Should_InsertValueProvided()
        {
            var email = "ExpectedEmail";
            var identity = "ContactInfoEmailInserted";
            await _seeder.SeedUser(identity);

            await _data.ExecuteAsync(new InsertUserContactInfo(identity, "FirstName", "LastName", email));

            var emailInserted = await _fetcher.Fetch<string>("UsersContactInfo", "Email", $"Email = '{email}'");

            await _remover.RemoveUserAndContactInfoByIdentity(identity);

            Assert.Equal(email, emailInserted);
        }

        [Fact]
        public async Task InsertUserContactInfo_Given_EmailIsNull_Should_ThrowSqlException()
        {
            var identity = "InsertContactInfoWithNullEmail";
            await _seeder.SeedUser(identity);

            var e = await Record.ExceptionAsync(async () =>
                await _data.ExecuteAsync(new InsertUserContactInfo(identity, "FirstName", null!, "Email")));

            await _remover.RemoveUserByIdentity(identity);

            Assert.IsType<SqlException>(e);
        }

        #endregion
    }
}
