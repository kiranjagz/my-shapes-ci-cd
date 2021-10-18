using Microsoft.AspNetCore.Mvc;
using Shapes.Api.Models;
using Shapes.Api.Services;
using Shapes.Api.Services.Square;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shapes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Square : ControllerBase
    {
        private readonly SquareModule _squareShape;

        public Square()
        {
            _squareShape = new SquareModule();
        }

        // GET: api/<Square>
        [HttpGet]
        public IActionResult Get()
        {
            _squareShape.Height = 2;
            _squareShape.Width = 4;

            double area = _squareShape.CalculateArea();

            return Ok(area);
        }

        // POST: api/<Square>
        [HttpPost]
        public IActionResult Post(SquareRequest request)
        {
            _squareShape.Height = request.Height;
            _squareShape.Width = request.Width;

            double area = _squareShape.CalculateArea();

            if (area >= 0)
            {
                return Ok(new
                {
                    result = area
                });
            }

            return BadRequest();
        }
    }
}
