using Microsoft.AspNetCore.Mvc;
using Udemy.Application.Features.ActivitiesOperations;
using Udemy.Domain.Entities;

namespace Udemy.API.Controllers;

public class ActivitiesController : BaseController
{
     [HttpGet]
     public async Task<ActionResult<IReadOnlyList<GetActivitiesQueryResponse>>> GetActivities() => Ok(await Mediator.Send(new GetActivitiesQueryRequest()));

     [HttpGet("{id}")]
     public async Task<ActionResult<GetActivityDetailQueryResponse>> GetActivity(Guid id) => Ok(await Mediator.Send(new GetActivityDetailQueryRequest(id)));

     [HttpPost]
     public async Task<IActionResult> CreateActivity(Activity activity) => Ok(await Mediator.Send(new CreateActivityCommandRequest { Activity = activity}));

     [HttpPut("{id}")]
     public async Task<IActionResult> UpdateActivity(Guid id, Activity activity)
     {
          activity.Id = id;
          return Ok(await Mediator.Send(new UpdateActivityCommandRequest { Activity = activity }));
     }

     [HttpDelete("{id}")]
     public async Task<IActionResult> RemoveActivity(Guid id) => Ok(await Mediator.Send(new RemoveActivityCommandRequest { Id = id}));
}