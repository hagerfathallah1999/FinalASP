using FinalASP.Models;

namespace FinalASP.Repositories
{
    public class SupplierRepository: ISupplierRepository
    {
        CloudKitchenContext context;
        public SupplierRepository(CloudKitchenContext _context)
        {
            context = _context;
        }
        public List<Supplier> GetAll()
        {
            return context.Suppliers.ToList();
        }
        public Supplier GetById(int id)
        {
            return context.Suppliers.FirstOrDefault(c => c.id == id);
        }
        public void Insert(Supplier Supplier)
        {
            context.Suppliers.Add(Supplier);
            context.SaveChanges();
        }
        public void Update(Supplier Supplier)
        {
            context.Update(Supplier);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Supplier Supplier = GetById(id);
            context.Suppliers.Remove(Supplier);
            context.SaveChanges();
        }
        public int GetSupplierIdByName(string name)
        {
            return context.Suppliers.FirstOrDefault(S => S.Username == name).id;
        }
    }
}
