using Moq;

namespace UnitTest.Core
{
    public class GridTests
    {
        private Mock<IRectangleGenerator> _generatorMock;

        public GridTests()
        {
            _generatorMock = new Mock<IRectangleGenerator>();

            _generatorMock.Setup(_ => _.GenerateRectangles(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<Rectangle>()
                {
                    new Rectangle(2, 0, 7, 4),
                    new Rectangle(3, 8, 9, 10),
                    new Rectangle(8, 6, 10, 8),
                    new Rectangle(6, 5, 8, 7),
                    new Rectangle(1, 5, 4, 7),
                    new Rectangle(7, 0, 9, 4)
                });
        }

        [Theory]
        [InlineData(1, 25)]
        [InlineData(5, 26)]
        public void Create_InvalidValid_ThrowException(int width, int height)
        {
            Assert.Throws<ArgumentException>(() => Grid.Create(width, height));
        }

        [Theory]
        [InlineData(5, 25)]
        [InlineData(10, 10)]
        [InlineData(8, 5)]
        public void Create_WithValidParams_ReturnsGrid(int width, int height)
        {
            // Arrange, Act
            var grid = Grid.Create(width, height);

            // Assert
            Assert.Equal(grid.Width, width);
            Assert.Equal(grid.Height, height);
        }

        [Theory]
        [InlineData(7, 1)]
        [InlineData(3, 1)]
        [InlineData(6, 2)]
        [InlineData(9, 10)]
        [InlineData(3, 7)]
        public void Find_WithValidCoordinate_ReturnsRectangle(int x, int y)
        {
            // Arrange
            var grid = Grid
                .Create(10, 10)
                .PlaceRectangles(_generatorMock.Object);

            // Act
            var result = grid.Find(x - 1, y - 1);

            // Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(7, 8)]
        [InlineData(3, 8)]
        [InlineData(6, 5)]
        public void Find_WithInvalidCoordinate_ReturnsNull(int x, int y)
        {
            // Arrange
            var grid = Grid
                .Create(10, 10)
                .PlaceRectangles(_generatorMock.Object);

            // Act
            var result = grid.Find(x - 1, y - 1);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData(5, 3)]
        [InlineData(4, 9)]
        public void Remove_WithValidCoordinate_RemoveAndReturnsRectangle(int x, int y)
        {
            // Arrange
            var grid = Grid
                .Create(10, 10)
                .PlaceRectangles(_generatorMock.Object);

            var currRectangleCount = grid.Rectangles.Count;

            // Act
            var result = grid.Remove(x - 1, y - 1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(currRectangleCount - 1, grid.Rectangles.Count);
        }

        [Theory]
        [InlineData(7, 8)]
        [InlineData(3, 8)]
        [InlineData(6, 5)]
        public void Remove_WithInvalidCoordinate_ReturnsNull(int x, int y)
        {
            // Arrange
            var grid = Grid
                .Create(10, 10)
                .PlaceRectangles(_generatorMock.Object);

            var currRectangleCount = grid.Rectangles.Count;

            // Act
            var result = grid.Remove(x - 1, y - 1);

            // Assert
            Assert.Null(result);
            Assert.Equal(currRectangleCount, grid.Rectangles.Count);
        }
    }
}
