using researchApi.Infrastructure.Adapters;
using researchApi.Schema;

var builder = WebApplication.CreateBuilder(args);

//Injecting services.
//builder.Services.RegisterMockServices();
builder.Services.RegisterServices();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
