using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRM.Common.Constants;
using SRM.Models.ViewModels.StudentsList;
using SRM.Models.ViewModels.User;
using SRM.Services.Contracts.StudentGroups;
using SRM.Services.Interfaces;

namespace SRM.Controllers
{
    public class StudentGroupController : BaseController
    {
        private readonly IStudentGroupService _studentGroupService;

        public StudentGroupController(IStudentGroupService studentGroupService)
        {
            _studentGroupService = studentGroupService;
        }
        public StudentGroupController()
        {
        }

        [HttpPost, Authorize(Roles = UserRole.Starosta)]
        public ActionResult Create([FromBody]StudentGroupVM studentGroupViewModel)
        {
            if (!ModelState.IsValid)
                return RequestModelIsIncorrect();
            var model = new StudentGroupModel
            {
                Name = studentGroupViewModel.Name
            };
            var response = _studentGroupService.Add(model);
            if (!response.Success)
                return CustomValidationError(response.ErrorMessage);
            return Json(response);
        }

        [HttpPut, Authorize(Roles = UserRole.Starosta)]
        public ActionResult Update([FromBody]StudentGroupVM studentGroupViewModel)
        {
            if (!ModelState.IsValid)
                return RequestModelIsIncorrect();
            //TODO
            return Ok();
        }

        [HttpDelete, Route("{studentGroupId}"), Authorize(Roles = UserRole.Starosta)]
        public ActionResult Delete(int studentGroupId)
        {
            //TODO
            return Ok();
        }
    }
}
