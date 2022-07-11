using AutoMapper;
using Microsoft.OpenApi.Models;
using OrderManagment.API.Mapper;
using OrderManagment.API.Middleware;
using OrderManagment.Repository;
using OrderManagment.Services;
using OrderManagment.Services.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var config = new MapperConfiguration(config => 
{
    config.AddProfile(new MappingProfile());
    config.AddProfile(new ServiceMapperProfile());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddOrderManagmentRepository(builder.Configuration);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Order Managment APIs", Version = "v1" });
    c.SchemaFilter<SwaggerSchemaFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Managment APIs v1");
    });
}

// add middleware to process exceptions automatically
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
