﻿using FinalASP.Models;

namespace FinalASP.Repositories
{
    public class SupplierMatrialRepository
    {
        CloudKitchenContext context;
        public SupplierMatrialRepository(CloudKitchenContext _context)
        {
            context = _context;
        }
        public List<SupplierMatrial> GetAll()
        {
            return context.SupplierMatrials.ToList();
        }
        public SupplierMatrial GetById(int id)
        {
            return context.SupplierMatrials.FirstOrDefault(c => c.id == id);
        }
        public void Insert(SupplierMatrial SupplierMatrial)
        {
            context.SupplierMatrials.Add(SupplierMatrial);
            context.SaveChanges();
        }
        public void Update(SupplierMatrial SupplierMatrial)
        {
            context.Update(SupplierMatrial);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            SupplierMatrial SupplierMatrial = GetById(id);
            context.SupplierMatrials.Remove(SupplierMatrial);
            context.SaveChanges();
        }
    }
}