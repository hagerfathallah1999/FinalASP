using FinalASP.Models;
using FinalASP.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinalASP.Controllers
{
    public class DeliveryCompanyController : Controller
    {
        IDeliveryCompanyRepository IDeliveryCompanyRepo;
        IKitchenRepository IKitchenRepo;
        IPhysicalKitchenRepository IPhysicalKitchenRepo;
        IPhysicalOrderListRepository IPhysicalOrderListRepo;
        IPhysicalOrderRepository IPhysicalOrderRepo;
        IReservationRepository IReservationRepo;
        ISupplierRepository ISupplierRepo;
        IVirtualKitchenRepository IVirtualKitchenRepo;
        IVirtualOrderRepository IVirtualOrderRepo;

        public DeliveryCompanyController (IDeliveryCompanyRepository _DeliveryCompanyRepo, IKitchenRepository _IKitchenRepo,
            IVirtualOrderRepository _IVirtualOrderRepo, IVirtualKitchenRepository _IVirtualKitchenRepo, ISupplierRepository _ISupplierRepo,
            IReservationRepository _IReservationRepo, IPhysicalOrderRepository _IPhysicalOrderRepo,
            IPhysicalOrderListRepository _IPhysicalOrderListRepo, IPhysicalKitchenRepository _IPhysicalKitchenRepo)
        {
            IDeliveryCompanyRepo = _DeliveryCompanyRepo;
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
            List<DeliveryCompany> DeliveryCompanyModel = IDeliveryCompanyRepo.GetAll();
            return View("Index", DeliveryCompanyModel);
        }
		public IActionResult New()
		{
			return View();
		}
		[HttpPost]
		public IActionResult SaveNew(DeliveryCompany newdelivery,IFormFile logo)
		{
			if (ModelState.IsValid == true)
			{
                newdelivery.Name = TempData["UserName"].ToString();
                newdelivery.Email = TempData["Email"].ToString();
                string fileName = logo.FileName;

                fileName = Path.GetFileName(fileName);

                string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", fileName);

                var stream = new FileStream(uploadpath, FileMode.Create);

                logo.CopyToAsync(stream);
                newdelivery.logo = fileName;
                IDeliveryCompanyRepo.Insert(newdelivery);
                return RedirectToAction("Index", "Home");
            }
            return View("New", newdelivery);
		}
        public IActionResult DeliveryProfile()
        {
            string DeliveryName = User.Identity.Name;
            int DeliveryId = IDeliveryCompanyRepo.GetDeliveryIdByName(DeliveryName);
            DeliveryCompany Delivery = IDeliveryCompanyRepo.GetById(DeliveryId);
            ViewData["Delivery"] = Delivery;
            return View(Delivery);
        }
        public IActionResult Edit(int id)
        {
            DeliveryCompany DeliveryCompanyToEdit = IDeliveryCompanyRepo.GetById(id);
            return View(DeliveryCompanyToEdit);//View=>Edit
        }
        //Submite MEthod=post
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, DeliveryCompany DeliveryCompanyToEdit, IFormFile logo)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    string fileName = logo.FileName;
                    fileName = Path.GetFileName(fileName);
                    string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", fileName);
                    var stream = new FileStream(uploadpath, FileMode.Create);
                    logo.CopyToAsync(stream);
                    DeliveryCompanyToEdit.logo = fileName;
                    IDeliveryCompanyRepo.Update(DeliveryCompanyToEdit);

                    return RedirectToAction("DeliveryProfile");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Name", ex.Message);
                }
            }

            return View(DeliveryCompanyToEdit);//View Eidt
        }
    }
}
