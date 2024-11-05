using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheatherForecast.Models
{
    public class WeatherModel
    {
        public string Time { get; set; }         // Час прогнозу
        public string Temperature { get; set; }
        public string Humidity { get; set; } // вологість
        public string Description { get; set; }   // Опис погоди
    }

}
