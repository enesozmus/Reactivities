namespace Udemy.Application.Features.AuthenticationOperations;

public class GetCurrentUserQueryResponse
{
	public Guid Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string UserName { get; set; }
	public string Email { get; set; }
}
