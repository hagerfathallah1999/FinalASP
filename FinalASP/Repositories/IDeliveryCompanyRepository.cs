using FinalASP.Models;

namespace FinalASP.Repositories
{
    public interface IDeliveryCompanyRepository
    {
        List<DeliveryCompany> GetAll();
        DeliveryCompany GetById(int id);
        void Insert(DeliveryCompany DeliveryCompany);
        void Update(DeliveryCompany DeliveryCompany);
        void Delete(int id);

    }
}