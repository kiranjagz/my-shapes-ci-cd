using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Services
{
    public interface IShape
    {
        double Width { get; set; }
        double CalculateArea();
    }
}
