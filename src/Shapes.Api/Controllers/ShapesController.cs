using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shapes.Api.Factory;
using Shapes.Api.Models;
using Shapes.Api.Services;
using Shapes.Api.Services.Shapes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shapes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShapesController : ControllerBase
    {
        private readonly ILogger _logger;
        public ShapesController(ILogger<ShapesController> logger)
        {
            _logger = logger;
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
                _logger.LogInformation($"Trying to calculate area for shape: {shape.GetType().Name} with width: {shape.Width}");

                var area = shape.CalculateArea();

                _logger.Log(LogLevel.Information, $"Area is equal to: {area.ToString(new CultureInfo("en-US"))} for shape: {shape.GetType().Name}");

                response.Add(new ShapeResponse
                {
                    Shape = shape.GetType().Name,
                    Area = area
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
