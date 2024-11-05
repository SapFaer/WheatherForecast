using System.Collections.Generic;

namespace WheatherForecast.Models
{
    public class WeatherForecastModel
    {
        public List<Forecast> List { get; set; } // Список прогнозів

        public class Forecast
        {
            public long Dt { get; set; } // Час
            public Main Main { get; set; } // Основні дані
            public List<Weather> Weather { get; set; } // Опис погоди
        }

        public class Main
        {
            public float Temp { get; set; } // Температура

            public float Humidity { get; set; }
        }

        public class Weather
        {
            public string Description { get; set; } // Опис погоди
        }
    }
}
