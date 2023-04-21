using FinalASP.Models;

namespace FinalASP.Repositories
{
    public class ReservationRepository: IReservationRepository
    {
        CloudKitchenContext context;
        public ReservationRepository(CloudKitchenContext _context)
        {
            context = _context;
        }
        public List<Reservation> GetAll()
        {
            return context.Reservations.ToList();
        }
        public Reservation GetById(int id)
        {
            return context.Reservations.FirstOrDefault(c => c.id == id);
        }
        public void Insert(Reservation Reservation)
        {
            context.Reservations.Add(Reservation);
            context.SaveChanges();
        }
        public void Update(Reservation Reservation)
        {
            context.Update(Reservation);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Reservation Reservation = GetById(id);
            context.Reservations.Remove(Reservation);
            context.SaveChanges();
        }
    }
}
