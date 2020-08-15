using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Resource.Api.Controllers
{
    [Authorize(Policy = "CommerceFrameworkApi")] //policy api.read is requested for this use-case
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
       // [Authorize(Policy = "Consumer")] Policy consumer is not wanted in this use-case
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new JsonResult(User.Claims.Select(c => new { c.Type, c.Value }));
        }
    }
}
