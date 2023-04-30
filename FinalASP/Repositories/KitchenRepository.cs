using FinalASP.Models;
using Microsoft.EntityFrameworkCore;

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
        public List<Kitchen> GetAllWithOwner()
        {
            return context.Kitchens.Include(P=>P.PhysicalKitchen).ToList();
        }
        public Kitchen GetById(int id)
        {
            return context.Kitchens.Include(P => P.PhysicalKitchen).FirstOrDefault(c => c.Id == id);
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
        public void ReserveThisKit(Kitchen Kitchen)
        {
            Kitchen.State = true;
            context.Update(Kitchen);
            context.SaveChanges();
        }

    }
}
