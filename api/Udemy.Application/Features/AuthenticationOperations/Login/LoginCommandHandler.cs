using MediatR;
using Udemy.Application.Interfaces;

namespace Udemy.Application.Features.AuthenticationOperations;

public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
     private readonly IAuthentication _authentication;

     public LoginCommandHandler(IAuthentication authentication) => _authentication = authentication;

     public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
     {
          return await _authentication.LoginAsync(request);
     }
}
