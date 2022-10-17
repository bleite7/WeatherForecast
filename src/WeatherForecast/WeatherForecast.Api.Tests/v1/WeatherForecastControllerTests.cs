using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Reflection;
using WeatherForecast.Api.v1.Controllers;

namespace WeatherForecast.Api.Tests;
public class WeatherForecastControllerTests
{
    [Fact]
    public void Get_ReturnsForecastArrayOf5Items()
    {
        // Arrange
        var loggerStub = new Mock<ILogger<WeatherForecastController>>();
        var controller = new WeatherForecastController(loggerStub.Object);

        // Act
        var result = controller.Get();

        // Assert
        Assert.IsType<v1.Models.WeatherForecast[]?>(result.Value);
        var forecastArray = result?.Value;
        Assert.Equal(5, forecastArray?.Length);
    }
}