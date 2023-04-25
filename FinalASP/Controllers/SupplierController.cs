using FinalASP.Models;
using FinalASP.Repositories;
using FinalASP.ViewModel;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace FinalASP.Controllers
{
    public class SupplierController : Controller
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
        ISupplierMatrialRepository ISupplierMatrialRepo;

        public SupplierController(IDeliveryCompanyRepository _DeliveryCompanyRepo, IKitchenRepository _IKitchenRepo,
            IVirtualOrderRepository _IVirtualOrderRepo, IVirtualKitchenRepository _IVirtualKitchenRepo, ISupplierRepository _ISupplierRepo,
            IReservationRepository _IReservationRepo, IPhysicalOrderRepository _IPhysicalOrderRepo,
            IPhysicalOrderListRepository _IPhysicalOrderListRepo, IPhysicalKitchenRepository _IPhysicalKitchenRepo, ISupplierMatrialRepository _ISupplierMatrialRepo)
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
            ISupplierMatrialRepo = _ISupplierMatrialRepo;
        }

        public IActionResult Index()
        {
            List<Supplier> SupplierModel = ISupplierRepo.GetAll();
            return View("Index", SupplierModel);
        }
        public IActionResult GetSupplierMatrials()
        {
            string SupplierName = User.Identity.Name;
            int SupplierId = ISupplierRepo.GetSupplierIdByName(SupplierName);
            List<SupplierMatrial> MatrialsModel = ISupplierMatrialRepo.GetMatrialsBySupplier(SupplierId);
            return View("GetSupplierMatrials", MatrialsModel);
        }
        public IActionResult AddMatrialToSupplier()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMatrialToSupplier(SupplierMatrial supplierMatrial)
        {
            string SupplierName = User.Identity.Name;
            int SupplierId = ISupplierRepo.GetSupplierIdByName(SupplierName);
            supplierMatrial.SupplierId= SupplierId;
            ISupplierMatrialRepo.AddMatrialToSupplier(supplierMatrial);
            return RedirectToAction("GetSupplierMatrials");
        }
        public IActionResult SupplierProfile()
        {
            string SupplierName = User.Identity.Name;
            int SupplierId = ISupplierRepo.GetSupplierIdByName(SupplierName);
            Supplier supplierModel = ISupplierRepo.GetById(SupplierId);
            return View(supplierModel);
        }



        /////
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveNew(Supplier newSupplier)
        {
            if (ModelState.IsValid == true)
            {
                ISupplierRepo.Insert(newSupplier);
                return RedirectToAction("SupplierProfile");
            }
            return View("New", newSupplier);
        }
    }
}
