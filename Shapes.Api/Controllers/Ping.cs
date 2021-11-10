using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shapes.Api.Services;

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
            var subtraction = new Does.Stuff.With.Logic.Services.Subtraction();
            var result = subtraction.SubtractTwoNumbers(10, 3);
            var multiple = new Does.Stuff.Multiple.Multiple();
            var multipleResult = multiple.MultipleTwoNumbers(10, 3);

            _logger
                .Log(LogLevel.Information, $"Ping controller called with message: {result} and multiple: {multipleResult}");
            _logger
                .Log(LogLevel.Information, "Somehow I managed to get the nuget package building with this project, ha!");

            return Ok($"{message} :: subraction {result} and multiple :: {multipleResult}");
        }
    }
}
