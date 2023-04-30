using FinalASP.Models;

namespace FinalASP.Repositories
{
    public class PhysicalKitchenRepository: IPhysicalKitchenRepository
    {
        CloudKitchenContext context;
        public PhysicalKitchenRepository(CloudKitchenContext _context)
        {
            context = _context;
        }
        public List<PhysicalKitchen> GetAll()
        {
            return context.PhysicalKitchens.ToList();
        }
        public PhysicalKitchen GetById(int id)
        {
            return context.PhysicalKitchens.FirstOrDefault(c => c.Id == id);
        }
        public void Insert(PhysicalKitchen PhysicalKitchen)
        {
            MyGeneralModel.PhyKitchenIdTracker = context.PhysicalKitchens.Count();
            PhysicalKitchen.Id = MyGeneralModel.PhyKitchenIdTracker + 1;
            context.PhysicalKitchens.Add(PhysicalKitchen);
            context.SaveChanges();
        }
        public void Update(PhysicalKitchen PhysicalKitchen)
        {
            context.Update(PhysicalKitchen);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            PhysicalKitchen PhysicalKitchen = GetById(id);
            context.PhysicalKitchens.Remove(PhysicalKitchen);
            context.SaveChanges();
        }
        public int GetPhyshicalIdByName(string name)
        {
            return context.PhysicalKitchens.FirstOrDefault(S => S.Name == name).Id;
        }
        public PhysicalKitchen GetPhyshicalByName(string name)
        {
            return context.PhysicalKitchens.FirstOrDefault(S => S.Name == name);
        }
        
    }
}
