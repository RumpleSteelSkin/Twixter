using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TwixterR.Application.Services.JwtServices;
using TwixterR.Domain.Entities;

namespace TwixterR.Application.Features.Authentications.Register.Commands;

public class RegisterCommandHandler(UserManager<User> userManager, IJwtService jwtService)
    : IRequestHandler<RegisterCommand, AccessTokenDto>
{
    public async Task<AccessTokenDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        User user = new()
        {
            UserName = request.UserName,
            Email = request.Email,
        };

        if (await userManager.FindByEmailAsync(request.Email) is not null)
            throw new BusinessException("Kullanıcı Emaili benzersiz olmalıdır.");

        IdentityResult result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            throw new AuthorizationException(result.Errors.Select(x => x.Description).ToList());


        AccessTokenDto token = await jwtService.CreateTokenAsync(user);
        return token;
    }
}