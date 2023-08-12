namespace WeatherForecast.ViewModels
{
    public class MyWeatherForecastViewModel
    {
        public int Id { get; set; }
        public string Photo { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public string? Summary { get; set; }
    }
}
