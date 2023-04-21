using FinalASP.Models;

namespace FinalASP.Repositories
{
    public interface IReservationRepository
    {
        List<Reservation> GetAll();
        Reservation GetById(int id);
        void Insert(Reservation Reservation);
        void Update(Reservation Reservation);
        void Delete(int id);
    }
}