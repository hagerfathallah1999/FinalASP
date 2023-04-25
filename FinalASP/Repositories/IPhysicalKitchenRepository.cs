using FinalASP.Models;

namespace FinalASP.Repositories
{
    public interface IPhysicalKitchenRepository
    {
        List<PhysicalKitchen> GetAll();
        PhysicalKitchen GetById(int id);
        void Insert(PhysicalKitchen PhysicalKitchen);
        void Update(PhysicalKitchen PhysicalKitchen);
        void Delete(int id);
        int GetPhyshicalIdByName(string name);
        PhysicalKitchen GetPhyshicalByName(string name);
    }
}