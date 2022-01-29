using Microsoft.AspNetCore.Mvc;
using Shapes.Api.Factory;
using Shapes.Api.Models;
using Shapes.Api.Services;
using Shapes.Api.Services.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shapes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShapesController : ControllerBase
    {
        public ShapesController()
        {

        }

        // GET: api/<Square>/1
        [Route("{width}")]
        [HttpGet]
        public IActionResult Get(int width)
        {
            var shapes = new List<IShape>();
            var response = new List<ShapeResponse>();

            var square = new SquareModule { Width = width };
            var circle = new CircleModule { Width = width };

            shapes.Add(square);
            shapes.Add(circle);

            shapes.ForEach(shape =>
            {
                response.Add(new ShapeResponse
                {
                    Shape = shape.GetType().Name,
                    Area = shape.CalculateArea()
                });
            });

            return Ok(response);
        }

        // POST: api/<Square>
        [HttpPost]
        public IActionResult Post(ShapeRequest shapeRequest)
        {
            var shape = OperatorFactory.ReturnShape(shapeRequest);
            shape.Width = shapeRequest.Width;

            return Ok(new
            {
                shape = shape.GetType().Name,
                area = shape.CalculateArea(),
            });
        }
    }
}
