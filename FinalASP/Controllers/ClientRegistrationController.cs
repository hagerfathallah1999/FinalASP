using FinalASP.Models;
using FinalASP.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinalASP.Controllers
{
	public class ClientRegistrationController : Controller
    {
        //Inject
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ClientRegistrationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) 
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(ClientRegistrationViewModel newClient)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser clientModel = new ApplicationUser();
                clientModel.UserName = newClient.UserName;
                clientModel.Email=newClient.Email;  
                clientModel.PasswordHash = newClient.Password;
                clientModel.Role = newClient.Role;
                //save db
                IdentityResult result =
                    await userManager.CreateAsync(clientModel, newClient.Password); //Hashing  //Block create user in db
                if (result.Succeeded)
                {
                    // Add role to user
                    await userManager.AddToRoleAsync(clientModel, newClient.Role);
                    // Create cookie
                    await signInManager.SignInAsync(clientModel, false);
                    if (newClient.Role == "Supplier")
                    {
						return RedirectToAction("New", "Supplier");
                    }else if (newClient.Role == "Chef")
                    {
                        return RedirectToAction("New", "VirtualKitchen");
                    }else if(newClient.Role == "Delivery")
                    {
                        return RedirectToAction("New", "DeliveryCompany");
                    }else if(newClient.Role == "Kitchen")
                    {
                        return RedirectToAction("New", "PhysicalKitchen");
                    }
                    return RedirectToAction("Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);//Div
                    }
                }
            }

            return View(newClient);
        }
    }
}
