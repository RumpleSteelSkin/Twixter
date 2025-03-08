using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TwixterR.Domain.Entities;
using TwixterR.Persistence.Contexts;

namespace TwixterR.Presentation.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();

        services.AddIdentity<User, IdentityRole<Guid>>(opt =>
        {
            opt.User.RequireUniqueEmail = true;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequiredLength = 8;
        }).AddEntityFrameworkStores<BaseDbContext>().AddDefaultTokenProviders();
        
        return services;
    }
}