using Udemy.Application.Features.AuthenticationOperations;

namespace Udemy.Application.Interfaces;

public interface IAuthentication
{
     Task<LoginCommandResponse> LoginAsync(LoginCommandRequest request);
}
