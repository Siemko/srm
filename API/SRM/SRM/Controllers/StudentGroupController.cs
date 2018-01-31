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

        [HttpGet]
        public IActionResult Get()
        {
            return GetResult(() => _studentGroupService.Get(), r => r.StudentGroups);
        }
    }
}
