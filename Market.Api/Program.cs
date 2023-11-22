using Market.Data.Concrete.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NuGet.ProjectModel;
using Market.Api.Extensions;
using Market.Api.Error;

var builder = WebApplication.CreateBuilder(args);

Log.Logger=new LoggerConfiguration().MinimumLevel.Debug().WriteTo
    .File("LogFile\\log.txt",rollingInterval:RollingInterval.Day)
    .CreateLogger();

builder.Services.AddControllers();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddSingleton<ILogging, Logging>(ILogging);
builder.Services.AddDbContext<MarketDbContext>(options =>
{
    options.UseSqlServer("Data Source = 'DESKTOP-R4ITLSH,1433\\MSSQLSERVER'; Initial Catalog =MarketDB;MultipleActiveResultSets=True; ");
});
builder.Services.AddLogging(log =>
{
    log.ClearProviders();
    log.AddFile($"{Directory.GetCurrentDirectory()}\\LogFile\\log.txt", LogLevel.Error);
});


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
