using FinalASP.Models;

namespace FinalASP.Repositories
{
    public class VirtualKitchenRepository: IVirtualKitchenRepository
    {
        CloudKitchenContext context;
        public VirtualKitchenRepository(CloudKitchenContext _context)
        {
            context = _context;
        }
        public List<VirtualKitchen> GetAll()
        {
            return context.VirtualKitchens.ToList();
        }
        public VirtualKitchen GetById(int id)
        {
            return context.VirtualKitchens.FirstOrDefault(c => c.Id == id);
        }
        public void Insert(VirtualKitchen VirtualKitchen)
        {
            context.VirtualKitchens.Add(VirtualKitchen);
            context.SaveChanges();
        }
        public void Update(VirtualKitchen VirtualKitchen)
        {
            context.Update(VirtualKitchen);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            VirtualKitchen VirtualKitchen = GetById(id);
            context.VirtualKitchens.Remove(VirtualKitchen);
            context.SaveChanges();
        }
        public int GetChefIdByName(string name)
        {
            return context.VirtualKitchens.FirstOrDefault(S => S.Name == name).Id;
        }
    }
}
