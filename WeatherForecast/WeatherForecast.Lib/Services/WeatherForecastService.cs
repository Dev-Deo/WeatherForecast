using Newtonsoft.Json;
using WeatherForecast.Lib.Models;

namespace WeatherForecast.Lib.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {

        public async Task<WeatherResponse> GetCurrentWeather(double cLatitude, double cLongitude)
        {
            using (HttpClient client = new HttpClient())
            {
                var tmpUrl = new Uri($"https://api.open-meteo.com/v1/forecast?latitude={cLatitude}&longitude={cLongitude}&current_weather=true");

                var curResponse = await client.GetAsync(tmpUrl);

                string tmpJson;
                using (var content = curResponse.Content)
                {
                    tmpJson = await content.ReadAsStringAsync();
                }

                return JsonConvert.DeserializeObject<WeatherResponse>(tmpJson);
            }
        }
    }
}
