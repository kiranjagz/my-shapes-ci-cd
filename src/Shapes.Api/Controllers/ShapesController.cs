using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shapes.Api.Factory;
using Shapes.Api.Models;
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

        // GET: api/<Shapes>/1
        [Route("{width}")]
        [HttpGet]
        public IActionResult Get(int width)
        {
            var shapes = new List<IShape>()
            {
              new SquareModule(),
              new CircleModule()
            };

            var response = new List<ShapeResponse>();

            shapes.ForEach(shape =>
            {
                _logger.LogInformation($"Trying to calculate area for shape: {shape.GetType().Name} with width: {width}");

                var area = shape.CalculateArea(width);

                _logger.Log(LogLevel.Information, $"Area is equal to: {area.ToString(new CultureInfo("en-US"))} for shape: {shape.GetType().Name}");

                response.Add(new ShapeResponse
                {
                    Shape = shape.GetType().Name,
                    Area = area
                });
            });

            return Ok(response);
        }

        // POST: api/<Shapes>
        [HttpPost]
        public IActionResult Post(ShapeRequest shapeRequest)
        {
            var shape = OperatorFactory.ReturnShape(shapeRequest);

            return Ok(new
            {
                shape = shape.GetType().Name,
                area = shape.CalculateArea(shapeRequest.Width),
            });
        }
    }
}
