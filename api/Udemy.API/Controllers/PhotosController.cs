using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Features.PhotosOperations;

namespace Udemy.API.Controllers;

public class PhotosController : BaseController
{
     [HttpPost]
     public async Task<IActionResult> Add([FromForm] AddPhotoCommandRequest request) => HandleResult(await Mediator.Send(request));
}
