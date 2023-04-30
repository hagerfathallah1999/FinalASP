using FinalASP.Models;
using FinalASP.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinalASP.Controllers
{
    public class CartController : Controller
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

        public CartController(IDeliveryCompanyRepository _DeliveryCompanyRepo, IKitchenRepository _IKitchenRepo,
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
            ISupplierMatrialRepo = _ISupplierMatrialRepo;
            IVirtualKitchenRepo = _IVirtualKitchenRepo;
            IVirtualOrderRepo = _IVirtualOrderRepo;
        }
        public IActionResult YourCart()
        {
            return View();
        }
        public ActionResult AddToCart([FromRoute]int id) 
        {
            SupplierMatrial productModel = ISupplierMatrialRepo.GetById(id);
            item item = new item();
            item.SupplierMatrial= productModel;

            if (MyGeneralModel.Matrials == null )
            {
                MyGeneralModel.Matrials = new List<item>();
                MyGeneralModel.Matrials.Add(item);
            }
            else
            {
                var existingItem = MyGeneralModel.Matrials.FirstOrDefault(P => P.SupplierMatrial.id == id);
                if (existingItem != null)
                {
                    MyGeneralModel.Matrials.FirstOrDefault(P => P.SupplierMatrial.id == id).Quantity++;
                }
                else
                {
                    MyGeneralModel.Matrials.Add(item);
                }
            }
            return RedirectToAction("YourCart");
        }
    }
}
