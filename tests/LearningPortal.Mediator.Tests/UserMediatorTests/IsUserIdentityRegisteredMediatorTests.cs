using LearningPortal.Data.DataRequestObjects.UserRequests;
using LearningPortal.Mediator.Mediators.UserMediators;

namespace LearningPortal.Mediator.Tests.UserMediatorTests
{
    public class IsUserIdentityRegisteredMediatorTests : DataMediatorTest
    {
        private readonly IsUserIdentityRegisteredMediator _mediator;

        public IsUserIdentityRegisteredMediatorTests()
        {
            _mediator = new(_mockData.Object);
        }

        [Fact]
        public async Task IsUserIdentityRegistered_Given_DataReturnsTrue_Should_ReturnTrue()
        {
            _mockData.Setup(_ => _.FetchAsync<bool>(It.IsAny<IsUserIdentityRegistered>())).Returns(() => Task.FromResult(true));

            var result = await _mediator.Handle(new IsUserIdentityRegisteredRequest("ReturnsTrue"), cancellationToken: default);

            Assert.True(result.ContentAs<bool>());
        }

        [Fact]
        public async Task IsUserIdentityRegistered_Given_DataReturnsFalse_Should_ReturnFalse()
        {
            _mockData.Setup(_ => _.FetchAsync<bool>(It.IsAny<IsUserIdentityRegistered>())).Returns(() => Task.FromResult(false));

            var result = await _mediator.Handle(new IsUserIdentityRegisteredRequest("ReturnsFalse"), cancellationToken: default);

            Assert.False(result.ContentAs<bool>());
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public async Task IsUserIdentityRegistered_Given_IdentityIsInvalid_Should_ReturnStatusCode_BadRequest400(string identity)
        {
            var result = await _mediator.Handle(new IsUserIdentityRegisteredRequest(identity), cancellationToken: default);

            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}
