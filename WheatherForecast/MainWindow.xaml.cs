using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using WheatherForecast.Controllers;
using WheatherForecast.Models;

namespace WheatherForecast
{
    public partial class MainWindow : Window
    {
        private WeatherController controller;
        public ObservableCollection<WeatherModel> WeatherForecasts { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            controller = new WeatherController(this);
            WeatherForecasts = new ObservableCollection<WeatherModel>();
            WeatherDataGrid.ItemsSource = WeatherForecasts; // Прив'язка даних до DataGrid

            // Автоматичне отримання погоди для Києва при запуску програми
            LoadWeatherForecast();
        }

        private async void LoadWeatherForecast()
        {
            await controller.GetWeatherForecast(); // Завантажуємо прогноз погоди
        }

        public void DisplayForecast(WeatherForecastModel forecast)
        {
            WeatherForecasts.Clear(); // Очищення старих даних
            foreach (var weather in forecast.List)
            {
                var time = DateTimeOffset.FromUnixTimeSeconds(weather.Dt).DateTime.ToLocalTime();
                var temperature = weather.Main.Temp;
                var description = weather.Weather[0].Description;
                var humidity = weather.Main.Humidity;
                var formattedDate = time.ToString("ddd d MMMM HH:mm", new CultureInfo("uk-UA"));
                WeatherForecasts.Add(new WeatherModel
                {
                    Time = formattedDate,
                    Temperature = temperature.ToString(),
                    Description = description,
                    Humidity = humidity.ToString()
                }); 
            }
        }

        public void ShowError(string message)
        {
            WeatherForecasts.Clear(); // Очищення таблиці при помилці
            WeatherForecasts.Add(new WeatherModel { Time = "Помилка", Temperature = "", Description = message });
        }
    }
}
