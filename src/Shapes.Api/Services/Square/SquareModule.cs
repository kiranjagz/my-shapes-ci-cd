using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Services.Square
{
    public class SquareModule : IShape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public SquareModule()
        {

        }

        public SquareModule(double Height, double Width)
        {
            this.Height = Height;
            this.Width = Width;
        }

        public double CalculateArea()
        {
            return Height * Width;
        }
    }
}
