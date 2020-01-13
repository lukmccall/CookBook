using System;
using System.Collections.Generic;
using System.Text;
using client_generator.Extensions;
using Xunit;

namespace client_generator_tests.Extensions
{
    public class StringBuilderExtensionTest
    {

        [Fact]
        public void AppendLines()
        {
            // Arrange 
            var lines = new List<string>
            {
                "a","b","c"
            };
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.AppendLines(lines);
            var result = stringBuilder.ToString();

            // Assert
            Assert.Equal($"{string.Join(Environment.NewLine, lines)}{Environment.NewLine}", result);
        }

    }
}
