using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherForecast.Models;
using WeatherForecast.Services;
using WeatherForecast.ViewModels;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public HomeController(ILogger<HomeController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(IndexPageViewModel model)
        {
            var result = await _weatherForecastService.GetAll();
            var mappedResult = new List<MyWeatherForecast>();

            mappedResult = result.ToList();

            if (model.SearchTerm != null && model.SearchTerm !="")
            {
                 var searchedResult = result.Where(x => x.Summary.Contains( model.SearchTerm));

                if (searchedResult.Any())
                {
                   mappedResult = searchedResult.ToList();

                }

            }

            var viewResult = mappedResult.Select(x => new MyWeatherForecastViewModel
            {
                Id = x.Id,
                Photo = $"~/img/{x.Summary}.jpg",
                TemperatureC = x.TemperatureC,
                TemperatureF = x.TemperatureF,
                Summary = x.Summary,

            });

            var pageModel = new IndexPageViewModel();
            pageModel.WeatherResults = viewResult;
            
            return View(pageModel);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}