using MediatR;
using Udemy.Application.Results;

namespace Udemy.Application.Features.ProfilesOperations;

public class EditProfilesQueryRequest : IRequest<Result<Unit>>
{
     public string FirstName { get; set; }
     public string LastName { get; set; }
     public string? Bio { get; set; }
}
