using FinalASP.Models;
using static FinalASP.Repositories.DeliveryCompanyRepository;

namespace FinalASP.Repositories
{
    public class DeliveryCompanyRepository : IDeliveryCompanyRepository
    {
        CloudKitchenContext context;
        public DeliveryCompanyRepository(CloudKitchenContext _context)
        {
            context = _context;
        }
        public List<DeliveryCompany> GetAll()
        {
            return context.DeliveryCompanys.ToList();
        }
        public DeliveryCompany GetById(int id)
        {
            return context.DeliveryCompanys.FirstOrDefault(c => c.id == id);
        }
        public void Insert(DeliveryCompany DeliveryCompany)
        {
            int id = context.DeliveryCompanys.Count();
            DeliveryCompany.id = id +1;
            context.DeliveryCompanys.Add(DeliveryCompany);
            context.SaveChanges();
        }
        public void Update(DeliveryCompany DeliveryCompany)
        {
            context.Update(DeliveryCompany);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            DeliveryCompany DelDeliveryCompany = GetById(id);
            context.DeliveryCompanys.Remove(DelDeliveryCompany);
            context.SaveChanges();
        }
        public int GetDeliveryIdByName(string name)
        {
            return context.DeliveryCompanys.FirstOrDefault(S => S.Name == name).id;
        }
    }
}
