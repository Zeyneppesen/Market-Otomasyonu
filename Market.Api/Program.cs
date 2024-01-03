using Market.Api.Extensions;
using Market.Data.Abstract;
using Market.Entity;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger=new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("LogFile\\log.txt",rollingInterval:RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();
//builder.Logging.AddSerilog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependency(); 
//builder.AddSingleton<ILogging, Logging>(ILogging);
;



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
