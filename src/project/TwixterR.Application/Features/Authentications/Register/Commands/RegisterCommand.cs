using MediatR;
using TwixterR.Application.Services.JwtServices;
namespace TwixterR.Application.Features.Authentications.Register.Commands;
public class RegisterCommand : IRequest<AccessTokenDto>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}