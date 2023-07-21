namespace WeatherForecast.Lib.Models
{
    public class Weather
    {
        public DateTime? Time { get; set; }
        public double? Temperature { get; set; }
        public double? Weathercode { get; set; }
        public double? Is_day { get; set; }
        public double? Windspeed { get; set; }
        public double? Winddirection { get; set; }
    }
}
