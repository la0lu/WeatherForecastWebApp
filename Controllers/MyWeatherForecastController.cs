using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Models;
using WeatherForecast.Services;
using WeatherForecast.ViewModels;

namespace WeatherForecast.Controllers
{
    public class MyWeatherForecastController : Controller
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public MyWeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        public async Task<IActionResult> AddWeatherforecast(AddNewWeatherForecastViewModel model)
        {
            if(ModelState.IsValid)
            {
                var weatherForecastToAdd = new MyWeatherForecast
                {
                    Date = DateTime.Now,
                    TemperatureC = model.TemperatureC,
                    Summary = model.Summary,
                };

                var result = await _weatherForecastService.AddNewAsync(weatherForecastToAdd);

                return View();
            }

            return View(ModelState);
        }
    }
}
