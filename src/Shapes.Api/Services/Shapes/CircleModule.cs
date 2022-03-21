using System;

namespace Shapes.Api.Services.Shapes
{
    public class CircleModule : IShape
    {

        public double CalculateArea(double width)
        {
            return Math.PI * (width / 2) * (width / 2);
        }
    }
}
