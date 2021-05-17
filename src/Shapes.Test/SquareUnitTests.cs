using NUnit.Framework;
using Shapes.Api.Services.Square;

namespace Shapes.Test
{
    public class Tests
    {
        private SquareModule _squareShape;

        [SetUp]
        public void Setup()
        {
            _squareShape = new SquareModule();
        }

        [TestCase(2, 2, 4)]
        [TestCase(2, 3, 6)]
        [TestCase(10, 4, 40)]
        [TestCase(4, 4, 16)]
        public void Calculate_Area_Of_Square(double height, double width, double result)
        {
            _squareShape.Height = height;
            _squareShape.Width = width;

            double area = _squareShape.CalculateArea();

            Assert.That(area, Is.EqualTo(result));
        }
    }
}