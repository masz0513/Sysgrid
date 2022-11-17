using Sysgrid.Core;
using Sysgrid.Extensions;

namespace UnitTest.Extensions
{
    public class RectangleExtensionsTests
    {
        [Fact]
        public void IsOverlapWithAny_AGivenRectangleOverlapWithOthers_ReturnTrue()
        {
            // Arrange
            var rect = new Rectangle(0, 0, 5, 5);

            // Act
            var result = rect.IsOverlapWithAny(new List<Rectangle>
            {
                new Rectangle(2, 2, 8, 8),
                new Rectangle(0, 5, 10, 10)
            });

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsOverlapWithAny_AGivenRectangleDoesNotOverlapWithOthers_ReturnFalse()
        {
            // Arrange
            var rect = new Rectangle(0, 0, 5, 5);

            // Act
            var result = rect.IsOverlapWithAny(new List<Rectangle>
            {
                new Rectangle(5, 5, 8, 8),
                new Rectangle(0, 5, 10, 10)
            });

            // Assert
            Assert.False(result);
        }
    }
}
