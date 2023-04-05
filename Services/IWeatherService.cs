using GraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Services
{
    public interface IWeatherService
    {
        IQueryable<Weather> Get();
        bool Create(Weather weather);
    }
}
