using FinalASP.Models;

namespace FinalASP.Repositories
{
    public class VirtualOrderRepository: IVirtualOrderRepository
    {
        CloudKitchenContext context;
        public VirtualOrderRepository(CloudKitchenContext _context)
        {
            context = _context;
        }
        public List<VirtualOrder> GetAll()
        {
            return context.VirtualOrders.ToList();
        }
        public VirtualOrder GetById(int id)
        {
            return context.VirtualOrders.FirstOrDefault(c => c.Id == id);
        }
        public void Insert(VirtualOrder VirtualOrder)
        {
            context.VirtualOrders.Add(VirtualOrder);
            context.SaveChanges();
        }
        public void Update(VirtualOrder VirtualOrder)
        {
            context.Update(VirtualOrder);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            VirtualOrder VirtualOrder = GetById(id);
            context.VirtualOrders.Remove(VirtualOrder);
            context.SaveChanges();
        }
    }
}
