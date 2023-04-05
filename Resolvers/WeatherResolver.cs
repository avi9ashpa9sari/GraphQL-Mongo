using GraphQL.Models;
using GraphQL.Services;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Resolvers
{
    public class WeatherResolver : ObjectTypeExtension
    {
        [UseProjection]
        public IQueryable<Weather> GetWeather([Service] IWeatherService _weatherService)
        {
            return _weatherService.Get();
        }
        /// <summary>
        /// Add weather record into database
        /// </summary>
        /// <param name="_weatherService"></param>
        /// <param name="weatherInput"></param>
        /// <returns>weatherInput</returns>
        public Weather AddWeather([Service] IWeatherService _weatherService,Weather weatherInput)
        {
            _weatherService.Create(weatherInput);
            return weatherInput;
        }

        public string GetName()
        {
            return "Shailendra Yadav";
        }
    }
}
