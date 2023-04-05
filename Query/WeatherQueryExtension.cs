using GraphQL.Constants;
using GraphQL.Resolvers;
using HotChocolate.Types;

namespace GraphQL.Query
{

    public class WeatherQueryExtension : ObjectTypeExtension
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name(GraphQLConstant.Query);
            descriptor.Field("GetName")
                .ResolveWith<WeatherResolver>(r => r.GetName())
                .Type<StringType>();
            descriptor.Field("GetWeather")
                .ResolveWith<WeatherResolver>(r => r.GetWeather(default));
        }

    }

}
