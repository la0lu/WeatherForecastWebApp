using WeatherForecast.Data.Entities;

namespace WeatherForecast.Services
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(AppUser user, string password);

    }
}
