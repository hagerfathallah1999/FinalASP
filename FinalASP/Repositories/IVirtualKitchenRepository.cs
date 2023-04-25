using FinalASP.Models;

namespace FinalASP.Repositories
{
    public interface IVirtualKitchenRepository
    {
        List<VirtualKitchen> GetAll();
        VirtualKitchen GetById(int id);
        void Insert(VirtualKitchen VirtualKitchen);
        void Update(VirtualKitchen VirtualKitchen);
        void Delete(int id);
        int GetChefIdByName(string name);
    }
}