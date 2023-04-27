using FinalASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Policy;

namespace FinalASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        CloudKitchenContext context = new CloudKitchenContext();
        public HomeController(ILogger<HomeController> logger, CloudKitchenContext _context)
        {
            _logger = logger;
            context = _context;
        }

        public IActionResult Index()
        {
            
            string UserName = User.Identity.Name;
            MyGeneralModel model = new MyGeneralModel();
            if (User.IsInRole("Supplier"))
            {
                string SupplierImage = context.Suppliers.FirstOrDefault(S => S.Username == UserName).logo;
                model.SupplierImage= SupplierImage;
            }
            else if (User.IsInRole("Chef"))
            {
                string ChefImage = context.VirtualKitchens.FirstOrDefault(S => S.Name == UserName).LogoImage;
                model.ChefImage = ChefImage;
            }
            else if (User.IsInRole("Delivery"))
            {
                string DeliveryImage = context.DeliveryCompanys.FirstOrDefault(S => S.Name == UserName).logo;
                model.DeliveryImage = DeliveryImage;
            }
            else if (User.IsInRole("Kitchen"))
            {
                string KitchenImage = context.PhysicalKitchens.FirstOrDefault(S => S.Name == UserName).LogoImage;
                model.KitchenImage = KitchenImage;
            }
            return View(model);
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