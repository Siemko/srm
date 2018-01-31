using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SRM.Services.Contracts;
using System;
using System.Net;

namespace SRM.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("MyPolicy")]
    public class BaseController : Controller
    {
        protected IActionResult GetResult<T>(Func<T> action, Func<T, object> result)
             where T : BaseContractResponse
        {
            var response = action();
            if (!response.Success)
                return CustomValidationError(response.ErrorMessage);
            return Json(result(response));
        }

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
