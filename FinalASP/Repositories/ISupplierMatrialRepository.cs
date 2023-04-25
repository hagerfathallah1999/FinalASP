using FinalASP.Models;

namespace FinalASP.Repositories
{
    public interface ISupplierMatrialRepository
    {
        List<SupplierMatrial> GetAll();
        SupplierMatrial GetById(int id);
        void Insert(SupplierMatrial SupplierMatrial);
        void Update(SupplierMatrial SupplierMatrial);
        void Delete(int id);
        List<SupplierMatrial> GetMatrialsBySupplier(int SupplierId);
        void AddMatrialToSupplier(SupplierMatrial supplierMatrial);
    }
}