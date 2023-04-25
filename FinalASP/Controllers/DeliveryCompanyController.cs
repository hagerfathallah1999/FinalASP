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
		public IActionResult SaveNew(DeliveryCompany newdelivery)
		{
			if (ModelState.IsValid == true)
			{
                newdelivery.Name = TempData["UserName"].ToString();
                DeliveryCompanyRepo.Insert(newdelivery);
                return RedirectToAction("LogIn", "ClientLogIn");
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
    }
}
