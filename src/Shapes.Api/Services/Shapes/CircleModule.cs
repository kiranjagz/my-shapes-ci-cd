using System;

namespace Shapes.Api.Services.Shapes
{
    public class CircleModule : IShape
    {
        public double Width { get; set; }

        public double CalculateArea()
        {
            return Math.PI * (Width / 2) * (Width / 2);
        }
    }
}
