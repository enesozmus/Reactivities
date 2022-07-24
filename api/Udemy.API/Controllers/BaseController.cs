using MediatR;
using Microsoft.AspNetCore.Mvc;
using Udemy.API.Extensions;
using Udemy.Application.Results;

namespace Udemy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
     private IMediator _mediator;

     protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
          .GetService<IMediator>();

     #region Http Durum Kodları

     protected ActionResult HandleResult<T>(Result<T> result)
     {
          if (result == null) return NotFound();

          if (result.IsSuccess && result.Value != null)
               return Ok(result.Value);

          if (result.IsSuccess && result.Value == null)
               return NotFound();

          return BadRequest(result.Error);
     }

     #endregion

     #region Filtreleme, Sayfalama

     protected ActionResult HandlePagedResult<T>(Result<PagedList<T>> result)
     {
          if (result == null) return NotFound();
          if (result.IsSuccess && result.Value != null)
          {
               Response.AddPaginationHeader(result.Value.CurrentPage, result.Value.PageSize,
                   result.Value.TotalCount, result.Value.TotalPages);
               return Ok(result.Value);
          }
          if (result.IsSuccess && result.Value == null)
               return NotFound();
          return BadRequest(result.Error);
     }

     #endregion
}
