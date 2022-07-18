using MediatR;
using Microsoft.AspNetCore.Http;
using Udemy.Application.Result;
using Udemy.Domain.Entities;

namespace Udemy.Application.Features.PhotosOperations;

public class AddPhotoCommandRequest : IRequest<Result<Photo>>
{
     public IFormFile File { get; set; }
}
