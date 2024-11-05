using System;
using System.Threading.Tasks;
using WheatherForecast.Models;
using WheatherForecast.Services;

namespace WheatherForecast.Controllers
{
    public class WeatherController
    {
        private readonly MainWindow view;
        private readonly WeatherService weatherService;

        public WeatherController(MainWindow view)
        {
            this.view = view;
            weatherService = new WeatherService();
        }

        // Використання фіксованих координат Києва
        public async Task GetWeatherForecast()
        {
            double latitude = 50.4501;  // Широта Києва
            double longitude = 30.5234;  // Довгота Києва

            try
            {
                var forecast = await weatherService.GetWeatherForecast(latitude, longitude);
                view.DisplayForecast(forecast);
            }
            catch (Exception ex)
            {
                view.ShowError(ex.Message);
            }
        }
    }
}
