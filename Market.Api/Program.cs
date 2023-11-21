using Market.Data.Concrete.Ef;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<MarketDbContext>(opt =>
//    opt.UseInMemoryDatabase("Product"));



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
