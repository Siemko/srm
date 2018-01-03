using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Azynmag.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BaseController : Controller
    {
        #region Custom Object Results
        protected ObjectResult RequestModelIsIncorrect()
        {
            var obj = new { message = "Model is inncorrect." };
            return StatusCode(422, obj);
        }

        protected ObjectResult CustomValidationError(string message)
        {
            var obj = new { message = message };
            return StatusCode((int)HttpStatusCode.Conflict, obj);
        }

        protected ObjectResult CustomValidationError(string message, object parameters)
        {
            var obj = new
            {
                message = message,
                parameters = parameters
            };
            return StatusCode((int)HttpStatusCode.Conflict, obj);
        }
        #endregion
    }
}
