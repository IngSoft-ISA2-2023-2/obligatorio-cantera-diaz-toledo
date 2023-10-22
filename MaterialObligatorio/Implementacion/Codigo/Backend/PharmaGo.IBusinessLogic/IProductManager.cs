using PharmaGo.Domain.Entities;

namespace PharmaGo.IBusinessLogic
{
    public interface IProductManager
    {
        public Product CreatePurchase(Product product, string token);

        void Delete(int id);

        Product GetById(int id);

        IEnumerable<Product> GetAllByUser(string token);
    }
}