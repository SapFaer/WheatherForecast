using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WheatherForecast.Models;

namespace WheatherForecast.Services
{
    public class WeatherService
    {
        private readonly string apiKey = "f86a19bd06ba648ea206805e1aa2aa83"; // API-ключ
        private readonly HttpClient httpClient;

        public WeatherService()
        {
            httpClient = new HttpClient();
        }

        // метод, що приймає широту та довготу
        public async Task<WeatherForecastModel> GetWeatherForecast(double latitude, double longitude)
        {
            var url = $"https://api.openweathermap.org/data/2.5/forecast?lat={latitude}&lon={longitude}&appid={apiKey}&units=metric&lang=uk";
            var response = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<WeatherForecastModel>(response);
        }
    }
}
