using DivChecker.Api.Endpoints;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddProblemDetails()
    .AddOutputCache()
    .AddCors(options =>
    {
        options.AddDefaultPolicy(config =>
        {
            //Only for development
            config.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
    })
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
app.UseCors();
app.UseOutputCache();

app.MapDivEndpoints();

app.Run();

