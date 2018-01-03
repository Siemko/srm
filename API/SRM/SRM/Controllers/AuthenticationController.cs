using Microsoft.AspNetCore.Mvc;
using Azynmag.Services.Contracts.Accounts;
using Azynmag.Services.Interfaces;
using Azynmag.Models.ViewModels.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Azynmag.Authorization;

namespace Azynmag.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : BaseController
    {
        private readonly IAccountService _accountService;

        public AuthenticationController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost, Route("sign-in")]
        public ActionResult SignIn([FromBody]SignInVM loginViewModel)
        {
            if (!ModelState.IsValid)
                return RequestModelIsIncorrect();
            var response = _accountService.SignIn(loginViewModel.Email, loginViewModel.Password);
            if (!response.Success)
                return CustomValidationError(response.ErrorMessage);
            return Json(AuthorizationHelper.GenerateTokenForUser(response.User));
        }

        [HttpPost, Route("sign-up")]
        public ActionResult SignUp([FromBody]SignUpVM registerViewModel)
        {
            if (!ModelState.IsValid)
                return RequestModelIsIncorrect();
            var account = new AccountModel
            {
                Email = registerViewModel.Email,
                Password = registerViewModel.Password
            };
            var signUpResponse = _accountService.SignUp(account);
            if (!signUpResponse.Result.Succeeded)
                return CustomValidationError("Sign up errors", signUpResponse.Result.Errors.Select(e => e.Description));

            return Ok();
        }
    }
}
