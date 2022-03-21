using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Services
{
    public interface IShape
    {
        double CalculateArea(double width);
    }
}
