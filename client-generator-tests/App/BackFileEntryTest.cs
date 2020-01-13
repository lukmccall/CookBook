using System.Collections.Generic;
using System.IO;
using System.Linq;
using client_generator.App;
using Xunit;

namespace client_generator_tests.App
{
    public class BackFileEntryTest
    {

        [Fact]
        public void CorrectPath()
        {
            // Arrange
            var paths = new List<string>
            {
                "/path/a/b",
                "/a/b/c/d",
                "/a/b/c/d/../t/s",
            };

            // Act
            var backPaths = paths.Select(x => new BackFileEntry(x).ParentDirectory);

            // Arrange
            Assert.Equal(paths.Select(x => Directory.GetParent(x).FullName), backPaths);
        }

        [Fact]
        public void SlashPath()
        {
            // Arrange
            var paths = new List<string>
            {
                "/",
                "//"
            };

            // Act
            var backPaths = paths.Select(x => new BackFileEntry(x).ParentDirectory);

            // Arrange
            Assert.Equal(paths.Select(x => x), backPaths);
        }

    }
}
