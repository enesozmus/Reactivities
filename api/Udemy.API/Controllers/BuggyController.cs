using Microsoft.AspNetCore.Mvc;

namespace Udemy.API.Controllers;

public class BuggyController : BaseController
{
     [HttpGet("not-found")]
     public ActionResult GetNotFound() => NotFound();

     [HttpGet("bad-request")]
     public ActionResult GetBadRequest() => BadRequest("This is a bad request");

     [HttpGet("server-error")]
     public ActionResult GetServerError() => throw new Exception("This is a server error");

     [HttpGet("unauthorised")]
     public ActionResult GetUnauthorised() => Unauthorized();
}
