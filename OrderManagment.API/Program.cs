using AutoMapper;
using OrderManagment.API.Mapper;
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
builder.Services.AddOrderManagmentRepository(builder.Configuration);
builder.Services.AddOrderManagmentServices(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
