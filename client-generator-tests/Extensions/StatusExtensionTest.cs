using System.Linq;
using client_generator.Extensions;
using Xunit;

namespace client_generator_tests.Extensions
{
    public class StatusExtensionTest
    {

        [Fact]
        public void SuccessfulStatus()
        {
            // Arrange
            var status = new[] {200, 250, 280, 290, 300, 399};

            // Act
            var wasSuccessfully = status.Select(x => x.WasSuccessful()).ToList();

            // Assert
            Assert.True(wasSuccessfully.All(x => x), "All should be successful.");
        }

        [Fact]
        public void UnsuccessfulStatus()
        {
            // Arrange
            var status = new[] {400, 412, 100, 501, 520};

            // Act
            var wasSuccessfully = status.Select(x => x.WasSuccessful()).ToList();

            // Assert
            Assert.True(wasSuccessfully.All(x => !x), "All should be unsuccessful.");
        }

    }
}
