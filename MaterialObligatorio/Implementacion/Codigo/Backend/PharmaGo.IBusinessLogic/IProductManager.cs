﻿using PharmaGo.Domain.Entities;
using PharmaGo.Domain.SearchCriterias;

namespace PharmaGo.IBusinessLogic
{
    public interface IProductManager
    {
        IEnumerable<Product> GetAll(ProductSearchCriteria productSearchCriteria);
        public Product CreatePurchase(Product product, string token);

        void Delete(int id);

        Product GetById(int id);

        IEnumerable<Product> GetAllByUser(string token);

        Product Update(int id, Product product);
    }
}