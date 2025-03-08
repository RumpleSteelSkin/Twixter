using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TwixterR.Application.Services.JwtServices;
using TwixterR.Domain.Entities;

namespace TwixterR.Application.Features.Authentications.Login.Commands;

public class LoginCommandHandler(UserManager<User> userManager, IJwtService jwtService)
    : IRequestHandler<LoginCommand, AccessTokenDto>
{
    public async Task<AccessTokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var emailUser = await userManager.FindByEmailAsync(request.Email);
        if (emailUser is null || await userManager.CheckPasswordAsync(emailUser, request.Password) is false)
            throw new NotFoundException("Kullanıcı Adı veya Şifre bulunamadı!");
        return await jwtService.CreateTokenAsync(emailUser);
    }
}