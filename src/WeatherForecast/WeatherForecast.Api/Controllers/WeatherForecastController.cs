using Microsoft.AspNetCore.Mvc;

namespace WeatherForecast.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private static readonly string[] Summaries = new[] {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var weatherForecast = Enumerable.Range(1, 5).Select(index => new Models.WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToArray();

                return Ok(weatherForecast);
            }
            catch (Exception ex)
            {
                var errorTitle = "Error getting weather forecast data.";
                _logger.LogError(ex, errorTitle);
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = errorTitle,
                    Detail = ex.Message,
                    Instance = HttpContext.Request.Path
                };

                return BadRequest(problemDetails);
            }
        }
    }
}