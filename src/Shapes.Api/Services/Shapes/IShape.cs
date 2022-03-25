using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Services.Shapes
{
    public interface IShape
    {
        double CalculateArea(double width);
    }
}
