namespace WeatherForecast.ViewModels
{
    public class IndexPageViewModel
    {
        public string SearchTerm { get; set; } = string.Empty;
        public IEnumerable<MyWeatherForecastViewModel> WeatherResults { get; set;} = new List<MyWeatherForecastViewModel>();
    }
}
