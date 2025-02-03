using GameStore.BL.Interfaces;
using GameStore.BL.Services;
using GameStore.DL.Interfaces;
using GameStore.DL.Repositories;
using GameStore.API.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining<GameValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBusinessService, BusinessService>();

builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.UseSerilogRequestLogging();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
