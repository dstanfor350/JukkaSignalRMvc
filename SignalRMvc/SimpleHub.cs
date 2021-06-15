using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalRMvc.Weather;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRMvc
{
    public interface IMyClient
    {
        void AddMessage(string message);
        void OnDisplayWeather(WeatherForecast weather);
        void OnDisplayWeather2(WeatherForecast weather);
    }

    [HubName("SimpleHub")]
    public class SimpleHub : Hub<IMyClient>
    {
        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<SimpleHub>();
 
        public SimpleHub()
        {
            Console.WriteLine();
        }

        public void Send(WeatherForecast weather)
        {
            // Only need the hubContext if outside the Hub class
            //var hubContext = GlobalHost.ConnectionManager.GetHubContext<SimpleHub>();

            string wf = JsonConvert.SerializeObject(weather);
            //hubContext.Clients.All.AddMessage($"Here is the message: {wf}");
            Clients.All.AddMessage($"Here is a message to the client: {wf}");

            Clients.All.OnDisplayWeather(weather);
            Clients.All.OnDisplayWeather2(weather);
        }

        public void GetWeatherForecast(WeatherForecast weather)
        {
            string wf = JsonConvert.SerializeObject(weather);
            Clients.All.OnDisplayWeather(weather);
            Clients.All.OnDisplayWeather2(weather);
        }

    }
}