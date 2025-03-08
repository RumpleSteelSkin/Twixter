using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TwixterR.Application.Services.JwtServices;

namespace TwixterR.Application.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<IJwtService, JwtService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(opt => { opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        return services;
    }
}