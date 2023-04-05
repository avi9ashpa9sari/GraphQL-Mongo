using GraphQL.Models;
using GraphQL.Services;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace GraphQL.Schemas
{
    public class Query
    {
        [UseProjection]
        public IQueryable<Weather> Get([Service] IWeatherService weatherService) => weatherService.Get();

    }
}
