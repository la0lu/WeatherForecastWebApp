using WeatherForecast.Models;
using WeatherForecast.Models.ENUMS;

namespace WeatherForecast.Services
{
    public class WeatherForecastService : BaseService, IWeatherForecastService
    {
       
        public WeatherForecastService(HttpClient client, IConfiguration config) : base(client, config)
        {
          
        }

        public async Task<IEnumerable<MyWeatherForecast>> GetAll()
        {
            var address = "/WeatherForecast/get-all";
            var methodType = ApiVerbs.GET.ToString();

            var result = await MakeRequest<IEnumerable<MyWeatherForecast>, string>(address, methodType, "", "");

            if(result != null)
                return result;

            return new List<MyWeatherForecast>();
        }

        public async Task<bool> AddNewAsync(MyWeatherForecast entity)
        {
            var address = "/WeatherForecast/add";
            var methodType = ApiVerbs.POST.ToString();

            var result = await MakeRequest<IEnumerable<char>, MyWeatherForecast>(address, methodType, entity, "");

            if(result!= null)
                return true;

            return false;
        }
    }
}
