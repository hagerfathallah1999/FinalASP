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
		public IActionResult SaveNew(PhysicalKitchen newKitchen,IFormFile LogoImage)
		{
			if (ModelState.IsValid == true)
			{
                newKitchen.Name = TempData["UserName"].ToString();
                newKitchen.Email = TempData["Email"].ToString();

                string fileName = LogoImage.FileName;

                fileName = Path.GetFileName(fileName);

                string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", fileName);

                var stream = new FileStream(uploadpath, FileMode.Create);

                LogoImage.CopyToAsync(stream);
                newKitchen.LogoImage = fileName;
                IPhysicalKitchenRepo.Insert(newKitchen);
                return RedirectToAction("Index", "Home");
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
        public async Task<IActionResult> AddKitchenToPhyKitchen(Kitchen Kitchen, IFormFile KitchenImage1, IFormFile KitchenImage2, IFormFile KitchenImage3)
        {
            string KitchenName = User.Identity.Name;
            int PhyKitchenId = IPhysicalKitchenRepo.GetPhyshicalIdByName(KitchenName);
            Kitchen.PhysicalKitchenId = PhyKitchenId;

            var files = new List<IFormFile> { KitchenImage1, KitchenImage2, KitchenImage3 };
            for (int i = 0; i < files.Count; i++)
            {
                var file = files[i];
                if (file == null)
                    continue;
                string fileName = Path.GetFileName(file.FileName);
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", fileName);
                using var stream = new FileStream(uploadPath, FileMode.Create);
                await file.CopyToAsync(stream);
                switch (i)
                {
                    case 0:
                        Kitchen.KitchenImage1 = fileName;
                        break;
                    case 1:
                        Kitchen.KitchenImage2 = fileName;
                        break;
                    case 2:
                        Kitchen.KitchenImage3 = fileName;
                        break;
                }
            }
            IKitchenRepo.Insert(Kitchen);
            return RedirectToAction("GetPhyshicalKitchens");
        }

        public IActionResult PhyKitchenProfile()
        {
            string PhyKitchenName = User.Identity.Name;
            int PhyKitchenId = IPhysicalKitchenRepo.GetPhyshicalIdByName(PhyKitchenName);
            PhysicalKitchen PhyKitchen = IPhysicalKitchenRepo.GetById(PhyKitchenId);
            ViewData["PhyKitchen"] = PhyKitchen;
            List<Kitchen> list = IKitchenRepo.GetKitchensByPhyKitchen(PhyKitchenId).ToList();
            TempData["List"] = list.Count;
            ///get of physical kitchen orders >>>>>>>
            List<PhysicalOrderList> reservations = IPhysicalOrderListRepo.GetAll().ToList();
            TempData["Num.of Orders"] = reservations.Count;
            var reservationmodel = IReservationRepo.GetReservedKitchenByPhyKitchenId(PhyKitchenId);
            TempData["Num.of Reserved Kitchens"] = reservationmodel.Count;
            return View(PhyKitchen);
        }
        public IActionResult GetReservedKitchenByPhyKitchenId()
        {
            string PhyKitchenName = User.Identity.Name;
            int PhysicalKitchenId = IPhysicalKitchenRepo.GetPhyshicalIdByName(PhyKitchenName);
            

            var reservationmodel = IReservationRepo.GetReservedKitchenByPhyKitchenId(PhysicalKitchenId);

            return View(reservationmodel);
        }
        public IActionResult Edit(int id)
        {
            PhysicalKitchen PhysicalkitchenToEdit = IPhysicalKitchenRepo.GetById(id);
            return View(PhysicalkitchenToEdit);//View=>Edit
        }
        //Submite MEthod=post
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, PhysicalKitchen PhysicalkitchenToEdit, IFormFile LogoImage)
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
                    PhysicalkitchenToEdit.LogoImage = fileName;
                    IPhysicalKitchenRepo.Update(PhysicalkitchenToEdit);

                    return RedirectToAction("PhyKitchenProfile");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Name", ex.Message);
                }
            }
   
            return View(PhysicalkitchenToEdit);//View Eidt
        }
    }
}
