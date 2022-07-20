using MediatR;
using Microsoft.AspNetCore.Http;
using Udemy.Application.Results;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.PhotosOperations;

public class AddPhotoCommandRequest : IRequest<Result<Unit>>
{
     public IFormFile File { get; set; }
}
