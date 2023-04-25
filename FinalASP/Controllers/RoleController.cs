using FinalASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalASP.Controllers
{
    public class RoleController : Controller
    {
            CloudKitchenContext context;
        public IActionResult Index()
        {
           List<ApplicationUser> usersmodels= context.Users.ToList();
           return View(usersmodels);
        }
    }
}
