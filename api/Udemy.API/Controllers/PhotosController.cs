using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Features.PhotosOperations;

namespace Udemy.API.Controllers;

public class PhotosController : BaseController
{
     [HttpPost]
     public async Task<IActionResult> Add([FromForm] AddPhotoCommandRequest request) => HandleResult(await Mediator.Send(request));

     [HttpDelete("{id}")]
     public async Task<IActionResult> Delete(string id) => HandleResult(await Mediator.Send(new DeletePhotoCommandRequest { Id = id }));

     [HttpPost("{id}/setMain")]
     public async Task<IActionResult> SetMain(string id) => HandleResult(await Mediator.Send(new SetMainPhotoCommandRequest { Id = id }));
}
