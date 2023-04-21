using FinalASP.Models;

namespace FinalASP.Repositories
{
    public interface IPhysicalOrderRepository
    {
        List<PhysicalOrder> GetAll();
        PhysicalOrder GetById(int id);
        void Insert(PhysicalOrder PhysicalOrder);
        void Update(PhysicalOrder PhysicalOrder);
        void Delete(int id);
    }
}