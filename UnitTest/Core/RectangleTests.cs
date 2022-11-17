namespace UnitTest.Core
{
    public class RectangleTests
    {
        [Fact]
        public void DataPoints_GivenAValidRectangle_ReturnAllDataPoints()
        {
            // Arrange
            var rect = new Rectangle(2, 2, 4, 5);

            // Act
            var dataPoints = rect.DataPoints;

            // Assert
            var expected = new List<(int x, int y)>
            {
                (2, 2), (2, 3), (2, 4),
                (3, 2), (3, 3), (3, 4)
            };

            Assert.Equal(expected, dataPoints);
        }
    }
}
