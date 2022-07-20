namespace Udemy.Application.Features.AuthenticationOperations;

public class LoginCommandResponse
{
	public Guid Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string UserName { get; set; }
	public string Email { get; set; }
	public string Token { get; set; }
	public string Image { get; set; }

	public bool IsSuccess { get; set; }
	public string[] Errors { get; set; }
}
