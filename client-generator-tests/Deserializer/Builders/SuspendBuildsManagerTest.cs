using System.Collections.Generic;
using System.Linq;
using client_generator.Deserializer.Helpers.Builders;
using client_generator_tests.Helpers;
using Xunit;

namespace client_generator_tests.Deserializer.Builders
{
    public class SuspendBuildsManagerTest
    {

        [Fact]
        public void SimpleBuild()
        {
            // Arrange
            var builds = new Dictionary<string, BuildableObject>
            {
                {"1", new BuildableObject {Id = "1", RequiredIds = new string[0]}}
            };
            var builder = new SuspendBuildsManager<BuildableObject, string>(builds, BuildableObject.BuildMethod);

            // Act
            var resultStatus = builder.Build();
            var result = builder.GetResult();

            // Assert
            Assert.True(resultStatus, "Build should be possible");
            Assert.Single(result.Values);
            Assert.Equal("1", result["1"]);
        }

        [Fact]
        public void MultiTaskBuild()
        {
            // Arrange
            var builds = new Dictionary<string, BuildableObject>
            {
                {"1", new BuildableObject {Id = "a", RequiredIds = new string[0]}},
                {"2", new BuildableObject {Id = "b", RequiredIds = new string[0]}},
                {"3", new BuildableObject {Id = "c", RequiredIds = new string[0]}}
            };
            var builder = new SuspendBuildsManager<BuildableObject, string>(builds, BuildableObject.BuildMethod);

            // Act
            var resultStatus = builder.Build();
            var result = builder.GetResult();

            // Assert
            Assert.True(resultStatus, "Build should be possible");
            Assert.Equal(builds.Keys.Count, result.Keys.Count);
            Assert.Equal(builds.Select(x => x.Value.Id), result.Select(x => x.Value));
        }

        [Fact]
        public void MultiDependentTaskBuild()
        {
            // Arrange
            var builds = new Dictionary<string, BuildableObject>
            {
                {"1", new BuildableObject {Id = "a", RequiredIds = new[] {"2"}}},
                {"2", new BuildableObject {Id = "b", RequiredIds = new string[0]}},
                {"3", new BuildableObject {Id = "c", RequiredIds = new[] {"4"}}},
                {"4", new BuildableObject {Id = "d", RequiredIds = new string[0]}},
                {"5", new BuildableObject {Id = "e", RequiredIds = new[] {"4"}}}
            };
            var builder = new SuspendBuildsManager<BuildableObject, string>(builds, BuildableObject.BuildMethod);

            // Act
            var resultStatus = builder.Build();
            var result = builder.GetResult();

            // Assert
            Assert.True(resultStatus, "Build should be possible");
            Assert.Equal(builds.Keys.Count, result.Keys.Count);
            Assert.Equal(builds.Select(x => x.Value.Id).OrderBy(x => x),
                result.Select(x => x.Value).OrderBy(x => x));
        }
        
        
        [Fact]
        public void ImpossibleBuild()
        {
            // Arrange
            var builds = new Dictionary<string, BuildableObject>
            {
                {"1", new BuildableObject {Id = "a", RequiredIds = new[] {"2"}}},
                {"2", new BuildableObject {Id = "b", RequiredIds = new[] {"2"}}},
                {"3", new BuildableObject {Id = "c", RequiredIds = new[] {"4"}}},
                {"4", new BuildableObject {Id = "d", RequiredIds = new string[0]}},
                {"5", new BuildableObject {Id = "e", RequiredIds = new[] {"4"}}}
            };
            var builder = new SuspendBuildsManager<BuildableObject, string>(builds, BuildableObject.BuildMethod);

            // Act
            var resultStatus = builder.Build();
            var result = builder.GetResult();

            // Assert
            Assert.False(resultStatus, "Build should be possible");
            Assert.Equal(3, result.Keys.Count);
        }

    }
}
