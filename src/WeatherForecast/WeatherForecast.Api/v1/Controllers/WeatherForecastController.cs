using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Api.v1.Models;

namespace WeatherForecast.Api.v1.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class WeatherForecastController : ControllerBase
{
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

    [HttpGet]
    public ActionResult<Models.WeatherForecast[]?> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Models.WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();
    }
}
