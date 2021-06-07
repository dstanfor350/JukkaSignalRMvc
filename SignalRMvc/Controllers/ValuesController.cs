using SignalRMvc.Models;
using SignalRMvc.Weather;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SignalRMvc.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        // GET api/values
        [Route("")]
        [HttpGet]
        //public IEnumerable<string> Get()
        public IHttpActionResult GetValues()
        {
            return Ok(new string[] { "Get", "value1", "value2" });
        }

        // GET api/values/5
        //[Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            return Ok(id);
        }

        //[HttpPost]
        //public IHttpActionResult Post()
        //{
        //    string body = Request.Content.ReadAsStringAsync().Result;
        //    return Ok(new string[] { "Post", "value1", "value2" });
        //}

        // POST api/values
        //[Route("{name}")]
        //[HttpPost]
        ////public IHttpActionResult Post([FromBody]  string name)
        ////public IHttpActionResult Post(string name)
        [HttpPost]
        [Route()]
        //public IHttpActionResult Post([FromBody] WeatherForecast weather)
        //public IHttpActionResult Post([FromBody] JsonName name)
        public IHttpActionResult Post([FromBody] WeatherForecast weather)
        {
            // https://stackoverflow.com/questions/13284460/asp-net-webapi-not-receiving-post-data
            //string body = Request.Content.ReadAsStringAsync().Result;
            //var body = Request.Content.ReadAsStringAsync().Result;

            //return Ok(new string[] { "Post", "value1", "value2" });
            return Ok(weather);
        }

        [HttpPost]
        //[Route("weather")]
        //[ActionName("Weather")]
        public IHttpActionResult PostWeather([FromBody] WeatherForecast weather)
        {
            // This will read the contents of the HTTP Body
            // https://stackoverflow.com/questions/13284460/asp-net-webapi-not-receiving-post-data
            //string body = Request.Content.ReadAsStringAsync().Result;
            //var body = Request.Content.ReadAsStringAsync().Result;

            return Ok(weather);
        }

        ////[Route("{id:string}")]
        //[HttpPost]
        //public IHttpActionResult PostId([FromBody] string name)
        //{
        //    return Ok(new string[] { "Post" + name });
        //}

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
