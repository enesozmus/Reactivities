namespace Udemy.Application.Features.AuthenticationOperations;

public class RegisterCommandResponse
{
     public string UserName { get; set; }
     public bool IsSuccess { get; set; }
     public string Message { get; set; }
}
