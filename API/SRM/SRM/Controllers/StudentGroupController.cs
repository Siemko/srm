using Microsoft.AspNetCore.Mvc;
using SRM.Models.ViewModels.StudentsList;
using SRM.Models.ViewModels.User;
using SRM.Services.Interfaces;

namespace SRM.Controllers
{
    public class StudentGroupController : BaseController
    {
        public StudentGroupController()
        {
        }

        [HttpPost]
        public ActionResult Create([FromBody]StudentGroupVM studentGroupViewModel)
        {
            if (!ModelState.IsValid)
                return RequestModelIsIncorrect();
            //TODO
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody]StudentGroupVM studentGroupViewModel)
        {
            if (!ModelState.IsValid)
                return RequestModelIsIncorrect();
            //TODO
            return Ok();
        }

        [HttpDelete, Route("{studentGroupId}")]
        public ActionResult Delete(int studentGroupId)
        {
            //TODO
            return Ok();
        }
    }
}
