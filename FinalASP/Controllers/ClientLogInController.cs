using FinalASP.Models;
using FinalASP.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalASP.Controllers
{
    public class ClientLogInController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ClientLogInController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(ClientLogInViewModel clientVM)
        {
            if (ModelState.IsValid)
            {
                //Check Valid User ==>db
                ApplicationUser userModel =
                    await userManager.FindByNameAsync(clientVM.UserName);
                if (userModel != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userModel, clientVM.Password);
                    if (found)
                    {
                        //cookie
                        await signInManager.SignInAsync(userModel, clientVM.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Invalid Login, please try again");
            }
            return View(clientVM);
        }
    }
}
