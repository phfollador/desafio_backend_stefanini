using Example.Application.CitizenService.Service;
using Example.Application.CityService.Service;
using Example.Application.ExampleService.Service;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Example.API.Convertions;
using System.Text.Json.Serialization;
using Example.Domain.CitizenAggregate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddControllers().AddJsonOptions(x =>
//{
//    var converters = x.JsonSerializerOptions.Converters;
//    converters.Add(new JsonStringEnumConverter());
//    //converters.Add(new CpfToJSonConvertion());
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(x =>
//{
//    x.MapType<Cpf> (()=> new OpenApiSchema { Type = "string", Example = new OpenApiString("11111111111") });
//});

builder.Services.AddScoped<IExampleService, ExampleService>();
builder.Services.AddScoped<ICitizenService, CitizenService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddDbContext<ExampleContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ExampleContext>();
    dataContext.Database.Migrate();
}

app.UseAuthorization();

app.MapControllers();

app.Run();