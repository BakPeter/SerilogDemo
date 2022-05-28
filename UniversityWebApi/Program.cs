using Serilog;
using StudentService.Services;
using UniversityWebApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

#region Add services
// Add services to the container.
//var settings = builder.Configuration.GetSection("<sectionName>").Get<Settings>();
builder.Services.AddStudentServiceInfrastructureServices(
    new StudentService.Configurations.StudentServiceConfiguration());
#endregion
#region Serlog

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
