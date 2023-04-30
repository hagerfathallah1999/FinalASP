using FinalASP.Models;

namespace FinalASP.Repositories
{
    public interface IReservationRepository
    {
        List<Reservation> GetAll();
        Reservation GetById(int id);
        List<Reservation> GetReservedKitchenByPhyKitchenId(int PhysicalId);

        void Insert(Reservation Reservation);
        void Update(Reservation Reservation);
        void Delete(int id);
        List<Reservation> GetReservationsByChef(int ChefId);
    }
}