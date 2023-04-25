using FinalASP.Models;

namespace FinalASP.Repositories
{
    public class KitchenRepository : IKitchenRepository
    {
        CloudKitchenContext context;
        public KitchenRepository(CloudKitchenContext _context)
        {
            context = _context;
        }
        public List<Kitchen> GetAll()
        {
            return context.Kitchens.ToList();
        }
        public Kitchen GetById(int id)
        {
            return context.Kitchens.FirstOrDefault(c => c.Id == id);
        }
        public void Insert(Kitchen Kitchen)
        {
            context.Kitchens.Add(Kitchen);
            context.SaveChanges();
        }
        public void Update(Kitchen Kitchen)
        {
            context.Update(Kitchen);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Kitchen Kitchen = GetById(id);
            context.Kitchens.Remove(Kitchen);
            context.SaveChanges();
        }
        public List<Kitchen> GetKitchensByPhyKitchen(int PhyKitchenId)
        {
            List<Kitchen> Kitchens = context.Kitchens.Where(e => e.PhysicalKitchenId == PhyKitchenId).ToList();
            return Kitchens;
        }
        
    }
}
