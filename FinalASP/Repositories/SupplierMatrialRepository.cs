using FinalASP.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalASP.Repositories
{
    public class SupplierMatrialRepository : ISupplierMatrialRepository
    {
        CloudKitchenContext context;
        public SupplierMatrialRepository(CloudKitchenContext _context)
        {
            context = _context;
        }
        public List<SupplierMatrial> GetAll()
        {
            return context.SupplierMatrials.Include(S=>S.Supplier).ToList();
        }
        public SupplierMatrial GetById(int id)
        {
            return context.SupplierMatrials.Include(s => s.Supplier).FirstOrDefault(c => c.id == id);
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
        public List<SupplierMatrial> GetMatrialsBySupplier(int SupplierId)
        {
            List<SupplierMatrial> SupplierMatrials = context.SupplierMatrials.Where(e => e.SupplierId == SupplierId).ToList();
            return SupplierMatrials;
        }
        public void AddMatrialToSupplier (SupplierMatrial supplierMatrial)
        {
            context.SupplierMatrials.Add(supplierMatrial);
            context.SaveChanges();
        }
        public void SupFromQunt(SupplierMatrial SupplierMatrial)
        {
            double qun = SupplierMatrial.quantity - 1;
            SupplierMatrial.quantity = qun;
            context.Update(SupplierMatrial);
            context.SaveChanges();
        }

    }
}
