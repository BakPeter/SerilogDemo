using Microsoft.Extensions.DependencyInjection;
using StudentService.Configurations;
using StudentService.Services.Interfaces;

namespace StudentService.Services;

public static class ServicesCollectionExtension
{
    public static void AddStudentServiceInfrastructureServices(this IServiceCollection services, StudentServiceConfiguration settings)
    {
        services.AddSingleton(settings);
        services.AddScoped<IStudentService, StudentService>();
        services.AddSingleton<IStudentsRepository, StudentsRepository>();
    }
}
