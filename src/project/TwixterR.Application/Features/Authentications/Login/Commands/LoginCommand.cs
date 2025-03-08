using MediatR;
using TwixterR.Application.Services.JwtServices;

namespace TwixterR.Application.Features.Authentications.Login.Commands;

public class LoginCommand: IRequest<AccessTokenDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
}