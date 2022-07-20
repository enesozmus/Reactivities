using MediatR;
using Udemy.Application.Results;

namespace Udemy.Application.Features.PhotosOperations;

public class DeletePhotoCommandRequest : IRequest<Result<Unit>>
{
     public string Id { get; set; }
}
