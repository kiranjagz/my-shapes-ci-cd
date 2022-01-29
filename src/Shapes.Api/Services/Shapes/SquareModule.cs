using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Services.Shapes
{
    public class SquareModule : IShape
    {
        public double Width { get; set; }

        public double CalculateArea()
        {
            return Width * Width;
        }
    }
}
