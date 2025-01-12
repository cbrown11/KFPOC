
using researchApi.Infrastructure.Adapters;
using simpleEtl.Application;
using simpleEtl.Schema;

var builder = WebApplication.CreateBuilder(args);

//Injecting services.
//builder.Services.RegisterMockServices();
builder.Services.RegisterExtractorServices();
builder.Services.AddApplicationAutoMapperProfiles();
builder.Services.RegisterLoaderServices();

// Dont need graphql but just a api trigger
builder.Services.AddGraphQLServer()
    .ConfigureSchema(sb => sb.ModifyOptions(opts => opts.StrictValidation = false))
    .AddMutationType<Mutation>();

builder.Services.AddCors();

var app = builder.Build();
app.MapGraphQL();
app.Run();
