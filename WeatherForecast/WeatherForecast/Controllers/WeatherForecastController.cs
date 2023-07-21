using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using WeatherForecast.Lib.Models;
using WeatherForecast.Lib.Services;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IWeatherForecastService weatherForecastService,
            IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet(Name = "GetCurrentWeather")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetCurrentWeather(string cCity)
        {
            try
            {
                double tmpLatitude = 0;
                double tmpLongitude = 0;
                List<Address> tmpAddressList = new List<Address>(); 

                string tmpDirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string tmpFilePath = tmpDirectoryPath + @"/Data/addressData.json";

                using (StreamReader reader = new StreamReader(tmpFilePath))
                {
                    string tmpJson = reader.ReadToEnd();
                    tmpAddressList = JsonConvert.DeserializeObject<List<Address>>(tmpJson);
                }

                if (tmpAddressList.Count > 0)
                {
                    var curCity =  tmpAddressList.Where(a => a.City.ToLower() == cCity.ToLower()).FirstOrDefault();
                    if (curCity != null)
                    {
                        tmpLatitude = curCity.Lat ?? 0;
                        tmpLongitude = curCity.Lng ?? 0;
                    }

                }

                var curWeather = await _weatherForecastService.GetCurrentWeather(tmpLatitude, tmpLongitude);
                if (curWeather is null) return BadRequest("Failed to get weather information.");
                return Ok(curWeather);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}