using Does.Stuff.Multiple;
using Does.Stuff.With.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shapes.Api.Services.Pingy;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shapes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly IPingy _pingy;
        private readonly ILogger _logger;
        public PingController(IPingy pingy, ILogger<PingController> logger)
        {
            _pingy = pingy;
            _logger = logger;
        }
        // GET: api/<Ping>
        [HttpGet]
        public IActionResult Get()
        {
            var numberOne = 30; var numberTwo = 3;
            _logger.LogInformation($"Number One used was: {numberOne} and number two was: {numberTwo}");

            var message = _pingy.Ping();

            var subtraction = new Subtraction();
            var subtractionResult = subtraction.SubtractTwoNumbers(numberOne, numberTwo);
            _logger.LogInformation($"The subtraction result was: {subtractionResult}");

            var multiple = new Multiple();
            var multipleResult = multiple.MultipleTwoNumbers(numberOne, numberTwo);
            _logger.LogInformation($"The multiple result was: {multipleResult}");

            _logger.Log(LogLevel.Information, "Somehow I managed to get the nuget package building with this project, ha!");

            return Ok(new
            {
                message = message,
                subtractionResult = subtractionResult,
                multipleResult = multipleResult,
                dateTime = DateTime.Now.ToString()
            });
        }
    }
}
