using FinalASP.Models;

namespace FinalASP.Repositories
{
    public class PhysicalOrderRepository: IPhysicalOrderRepository
    {
        CloudKitchenContext context;
        public PhysicalOrderRepository(CloudKitchenContext _context)
        {
            context = _context;
        }
        public List<PhysicalOrder> GetAll()
        {
            return context.PhysicalOrders.ToList();
        }
        public PhysicalOrder GetById(int id)
        {
            return context.PhysicalOrders.FirstOrDefault(c => c.Id == id);
        }
        public void Insert(PhysicalOrder PhysicalOrder)
        {
            context.PhysicalOrders.Add(PhysicalOrder);
            context.SaveChanges();
        }
        public void Update(PhysicalOrder PhysicalOrder)
        {
            context.Update(PhysicalOrder);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            PhysicalOrder PhysicalOrder = GetById(id);
            context.PhysicalOrders.Remove(PhysicalOrder);
            context.SaveChanges();
        }
    }
}
