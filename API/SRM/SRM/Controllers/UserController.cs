﻿using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Get(int userId)
        {
            //TODO
            return Ok();
        }

        [HttpGet]
        public ActionResult Get()
        {
            var response = _userService.GetUsers();
            if (!response.Success)
                return CustomValidationError(response.ErrorMessage);
            return Json(response.Users);
        }

        [HttpPut]
        public ActionResult Update([FromBody]UserVM userViewModel)
        {
            if (!ModelState.IsValid)
                return RequestModelIsIncorrect();
            //TODO
            return Ok();
        }

        [HttpPut, Route("{userId}")]
        public ActionResult Activate(int userId)
        {
            var response = _userService.Activate(userId);
            if (!response.Success)
                return CustomValidationError(response.ErrorMessage);
            return Json(response);
        }

        [HttpPut, Route("{userId}")]
        public ActionResult Disable(int userId)
        {
            var response = _userService.Deactivate(userId);
            if (!response.Success)
                return CustomValidationError(response.ErrorMessage);
            return Json(response);
        }
    }
}
