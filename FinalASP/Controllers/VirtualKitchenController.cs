using FinalASP.Models;
using FinalASP.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinalASP.Controllers
{
    public class VirtualKitchenController : Controller
    {
        IDeliveryCompanyRepository DeliveryCompanyRepo;
        IKitchenRepository IKitchenRepo;
        IPhysicalKitchenRepository IPhysicalKitchenRepo;
        IPhysicalOrderListRepository IPhysicalOrderListRepo;
        IPhysicalOrderRepository IPhysicalOrderRepo;
        IReservationRepository IReservationRepo;
        ISupplierRepository ISupplierRepo;
        IVirtualKitchenRepository IVirtualKitchenRepo;
        IVirtualOrderRepository IVirtualOrderRepo;

        public VirtualKitchenController(IDeliveryCompanyRepository _DeliveryCompanyRepo, IKitchenRepository _IKitchenRepo,
            IVirtualOrderRepository _IVirtualOrderRepo, IVirtualKitchenRepository _IVirtualKitchenRepo, ISupplierRepository _ISupplierRepo,
            IReservationRepository _IReservationRepo, IPhysicalOrderRepository _IPhysicalOrderRepo,
            IPhysicalOrderListRepository _IPhysicalOrderListRepo, IPhysicalKitchenRepository _IPhysicalKitchenRepo)
        {
            DeliveryCompanyRepo = _DeliveryCompanyRepo;
            IKitchenRepo = _IKitchenRepo;
            IPhysicalKitchenRepo = _IPhysicalKitchenRepo;
            IPhysicalOrderListRepo = _IPhysicalOrderListRepo;
            IPhysicalOrderRepo = _IPhysicalOrderRepo;
            IReservationRepo = _IReservationRepo;
            ISupplierRepo = _ISupplierRepo;
            IVirtualKitchenRepo = _IVirtualKitchenRepo;
            IVirtualOrderRepo = _IVirtualOrderRepo;
        }

        public IActionResult Index()
        {
            List<VirtualKitchen> VirtualKitchenModel = IVirtualKitchenRepo.GetAll();
            return View("Index", VirtualKitchenModel);
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveNew(VirtualKitchen newChef, IFormFile LogoImage)
        {
            if (ModelState.IsValid == true)
            {
                newChef.Name = TempData["UserName"].ToString();
                newChef.Email = TempData["Email"].ToString();

                string fileName = LogoImage.FileName;

                fileName = Path.GetFileName(fileName);

                string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", fileName);

                var stream = new FileStream(uploadpath, FileMode.Create);

                LogoImage.CopyToAsync(stream);
                newChef.LogoImage = fileName;
                IVirtualKitchenRepo.Insert(newChef);
                return RedirectToAction("Index", "Home");
            }
            return View("New", newChef);
        }
        public IActionResult ChefProfile()
        {
            string ChefName = User.Identity.Name;
            int ChefId = IVirtualKitchenRepo.GetChefIdByName(ChefName);
            VirtualKitchen Chef = IVirtualKitchenRepo.GetById(ChefId);
            ViewData["Chef"] = Chef;
            return View(Chef);
        }
        public IActionResult Edit(int id)
        {
            VirtualKitchen VirtualKitchenToEdit = IVirtualKitchenRepo.GetById(id);
            return View(VirtualKitchenToEdit);//View=>Edit
        }
        //Submite MEthod=post
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, VirtualKitchen VirtualKitchenToEdit, IFormFile LogoImage)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    string fileName = LogoImage.FileName;
                    fileName = Path.GetFileName(fileName);
                    string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", fileName);
                    var stream = new FileStream(uploadpath, FileMode.Create);
                    LogoImage.CopyToAsync(stream);
                    VirtualKitchenToEdit.LogoImage = fileName;
                    IVirtualKitchenRepo.Update(VirtualKitchenToEdit);

                    return RedirectToAction("ChefProfile");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Name", ex.Message);
                }
            }

            return View(VirtualKitchenToEdit);//View Eidt
        }
    }
}
