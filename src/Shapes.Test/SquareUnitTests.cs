using NUnit.Framework;
using Shapes.Api.Services.Shapes;

namespace Shapes.Test
{
    public class SquareUnitTests
    {
        private SquareModule _squareShape;

        [SetUp]
        public void Setup()
        {
            _squareShape = new SquareModule();
        }

        [TestCase(2, 4)]
        [TestCase(3, 9)]
        [TestCase(4, 16)]
        public void Calculate_Area_Of_Square(double width, double result)
        {
            _squareShape.Width = width;

            double area = _squareShape.CalculateArea();

            Assert.That(area, Is.EqualTo(result));
        }

        [TestCase(-2, 4)]
        public void Calculate_Area_Of_Square_Negative_Number(double width, double result)
        {
            _squareShape.Width = width;

            double area = _squareShape.CalculateArea();

            Assert.That(area, Is.EqualTo(result));
        }
    }
}