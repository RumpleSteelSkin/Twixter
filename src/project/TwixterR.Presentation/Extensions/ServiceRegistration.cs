using Microsoft.AspNetCore.Identity;
using TwixterR.Application.Services.JwtServices;
using TwixterR.Domain.Entities;
using TwixterR.Persistence.Contexts;
using TwixterR.Presentation.Middlewares;

namespace TwixterR.Presentation.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        services.Configure<CustomTokenOptions>(configuration.GetSection("TokenOptions"));
        services.AddIdentity<User, IdentityRole<Guid>>(opt =>
        {
            opt.User.RequireUniqueEmail = true;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequiredLength = 8;
        }).AddEntityFrameworkStores<BaseDbContext>().AddDefaultTokenProviders();

        services.AddExceptionHandler<HttpExceptionHandler>();

        return services;
    }
}