using FinalASP.Models;

namespace FinalASP.Repositories
{
    public interface IPhysicalOrderListRepository
    {
        List<PhysicalOrderList> GetAll();
        PhysicalOrderList GetById(int id);
        void Insert(PhysicalOrderList PhysicalOrderList);
        void Update(PhysicalOrderList PhysicalOrderList);
        void Delete(int id);
    }
}