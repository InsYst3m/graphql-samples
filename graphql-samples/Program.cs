using Database.Extensions;

using Graphql.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

#region Configure Services

IServiceCollection services = builder.Services;

services.AddDatabaseLayer();
services.AddGraphQLServer(configuration);

#endregion

#region Configure Middleware

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app
	.UseRouting()
	.UseWebSockets();

app.MapGraphQL();

#endregion

app.Run();
