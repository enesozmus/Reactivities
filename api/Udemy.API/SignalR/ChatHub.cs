using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Udemy.Application.Features.CommentOperations;

namespace Udemy.API.SignalR;


public class ChatHub : Hub
{
     private readonly IMediator _mediator;

     public ChatHub(IMediator mediator)
     {
          _mediator = mediator;
     }

     [Authorize]
     [HttpGet]
     public async Task SendComment(CreateCommentsCommandRequest request)
     {
          var comment = await _mediator.Send(request);

          await Clients
               .Group(request.ActivityId.ToString())
               .SendAsync("ReceiveComment", comment.Value);
     }

     public override async Task OnConnectedAsync()
     {
          var httpContext = Context.GetHttpContext();
          var activityId = httpContext.Request.Query["activityId"];
          await Groups.AddToGroupAsync(Context.ConnectionId, activityId);
          var result = await _mediator.Send(new GetCommentsQueryRequest { ActivityId = Guid.Parse(activityId) });
          await Clients.Caller.SendAsync("LoadComments", result.Value);
     }


}
