using FinalASP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalASP.Controllers
{
    public class ClientLogOutController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public ClientLogOutController(SignInManager<ApplicationUser> signInManager)
        {  
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }
    }
}
