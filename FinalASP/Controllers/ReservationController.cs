using FinalASP.Models;
using FinalASP.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FinalASP.Controllers
{
    public class ReservationController : Controller
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

        public ReservationController(IDeliveryCompanyRepository _DeliveryCompanyRepo, IKitchenRepository _IKitchenRepo,
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
            List<Reservation> ReservationModel = IReservationRepo.GetAll();
            return View("Index", ReservationModel);
        }
        public IActionResult Resrve()
        {
            string ChefName = User.Identity.Name;
            ViewBag.ChefId = IVirtualKitchenRepo.GetChefIdByName(ChefName);
            ViewBag.Kitchen = MyGeneralModel.Kitchen;
            return View();
        }
        [HttpPost]
        public IActionResult Resrve(Reservation reservation)
        {
            IReservationRepo.Insert(reservation);
            IKitchenRepo.ReserveThisKit(MyGeneralModel.Kitchen);
            return RedirectToAction("index", "Home");
        }
        
    }
}
