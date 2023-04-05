using GraphQL.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq;

namespace GraphQL.Services
{
    public class WeatherService : IWeatherService
    {
        MongoClient _mongoclient;
        public WeatherService(IConfiguration configuration)
        {
            _mongoclient = new MongoClient(configuration.GetConnectionString("mongodb"));
        }

        public bool Create(Weather weather)
        {
            _mongoclient.GetDatabase("dotnetgraphql").GetCollection<Weather>("weather").InsertOne(weather);
            return true;
        }

        public IQueryable<Weather> Get() {
            return _mongoclient.GetDatabase("dotnetgraphql").GetCollection<Weather>("weather").AsQueryable();
        }
    }
}
