using FinalASP.Models;
using FinalASP.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinalASP.Controllers
{

    public class SupplierMatrialController : Controller
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

        public SupplierMatrialController(IDeliveryCompanyRepository _DeliveryCompanyRepo, IKitchenRepository _IKitchenRepo,
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

        public IActionResult Index()
        {
            List<SupplierMatrial> SupplierMatrialModel = ISupplierMatrialRepo.GetAll();
            return View("Index", SupplierMatrialModel);
        }
        public IActionResult Edit(int id)
        {
            SupplierMatrial MaterialToEdit = ISupplierMatrialRepo.GetById(id);
            return View(MaterialToEdit);//View=>Edit
        }
        //Submite MEthod=post
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, SupplierMatrial MaterialToEdit, IFormFile Image)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    string fileName = Image.FileName;
                    fileName = Path.GetFileName(fileName);
                    string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", fileName);
                    var stream = new FileStream(uploadpath, FileMode.Create);
                    Image.CopyToAsync(stream);
                    MaterialToEdit.Image = fileName;
                    ISupplierMatrialRepo.Update(MaterialToEdit);

                    return RedirectToAction("GetSupplierMatrials","Supplier");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Name", ex.Message);
                }
            }
            return View(MaterialToEdit);//View Eidt
        }
        public IActionResult GetMatrialWithID ([FromRoute]int id)
        {
            SupplierMatrial supplierMatrial = ISupplierMatrialRepo.GetById(id);
            return View();
        }
        public IActionResult SupFromQunt(SupplierMatrial supplierMatrial) 
        {

            return View();
        }
    }
    }


