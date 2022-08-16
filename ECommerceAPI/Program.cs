using Application;
using Application.Commands;
using ECommerceAPI;
using MediatR;
using Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositories();
builder.Services.AddCommandHandlers();
builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<ConfigureModelMaps>();
    cfg.AddProfile<ConfigureRequestMaps>();
});
builder.Services.AddSingleton<AuthenticationProvider>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
