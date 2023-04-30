using FinalASP.Models;
using FinalASP.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FinalASP.Controllers
{
    public class KitchenController : Controller
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

        public KitchenController(IDeliveryCompanyRepository _DeliveryCompanyRepo, IKitchenRepository _IKitchenRepo,
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
            List<Kitchen> KitchenModel = IKitchenRepo.GetAllWithOwner();
            return View("Index", KitchenModel);
        }

        public IActionResult KitchenDetails([FromRoute] int id)
        {
            Kitchen kitchen = IKitchenRepo.GetById(id);
            MyGeneralModel.Kitchen = kitchen;
            return View("KitchenDetails", kitchen);
        }
        public IActionResult Edit(int id)
        {
            Kitchen KitchenToEdit = IKitchenRepo.GetById(id);
            return View(KitchenToEdit);//View=>Edit
        }
        //Submite MEthod=post
        [HttpPost]
        public async Task<IActionResult> Edit(Kitchen KitchenToEdit)
        {
           
            if (ModelState.IsValid == true)
            {
                try
                {
                    IKitchenRepo.Update(KitchenToEdit);
                        return RedirectToAction("GetPhyshicalKitchens", "PhysicalKitchen");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Name", ex.Message);
                }
            }
            return View(KitchenToEdit);//View Eidt
        }

    }
}
