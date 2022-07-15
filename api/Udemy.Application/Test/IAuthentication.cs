using Udemy.Application.Features.AuthenticationOperations;

namespace Udemy.Application.Test;

public interface IAuthentication
{
     Task<LoginCommandResponse> LoginAsync(LoginCommandRequest request);
}
