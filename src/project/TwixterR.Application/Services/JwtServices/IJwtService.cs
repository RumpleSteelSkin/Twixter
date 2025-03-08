using TwixterR.Domain.Entities;

namespace TwixterR.Application.Services.JwtServices;

public interface IJwtService
{
    Task<AccessTokenDto> CreateTokenAsync(User user);
}