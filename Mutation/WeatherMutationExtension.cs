using GraphQL.Constants;
using GraphQL.Resolvers;
using GraphQL.Schemas;
using HotChocolate.Types;

namespace GraphQL.Mutation
{
    public class WeatherMutationExtension: WeatherResolver
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name(GraphQLConstant.Mutation);
            descriptor.Field("CreateWeather")
                .ResolveWith<WeatherResolver>(r => r.AddWeather(default,default))
                .Argument("weatherInput", p=>p.Type<WeatherInput>());
        }
    }
}
