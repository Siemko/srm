using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRM.Common.Constants;
using SRM.Models.ViewModels.User;
using SRM.Services.Interfaces;

namespace SRM.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get(int userId)
        {
            return GetResult(() => _userService.GetUser(userId), r => r.User);
        }

        [HttpGet, Authorize(Roles = UserRole.Starosta)]
        public ActionResult Get()
        {
            var response = _userService.GetUsers();
            if (!response.Success)
                return CustomValidationError(response.ErrorMessage);
            return Json(response.Users);
        }

        [HttpPut]
        public IActionResult Update([FromBody]UserVM userViewModel)
        {
            if (!ModelState.IsValid)
                return RequestModelIsIncorrect();
            return GetResult(() => _userService.UpdateUser(userViewModel.MapToUserModel()), r => r);
        }

        [HttpPut, Route("{userId}"), Authorize(Roles = UserRole.Starosta)]
        public ActionResult Activate(int userId)
        {
            var response = _userService.Activate(userId);
            if (!response.Success)
                return CustomValidationError(response.ErrorMessage);
            return Json(response);
        }

        [HttpPut, Route("{userId}"), Authorize(Roles = UserRole.Starosta)]
        public ActionResult Disable(int userId)
        {
            var response = _userService.Deactivate(userId);
            if (!response.Success)
                return CustomValidationError(response.ErrorMessage);
            return Json(response);
        }
    }
}
