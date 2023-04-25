﻿using FinalASP.Models;
using FinalASP.Repositories;
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

        public SupplierController(IDeliveryCompanyRepository _DeliveryCompanyRepo, IKitchenRepository _IKitchenRepo,
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
            List<Supplier> SupplierModel = ISupplierRepo.GetAll();
            return View("Index", SupplierModel);
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