using System.Reflection;
using client_generator.Deserializer;
using client_generator_tests.Helpers;
using Xunit;
using Moq;

namespace client_generator_tests.Deserializer
{
    public class VersionedDeserializersTest
    {

        [Fact]
        public void RegisterFromAssemblyTest()
        {
            // Arrange 
            var assembly = new Mock<Assembly>();
            var prevState = FakeDeserializer.Construction;
            assembly.Setup(x => x.GetTypes()).Returns(new[]
            {
                typeof(FakeDeserializer)
            });

            // Act
            VersionedDeserializers.RegisterFromAssembly(assembly.Object);

            // Assert
            assembly.Verify(x => x.GetTypes(), Times.Once);
            Assert.Equal(prevState + 1, FakeDeserializer.Construction);
        }

    }
}
