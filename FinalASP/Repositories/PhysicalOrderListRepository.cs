using FinalASP.Models;

namespace FinalASP.Repositories
{
    public class PhysicalOrderListRepository: IPhysicalOrderListRepository
    {
        CloudKitchenContext context;
        public PhysicalOrderListRepository(CloudKitchenContext _context)
        {
            context = _context;
        }
        public List<PhysicalOrderList> GetAll()
        {
            return context.PhysicalOrderLists.ToList();
        }
        public PhysicalOrderList GetById(int id)
        {
            return context.PhysicalOrderLists.FirstOrDefault(c => c.Id == id);
        }
        public void Insert(PhysicalOrderList PhysicalOrderList)
        {
            context.PhysicalOrderLists.Add(PhysicalOrderList);
            context.SaveChanges();
        }
        public void Update(PhysicalOrderList PhysicalOrderList)
        {
            context.Update(PhysicalOrderList);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            PhysicalOrderList PhysicalOrderList = GetById(id);
            context.PhysicalOrderLists.Remove(PhysicalOrderList);
            context.SaveChanges();
        }
    }
}
