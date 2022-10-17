using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Api.v1.Models;

namespace WeatherForecast.Api.v1.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
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
    public ActionResult<Models.WeatherForecast[]?> Get()
    {
        try
        {
            return Enumerable.Range(1, 5).Select(index => new Models.WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting weather forecast data.");
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = ex.Message,
                Detail = ex.StackTrace,
                Instance = HttpContext.Request.Path
            };
            return BadRequest(problemDetails);
        }
    }
}
