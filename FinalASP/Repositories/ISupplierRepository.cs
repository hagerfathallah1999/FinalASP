using FinalASP.Models;

namespace FinalASP.Repositories
{
    public interface ISupplierRepository
    {
        List<Supplier> GetAll();
        Supplier GetById(int id);
        void Insert(Supplier Supplier);
        void Update(Supplier Supplier);
        void Delete(int id);
        Supplier GetSupplierByName(string name);
        int GetSupplierIdByName(string name);
        Supplier GetSupplierByName(string name);
    }
}