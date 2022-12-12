using LearningPortal.Data.Abstractions.Interfaces;

namespace LearningPortal.Mediator.Tests._MediatorTestingObjects
{
    public abstract class DataMediatorTest
    {
        protected readonly Mock<IDataConnection> _mockData;

        public DataMediatorTest()
        {
            _mockData = new Mock<IDataConnection>();
        }
    }
}
