using MediatR;
using Udemy.Application.Test;

namespace Udemy.Application.Features.AuthenticationOperations;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
     public string Email { get; set; }
     public string Password { get; set; }
}
