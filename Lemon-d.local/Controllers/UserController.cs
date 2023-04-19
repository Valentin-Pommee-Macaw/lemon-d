using Lemon_d.local.Database.DbModels;
using Lemon_d.local.Helpers.Database;
using Microsoft.AspNetCore.Mvc;

namespace Lemon_d.local.Controllers
{
    public class UserController : Controller
    {
        private readonly MasterDbContext _context;
        public UserController(ListHelper listHelper, MasterDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login()
        {
            return View();
        }
    }
}
