using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shapes.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shapes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ping : ControllerBase
    {
        private readonly IPingy _pingy;
        private readonly ILogger _logger;
        public Ping(IPingy pingy, ILogger<Ping> logger)
        {
            _pingy = pingy;
            _logger = logger;
        }
        // GET: api/<Ping>
        [HttpGet]
        public IActionResult Get()
        {
            var message = _pingy.Ping();

            _logger.Log(LogLevel.Information, $"Ping controller called with message: {message}");

            return Ok(message);
        }
    }
}
