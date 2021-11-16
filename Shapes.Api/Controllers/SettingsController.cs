using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Shapes.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shapes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private AppSettings _appSettings;

        public SettingsController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        // GET: api/<SettingsController>
        [HttpGet]
        public IActionResult Get()
        {
            //_configuration.GetSection("AppSettings").Bind(_appSettings);

            return Ok(_appSettings);
        }
    }
}
