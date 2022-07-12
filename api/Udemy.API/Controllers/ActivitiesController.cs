using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Features.ActivitiesOperations;

namespace Udemy.API.Controllers;

public class ActivitiesController : BaseController
{
     [HttpGet]
     public async Task<IActionResult> GetActivities() => HandleResult(await Mediator.Send(new GetActivitiesQueryRequest()));


     [HttpGet("{id}")]
     public async Task<IActionResult> GetActivity(Guid id) => HandleResult(await Mediator.Send(new GetActivityDetailQueryRequest(id)));


     [HttpPost]
     public async Task<IActionResult> CreateActivity(CreateActivityCommandRequest request) => HandleResult(await Mediator.Send(request));


     [HttpPut("{id}")]
     public async Task<IActionResult> UpdateActivity(UpdateActivityCommandRequest request) => HandleResult(await Mediator.Send(request));


     [HttpDelete("{id}")]
     public async Task<IActionResult> RemoveActivity(Guid id) => HandleResult(await Mediator.Send(new RemoveActivityCommandRequest { Id = id }));
}