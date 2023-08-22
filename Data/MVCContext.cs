using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.Data.Entities;

namespace WeatherForecast.Data
{
    public class MVCContext : IdentityDbContext
    {
        public MVCContext(DbContextOptions<MVCContext> options) : base(options)
        {

        }

        
    }
}
