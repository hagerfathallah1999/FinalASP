using Microsoft.AspNetCore.Mvc;

namespace FinalASP.Controllers
{
    public class CartController : Controller
    {
        public IActionResult YourCart()
        {
            return View();
        }
    }
}
