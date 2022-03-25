using Shapes.Api.Models;
using Shapes.Api.Services.Shapes;
using System;

namespace Shapes.Api.Factory
{
    public static class OperatorFactory
    {
        public static IShape ReturnShape(ShapeRequest shapeRequest)
        {
            return shapeRequest.Shape.ToLower() switch
            {
                "square" => new SquareModule(),
                "circle" => new CircleModule(),
                _ => throw new ArgumentException("Could not find a shape."),
            };
        }
    }
}
