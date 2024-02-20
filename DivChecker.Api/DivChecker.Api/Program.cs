using DivChecker.Api.Endpoints;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddProblemDetails()
    .AddOutputCache()
    .Configure<JsonOptions>(options =>
    {
        options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseOutputCache();

app.MapGet("/divs", DivEndpoints.Get)
.WithName("GetDivs")
.WithOpenApi()
.CacheOutput( x=> x.SetVaryByQuery("input1", "input2", "sampleSize"));

app.Run();

