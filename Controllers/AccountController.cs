using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Data.Entities;
using WeatherForecast.Services;
using WeatherForecast.ViewModels;

namespace WeatherForecast.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(IAccountService accountService, UserManager<AppUser> userManager)
        {
            _accountService = accountService;
            _userManager = userManager;
        }

        public UserManager<AppUser> UserManager { get; }

        [HttpGet]
        public IActionResult Login()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    if(await _accountService.LoginAsync(user, model.Password));
                      return View(); 
                }

                ModelState.AddModelError("Login failed", "Invalid credentials");

              
            }

            return View(model);
        }
    }
}
