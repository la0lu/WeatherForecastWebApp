


using Microsoft.AspNetCore.Identity;
using WeatherForecast.Data.Entities;

namespace WeatherForecast.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> LoginAsync(AppUser user, string password)
        {
            var loginResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if(loginResult.Succeeded)
                return true;
            return false;
        }
    }
}
