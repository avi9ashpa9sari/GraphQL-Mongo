using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace GraphQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
 
        MongoClient _mongoclient;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _mongoclient = new MongoClient(configuration.GetConnectionString("mongodb"));
        }

        [HttpGet]
        public IEnumerable<Weather> Get()
        {
            try
            {
                var db = _mongoclient.GetDatabase("dotnetgraphql").GetCollection<Weather>("weather").AsQueryable();
                return db;
            }
            catch (Exception ex)
            {

                throw ex;
            }
 
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
        [HttpPost]
        public JsonResult Post(Weather weather)
        {
            try
            {

                var rng = new Random();
                //var data = Enumerable.Range(1, 5).Select(index => new Weather
                //{
                //    Date = DateTime.Now.AddDays(index),
                //    TemperatureC = rng.Next(-20, 55),
                //    Summary = Summaries[rng.Next(Summaries.Length)]
                //}).ToList();
                _mongoclient.GetDatabase("dotnetgraphql").GetCollection<Weather>("weather").InsertOne(weather);
                return new JsonResult("added successfully");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
