using FinalASP.Models;
using FinalASP.Repositories;
using FinalASP.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Security.Principal;

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
            Supplier Supplier = ISupplierRepo.GetSupplierByName(SupplierName);
            ViewData["Supplier"] = Supplier;
            int SupplierId = ISupplierRepo.GetSupplierIdByName(SupplierName);
            List<SupplierMatrial> MatrialsModel = ISupplierMatrialRepo.GetMatrialsBySupplier(SupplierId);
            return View("GetSupplierMatrials", MatrialsModel);
        }
        public IActionResult AddMatrialToSupplier()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMatrialToSupplier(SupplierMatrial supplierMatrial, IFormFile Image)
        {
            string SupplierName = User.Identity.Name;
            int SupplierId = ISupplierRepo.GetSupplierIdByName(SupplierName);
            supplierMatrial.SupplierId= SupplierId;
            string fileName = Image.FileName;
            fileName = Path.GetFileName(fileName);
            string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", fileName);
            var stream = new FileStream(uploadpath, FileMode.Create);
            Image.CopyToAsync(stream);
            supplierMatrial.Image = fileName;
            ISupplierMatrialRepo.AddMatrialToSupplier(supplierMatrial);
            return RedirectToAction("GetSupplierMatrials");
        }
        public IActionResult SupplierProfile()
        {
            string SupplierName = User.Identity.Name;
            int SupplierId = ISupplierRepo.GetSupplierIdByName(SupplierName);
            List<SupplierMatrial> list =ISupplierMatrialRepo.GetMatrialsBySupplier(SupplierId).ToList();
            Supplier supplierModel = ISupplierRepo.GetById(SupplierId);
            ViewData["Supplier"] = supplierModel;
            TempData["List"] = list.Count;
            return View(supplierModel);
        }



        /////
        public IActionResult Edit(int id)
        {


            List<SupplierMatrial> supplierMaterialList =ISupplierMatrialRepo.GetMatrialsBySupplier(id).ToList();
            Supplier supplierToEdit = ISupplierRepo.GetById(id);
            ViewData["deptList"] = supplierMaterialList;

            return View(supplierToEdit);//View=>Edit
        }
        //Submite MEthod=post
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, Supplier supplierToEdit)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    ISupplierRepo.Update(supplierToEdit);

                    return RedirectToAction("SupplierProfile");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Name", ex.Message);
                }
            }
            List<SupplierMatrial> supplierMaterialList = ISupplierMatrialRepo.GetMatrialsBySupplier(id).ToList();
            ViewData["depts"] = supplierMaterialList;
            return View(supplierToEdit);//View Eidt
        }
        //
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveNew(Supplier newSupplier ,IFormFile logo)
        {
            if (ModelState.IsValid == true)
            {
                newSupplier.Username = TempData["UserName"].ToString();
                newSupplier.Email = TempData["Email"].ToString();
                string fileName = logo.FileName;

                fileName = Path.GetFileName(fileName);

                string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", fileName);

                var stream = new FileStream(uploadpath, FileMode.Create);

                logo.CopyToAsync(stream);
                newSupplier.logo = fileName;
                ISupplierRepo.Insert(newSupplier);
                return RedirectToAction("Index", "Home");
            }
            return View("New", newSupplier);
        }
    }
}
