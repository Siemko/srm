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

        [HttpGet, Route("{userId}")]
        public IActionResult Get(int userId)
        {
            return GetResult(() => _userService.GetUser(userId), r => r.User);
        }

        [HttpGet, Authorize(UserRole.Starosta)]
        public IActionResult GetUsers()
        {
            return GetResult(() => _userService.GetUsers(), r => r.Users);
        }

        [HttpGet, Route("activated"), Authorize(UserRole.Starosta)]
        public IActionResult GetActivatedUsers()
        {
            return GetResult(() => _userService.GetActivatedUsers(), r => r.Users);
        }

        [HttpGet, Route("deactivated"), Authorize(UserRole.Starosta)]
        public IActionResult GetDeactivatedUsers()
        {
            return GetResult(() => _userService.GetDeactivatedUsers(), r => r.Users);
        }

        [HttpGet, Route("student-group/{studentGroupId}"), Authorize(UserRole.Starosta)]
        public IActionResult GetUsersByStudentGroup(int studentGroupId)
        {
            return GetResult(() => _userService.GetUsersByStudentGroup(studentGroupId), r => r.Users);
        }

        [HttpPut]
        public IActionResult Update([FromBody]UserVM userViewModel)
        {
            if (!ModelState.IsValid)
                return RequestModelIsIncorrect();
            return GetResult(() => _userService.UpdateUser(userViewModel.MapToUserModel()), r => r);
        }

        [HttpPut, Route("{userId}/activate"), Authorize(UserRole.Starosta)]
        public ActionResult Activate(int userId)
        {
            var response = _userService.Activate(userId);
            if (!response.Success)
                return CustomValidationError(response.ErrorMessage);
            return Json(response);
        }

        [HttpPut, Route("{userId}/disable"), Authorize(UserRole.Starosta)]
        public ActionResult Disable(int userId)
        {
            var response = _userService.Deactivate(userId);
            if (!response.Success)
                return CustomValidationError(response.ErrorMessage);
            return Json(response);
        }
    }
}
