using System.Collections.Generic;
using client_generator.Extensions;
using Xunit;

namespace client_generator_tests.Extensions
{
    public class EnumerableExtensionTest
    {

        [Fact]
        public void AddToEnumerable()
        {
            // Arrange
            var list = new List<int>
            {
                1,2,3,4
            };
            var element = 10;
            
            // Act
            var withElement = EnumerableExtension.Add(list, element);

            // Assert 
            Assert.Contains(element, withElement);
        }
        
        
        [Fact]
        public void StrJoin()
        {
            // Arrange
            var list = new List<string>
            {
                "1","2","3"
            };
            var separator = "";
            
            // Act
            var joined = EnumerableExtension.StrJoin(list, separator);

            // Assert 
            var correct = string.Join(separator, list);
            Assert.Equal(correct, joined);
        }

    }
}
