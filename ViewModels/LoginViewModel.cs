using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }
        
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
    }
}
