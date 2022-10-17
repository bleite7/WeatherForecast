using Microsoft.Extensions.Logging;
using Moq;
using WeatherForecast.Api.v1.Controllers;

namespace WeatherForecast.Api.Tests;
public class WeatherForecastControllerTests
{
    [Fact]
    public void Get_ReturnsForecastArrayOf5Items()
    {
        // Arrange
        WeatherForecastController controller = new();

        // Act
        var result = controller.Get();

        // Assert
        Assert.IsType<v1.Models.WeatherForecast[]?>(result?.Value);
        var forecastArray = result?.Value;
        Assert.Equal(5, forecastArray?.Length);
    }
}