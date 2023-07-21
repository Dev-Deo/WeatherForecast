namespace WeatherForecast.Lib.Models
{
    public class WeatherResponse
    {
        public double? Latitude { get;set; }
        public double? Longitude { get;set; }
        public double? Generationtime_ms { get;set; }
        public double? Utc_offset_seconds { get;set; }
        public string? Timezone_abbreviation { get;set; }
        public double? Elevation { get;set; }
        public Weather? Current_weather { get;set; }

    }
}
