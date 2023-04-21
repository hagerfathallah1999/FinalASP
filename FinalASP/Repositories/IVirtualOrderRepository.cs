using FinalASP.Models;

namespace FinalASP.Repositories
{
    public interface IVirtualOrderRepository
    {
        List<VirtualOrder> GetAll();
        VirtualOrder GetById(int id);
        void Insert(VirtualOrder VirtualOrder);
        void Update(VirtualOrder VirtualOrder);
        void Delete(int id);
    }
}