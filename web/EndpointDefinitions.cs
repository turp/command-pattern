
using Models;
using Services;

namespace Web;

public static class EndpointDefinition
{
    public static void DefineEndpoints(this WebApplication app)
    {
        app.MapGet("/weatherforecast", GetWeatherForecast)
            .WithName("GetWeatherForecast")
            .WithOpenApi();

        app.MapPost("/evaluate", EvaluateControls);
    }

    private static WeatherForecast[] GetWeatherForecast()
    {
        var summaries = new[] {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();
        return forecast;
    }

    public static IEnumerable<CommandResult> EvaluateControls(EvaluatorService service, FcrDto dto)
    {
        return service.Evaluate(dto.Controls.ToArray());
    }
}
