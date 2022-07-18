using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Features.ActivitiesOperations;

namespace Udemy.API.Controllers;

public class ActivitiesController : BaseController
{
     [AllowAnonymous]
     [HttpGet]
     public async Task<IActionResult> GetActivities() => HandleResult(await Mediator.Send(new GetActivitiesQueryRequest()));

     [AllowAnonymous]
     [HttpGet("{id}")]
     public async Task<IActionResult> GetActivity(Guid id) => HandleResult(await Mediator.Send(new GetActivityDetailQueryRequest(id)));


     [HttpPost]
     public async Task<IActionResult> CreateActivity(CreateActivityCommandRequest request) => HandleResult(await Mediator.Send(request));


     [HttpPost("{id}/attend")]
     public async Task<IActionResult> Attend(Guid id) => HandleResult(await Mediator.Send(new CreateAttendanceCommandRequest { Id = id }));

     [Authorize(Policy = "IsActivityHost")]
     [HttpPut("{id}")]
     public async Task<IActionResult> UpdateActivity(UpdateActivityCommandRequest request) => HandleResult(await Mediator.Send(request));


     [Authorize(Policy = "IsActivityHost")]
     [HttpDelete("{id}")]
     public async Task<IActionResult> RemoveActivity(Guid id) => HandleResult(await Mediator.Send(new RemoveActivityCommandRequest { Id = id }));
}