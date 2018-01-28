using Microsoft.AspNetCore.Mvc;
using SRM.Services.Contracts.Accounts;
using SRM.Services.Interfaces;
using SRM.Models.ViewModels.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using SRM.Authorization;

namespace SRM.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IEmailService _emailService;

        public AuthenticationController(IAccountService accountService, IEmailService emailService)
        {
            _accountService = accountService;
            _emailService = emailService;
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
                Password = registerViewModel.Password,
                Name = registerViewModel.Name,
                Surname = registerViewModel.Surname
            };
            var signUpResponse = _accountService.SignUp(account);
            if (!signUpResponse.Result.Succeeded)
                return CustomValidationError("Sign up errors", signUpResponse.Result.Errors.Select(e => e.Description));
            return NoContent();
        }

        [HttpPost, Route("remind-password")]
        public ActionResult RemindPassword([FromBody]string email)
        {
            var response = _emailService.SendResetToken(email);
            if (!response.Success)
                return CustomValidationError(response.ErrorMessage);
            return Json(response);
        }

        [HttpPost, Route("reset-password")]
        public ActionResult RemindPassword([FromBody]ResetPasswordVM model)
        {
            if (!ModelState.IsValid)
                return RequestModelIsIncorrect();
            var resetPasswordModel = new ResetPasswordModel
            {
                Password = model.Password,
                Guid = model.Guid
            };
            var response = _accountService.ResetPassword(resetPasswordModel);
            if (!response.Success)
                return CustomValidationError(response.ErrorMessage);
            return Json(response);
        }
    }
}
