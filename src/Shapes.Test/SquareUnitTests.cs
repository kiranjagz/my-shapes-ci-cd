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

        [Test]
        public void Calculate_Area_Of_Square()
        {
            _squareShape.Height = 2;
            _squareShape.Width = 4;

            double area = _squareShape.CalculateArea();

            Assert.That(area, Is.EqualTo(8));
        }
    }
}