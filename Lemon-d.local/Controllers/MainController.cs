using Lemon_d.local.IGDB;
using Lemon_d.local.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lemon_d.local.Controllers
{
    public class MainController : Controller
    {

        public IActionResult Main()
		{
			return View();
        }

        [HttpPost]
        public ActionResult SubmitSearch(string searchQuery)
        {
            return RedirectToAction("Results", "Results", new { sq = searchQuery });
        }
    }
}