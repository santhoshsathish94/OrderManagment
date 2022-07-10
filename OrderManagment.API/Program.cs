using AutoMapper;
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
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// add middleware to process exceptions automatically
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
