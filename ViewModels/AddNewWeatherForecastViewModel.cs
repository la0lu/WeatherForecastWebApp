using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.ViewModels
{
    public class AddNewWeatherForecastViewModel
    {
        [Required]
        public string  Summary { get; set; }= string.Empty;
        [Required]
        public int TemperatureC { get; set; }
    }
}
