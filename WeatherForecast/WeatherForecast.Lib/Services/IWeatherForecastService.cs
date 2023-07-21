using WeatherForecast.Lib.Models;

namespace WeatherForecast.Lib.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherResponse> GetCurrentWeather(double cLatitude, double cLongitude);
    }
}
