using FinalASP.Models;
using FinalASP.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinalASP.Controllers
{
    public class PhysicalKitchenController : Controller
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

        public PhysicalKitchenController(IDeliveryCompanyRepository _DeliveryCompanyRepo, IKitchenRepository _IKitchenRepo,
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
            List<PhysicalKitchen> PhysicalKitchenModel = IPhysicalKitchenRepo.GetAll();
            return View("Index", PhysicalKitchenModel);
        }
		public IActionResult New()
		{
			return View();
		}
		[HttpPost]
		public IActionResult SaveNew(PhysicalKitchen newKitchen)
		{
			if (ModelState.IsValid == true)
			{
				IPhysicalKitchenRepo.Insert(newKitchen);
				return RedirectToAction("KitchenProfile");
			}
			return View("New", newKitchen);
		}
        public IActionResult GetPhyshicalKitchens()
        {
            string KitchenName = User.Identity.Name;
            int PhyKitchenId = IPhysicalKitchenRepo.GetPhyshicalIdByName(KitchenName);
            PhysicalKitchen PhyKitchen = IPhysicalKitchenRepo.GetById(PhyKitchenId);
            ViewData["Kitchen"] = PhyKitchen;
            List <Kitchen> KitchensModel = IKitchenRepo.GetKitchensByPhyKitchen(PhyKitchenId);
            return View("GetPhyshicalKitchens", KitchensModel);
        }
        public IActionResult AddKitchenToPhyKitchen()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddKitchenToPhyKitchen(Kitchen Kitchen)
        {
            string KitchenName = User.Identity.Name;
            int PhyKitchenId = IPhysicalKitchenRepo.GetPhyshicalIdByName(KitchenName);
            Kitchen.PhysicalKitchenId = PhyKitchenId;
            IKitchenRepo.Insert(Kitchen);
            return RedirectToAction("GetPhyshicalKitchens");
        }
        public IActionResult PhyKitchenProfile()
        {
            string PhyKitchenName = User.Identity.Name;
            int PhyKitchenId = IPhysicalKitchenRepo.GetPhyshicalIdByName(PhyKitchenName);
            PhysicalKitchen PhyKitchen = IPhysicalKitchenRepo.GetById(PhyKitchenId);
            ViewData["PhyKitchen"] = PhyKitchen;
            return View(PhyKitchen);
        }
    }
}
