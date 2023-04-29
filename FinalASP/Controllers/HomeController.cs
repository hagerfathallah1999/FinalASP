using FinalASP.Models;
using FinalASP.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Policy;

namespace FinalASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        CloudKitchenContext context = new CloudKitchenContext();
        IKitchenRepository IKitchenRepo;
        public HomeController(ILogger<HomeController> logger, IKitchenRepository iKitchenRepo, CloudKitchenContext _context)
        {
            _logger = logger;
            IKitchenRepo = iKitchenRepo;
            context = _context;
        }

        public IActionResult Index()
        {
            
            string UserName = User.Identity.Name;
            MyGeneralModel.kitchens = IKitchenRepo.GetAllWithOwner();
            if (User.IsInRole("Supplier"))
            {
                MyGeneralModel.Image = context.Suppliers.FirstOrDefault(S => S.Username == UserName).logo;
                
            }
            else if (User.IsInRole("Chef"))
            {
                MyGeneralModel.Image = context.VirtualKitchens.FirstOrDefault(S => S.Name == UserName).LogoImage;
                
            }
            else if (User.IsInRole("Delivery"))
            {
                MyGeneralModel.Image = context.DeliveryCompanys.FirstOrDefault(S => S.Name == UserName).logo;
                
            }
            else if (User.IsInRole("Kitchen"))
            {
                MyGeneralModel.Image = context.PhysicalKitchens.FirstOrDefault(S => S.Name == UserName).LogoImage;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}