using HotChocolate.AspNetCore.Voyager;
using researchApi.Application;
using researchApi.Infrastructure.Adapters;
using researchApi.Schema;

var builder = WebApplication.CreateBuilder(args);

//Injecting services.
//builder.Services.RegisterMockServices();
builder.Services.RegisterServices();

builder.Services.AddApplicationAutoMapperProfiles();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

builder.Services.AddCors();

var app = builder.Build();


app.MapGraphQL();
app.UseGraphQLVoyager();

app.Run();
