using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRMvc.Weather
{
    public class WeatherForecast
    {
        //public DateTime Date { get; set; }
        public int TemperatureCelsius { get; set; }
        //private string _Summary;
        //public string Summary { get; set; }
        public string Summary { get; set; }
        //{ 
        //    get => _Summary;
        //    set { _Summary = value; }
        //}
    }
}
