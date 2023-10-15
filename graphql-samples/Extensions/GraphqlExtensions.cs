using Graphql.Api.Mutations;
using Graphql.Api.Queries;
using Graphql.Api.Subscriptions;

using HotChocolate.AspNetCore;
using HotChocolate.Execution.Configuration;
using HotChocolate.Execution.Options;

namespace Graphql.Api.Extensions
{
	public static class GraphqlExtensions
	{
		public static IServiceCollection AddGraphQL(this IServiceCollection services, IConfiguration configuration)
		{
			services
				.AddGraphQLServer(configuration);

			return services;
		}

		public static IRequestExecutorBuilder AddGraphQLServer(this IServiceCollection services, IConfiguration configuration)
		{
			IRequestExecutorBuilder builder = services
				.AddGraphQLServer()
				.SetRequestOptions(serviceProvider => new RequestExecutorOptions
				{

				})
				.AddQueryType<Query>()
				.AddMutationType<Mutation>()
				.AddSubscriptionType<Subscription>()
				.AddMutationConventions()
				.AddInMemorySubscriptions()
				.InitializeOnStartup();

			return builder;
		}

		public static IEndpointRouteBuilder MapGraphQL(this IEndpointRouteBuilder builder)
		{
			builder.MapGraphQLHttp();
			builder
				.MapBananaCakePop("/ui")
				.WithOptions(new GraphQLToolOptions
				{
					Title = "Graphql service sample",
					UseBrowserUrlAsGraphQLEndpoint = true,
					GraphQLEndpoint = "/graphql"
				});
			builder.MapGraphQLSchema();
			builder.MapGraphQLWebSocket();

			return builder;
		}
	}
}
