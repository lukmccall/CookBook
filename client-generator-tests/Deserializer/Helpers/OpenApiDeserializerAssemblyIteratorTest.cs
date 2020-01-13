using System;
using System.Collections.Generic;
using System.Linq;
using client_generator.Deserializer.Helpers;
using client_generator_tests.Helpers;
using Xunit;

namespace client_generator_tests.Deserializer.Helpers
{
    public class OpenApiDeserializerAssemblyIteratorTest
    {

        [Fact]
        public void ReturnsCorrectTypes()
        {
            // Arrange 
            var typesArray = new[]
            {
                typeof(string),
                typeof(FakeDeserializer),
                typeof(char),
                typeof(FakeDeserializer)
            };
            var iterator = new OpenApiDeserializerAssemblyIterator(typesArray);

            // Act
            var counter = typesArray.Count(type => type == typeof(FakeDeserializer));
            var getTypes = new List<Type>();
            while (iterator.MoveNext())
            {
                getTypes.Add(iterator.Current);
                counter--;
            }

            // Assert
            Assert.Equal(0, counter);
            Assert.True(getTypes.All(type => type == typeof(FakeDeserializer)), "Iterator returns incorrect type.");
        }

        [Fact]
        public void ReturnsNothingOnEmptyCollection()
        {
            // Arrange
            var typeArray = new Type[0];
            
            // Act
            var iterator = new OpenApiDeserializerAssemblyIterator(typeArray);
            
            // Assert
            Assert.False(iterator.MoveNext(), "Collection should be empty");
        }

        
        [Fact]
        public void ReturnsNothingOnNullCollection()
        {
            // Act
            var iterator = new OpenApiDeserializerAssemblyIterator(null);
            
            // Assert
            Assert.False(iterator.MoveNext(), "Collection should be empty");
        }
    }
}
