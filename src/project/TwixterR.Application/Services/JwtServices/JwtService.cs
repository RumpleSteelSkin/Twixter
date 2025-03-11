using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.CrossCuttingConcerns.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TwixterR.Domain.Entities;

namespace TwixterR.Application.Services.JwtServices;

public class JwtService(
    UserManager<User> userManager,
    IOptions<CustomTokenOptions> options)
    : IJwtService
{
    private readonly CustomTokenOptions _customTokenOptions = options.Value;

    public async Task<AccessTokenDto> CreateTokenAsync(User user)
    {
        var accessTokenExpiration = DateTime.Now.AddMinutes(_customTokenOptions.AccessTokenExpiration);
        JwtSecurityToken jwt = new(
            issuer: _customTokenOptions.Issuer,
            expires: accessTokenExpiration,
            signingCredentials: new SigningCredentials(GetSecurityKey(_customTokenOptions.SecurityKey),
                SecurityAlgorithms.HmacSha512Signature),
            claims: await GetClaims(user)
        );
        AccessTokenDto accessTokenDto = new()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(jwt),
            TokenExpiration = accessTokenExpiration
        };
        return accessTokenDto;
    }

    private async Task<List<Claim>> GetClaims(User user)
    {
        var claimList = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name,user.UserName!),
            new Claim(ClaimTypes.Email, user.Email ?? throw new NotFoundException("User email not set!"))
        };

        var roles = await userManager.GetRolesAsync(user);

        if (roles.Count > 0)
            claimList.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));

        return claimList;
    }

    private SecurityKey GetSecurityKey(string key)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    }
}