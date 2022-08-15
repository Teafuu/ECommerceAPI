using System.Reflection;
using System.Xml.Xsl;
using Application;
using Application.Commands;
using AutoMapper;
using ECommerceAPI;
using Repositories;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositories();
builder.Services.AddCommandHandlers();
builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<ConfigureModelMaps>();
    cfg.AddProfile<ConfigureRequestMaps>();
});
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
