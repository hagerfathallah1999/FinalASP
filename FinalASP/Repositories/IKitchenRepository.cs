using FinalASP.Models;

namespace FinalASP.Repositories
{
    public interface IKitchenRepository
    {
        List<Kitchen> GetAll();
        Kitchen GetById(int id);
        void Insert(Kitchen Kitchen);
        void Update(Kitchen Kitchen);
        void Delete(int id);
        List<Kitchen> GetKitchensByPhyKitchen(int PhyKitchenId);
        List<Kitchen> GetAllWithOwner();
        void ReserveThisKit(Kitchen Kitchen);
    }
}