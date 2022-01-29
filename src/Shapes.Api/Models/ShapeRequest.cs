using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Models
{
    public class ShapeRequest
    {
        public string Shape { get; set; }
        public double Width { get; set; }
    }
}
