using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<MyWeatherForecast>> GetAll();

        Task<bool> AddNewAsync(MyWeatherForecast entity);
    }
}
