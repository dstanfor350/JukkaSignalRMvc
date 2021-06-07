using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SignalRMvc.Weather;

namespace SignalRConsoleClient
{
    class Program
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();
        static HubConnection _signalRConnection;
        static IHubProxy _hubProxy;

        static async Task Main()
        {
            HttpResponseMessage response;
            string responseBody;

            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                Console.WriteLine("\n===== Client GetAsync(\"http://localhost:53203/api/values\") =====");
                response = await client.GetAsync("http://localhost:53203/api/values");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);

                Console.WriteLine("\n===== Client GetAsync(\"http://localhost:53203/api/values/1\") =====");
                response = await client.GetAsync("http://localhost:53203/api/values/1");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);

                Console.WriteLine("\n===== Invoke Hub Send method =====");
                await ConnectAsync();
                //HubConnection _signalRConnection = new HubConnection("http://localhost:53203/signalr");
                //IHubProxy _hubProxy = _signalRConnection.CreateHubProxy("SimpleHub");

                //Call the "Send" method on the hub (on the server) with the given parameters
                //await _hubProxy.Invoke("Send", "Hi from the SignlRConsoleClient");

                WeatherForecast weather = new WeatherForecast();
                weather.TemperatureCelsius = 83;
                //weather.Date = DateTime.Now; // (2008, 12, 28);
                weather.Summary = "Partly Cloudy";
                string weatherOut = JsonConvert.SerializeObject(weather);

                // Invoke a hub method
                Console.WriteLine("\n===== Invoke Hub GetWeatherForeast method =====");
                await _hubProxy.Invoke("Send", weather);
   
                Console.WriteLine("\n===== Invoke Hub GetWeatherForeast method =====");
                await _hubProxy.Invoke("GetWeatherForecast", weather);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();

        }

        static private async Task ConnectAsync()
        {
            _signalRConnection = new HubConnection("http://localhost:53203");
            _hubProxy = _signalRConnection.CreateHubProxy("SimpleHub");

            //Register to the "AddMessage" callback method of the hub
            //This method is invoked by the hub
            _hubProxy.On<string>("AddMessage", (message) => Console.WriteLine($"{message}"));

            // Register the OnDisplayWeather method
            Action<WeatherForecast> dw  = OnDisplayWeather;
            _hubProxy.On<WeatherForecast>("OnDisplayWeather", (w) => dw(w));

            // Register the OnDisplayWeather2 method
            // this works!! I wantted to give a delegate function a try as well
            // for the case of a more involved function
            _hubProxy.On<WeatherForecast>("OnDisplayWeather2", w =>
            {
                string wf = JsonConvert.SerializeObject(w);
                Console.WriteLine($"\nWeather2 Forecast is {wf}");
            });

            //Connect to the server
            await _signalRConnection.Start();
        }

        private static void OnDisplayWeather(WeatherForecast weather)
        {
            string wf = JsonConvert.SerializeObject(weather);

            Console.WriteLine($"Today's Weather Forecast is {wf}");
        }
    }
}
