using Lemon_d.local.Database.DbModels;
using Lemon_d.local.Helpers.Database;
using Microsoft.AspNetCore.Mvc;

namespace Lemon_d.local.Controllers
{
    public class ListController : Controller
    {
        private readonly ListHelper _listHelper;
        public ListController(ListHelper listHelper)
        {
            _listHelper = listHelper;
        }

        public IActionResult List(string li)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            _listHelper.CreateList(name);
            return RedirectToAction("List", new { });
        }

        [HttpPost]
        public IActionResult CreateWithProject(string name, Project project)
        {
            Guid pl = _listHelper.CreateList(name, project).ID;
            return RedirectToAction("List", new { li = pl });
        }
    }
}
