using LearningPortal.Data.DataRequestObjects.UserRequests;
using LearningPortal.Mediator.Mediators.UserMediators;

namespace LearningPortal.Mediator.Tests.UserMediatorTests
{
    public class InsertUserMediatorTests : DataMediatorTest
    {
        private readonly InsertUserMediator _mediator;

        public InsertUserMediatorTests()
        {
            _mediator = new(_mockData.Object);
        }

        [Fact]
        public async Task InsertUser_Given_IdentityIsNotAlreadyRegistered_Should_ReturnStatusCode_OK200()
        {
            _mockData.Setup(_ => _.FetchAsync<bool>(It.IsAny<IsUserIdentityRegistered>())).Returns(Task.FromResult(false));

            var result = await _mediator.Handle(new InsertUserRequest("IdentityNotRegistered"), cancellationToken: default);

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }
        
        [Fact]
        public async Task InsertUser_Given_IdentityIsAlreadyRegistered_Should_ReturnStatusCode_Conflict409()
        {
            _mockData.Setup(_ => _.FetchAsync<bool>(It.IsAny<IsUserIdentityRegistered>())).Returns(Task.FromResult(true));

            var result = await _mediator.Handle(new InsertUserRequest("IdentityIsRegistered"), cancellationToken: default);

            Assert.Equal((int)HttpStatusCode.Conflict, result.StatusCode);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public async Task InsertUser_Given_IdentityIsInvalid_Should_ReturnStatusCode_BadRequest400(string identity)
        {
            var result = await _mediator.Handle(new InsertUserRequest(identity), cancellationToken: default);

            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}
