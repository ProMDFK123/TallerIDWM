using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace api.src.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    protected ActionResult<T> HandleResult<T>(T result)
    {
        if (result == null) return NotFound();
        if (result is string error) return BadRequest(error);
        if (result is IEnumerable<string> errors) return BadRequest(errors);
        return Ok(result);
    }
}