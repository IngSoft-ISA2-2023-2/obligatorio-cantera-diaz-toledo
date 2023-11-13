using PharmaGo.Domain.Entities;
using PharmaGo.Domain.SearchCriterias;
using PharmaGo.Exceptions;
using PharmaGo.IBusinessLogic;
using PharmaGo.IDataAccess;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;


namespace PharmaGo.BusinessLogic
{
    public class ProductManager : IProductManager
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Pharmacy> _pharmacyRepository;
        private readonly IRepository<UnitMeasure> _unitMeasureRepository;
        private readonly IRepository<Presentation> _presentationRepository;
        private readonly IRepository<Session> _sessionRepository;
        private readonly IRepository<User> _userRepository;

        private readonly string PENDING = "Pending";
        private readonly string REJECTED = "Rejected";
        private readonly string APPROVED = "Approved";

        public ProductManager(
                                IRepository<Product> productRepository,
                                IRepository<Pharmacy> pharmacyRepository,
                                IRepository<UnitMeasure> unitMeasureRepository,
                                IRepository<Presentation> presentationRepository,
                                IRepository<Session> sessionRespository,
                                IRepository<User> userRespository)
        {
            _productRepository = productRepository;
            _pharmacyRepository = pharmacyRepository;
            _unitMeasureRepository = unitMeasureRepository;
            _presentationRepository = presentationRepository;
            _sessionRepository = sessionRespository;
            _userRepository = userRespository;
        }

        public IEnumerable<Product> GetAll(ProductSearchCriteria productSearchCriteria)
        {
            Product productToSearch = new Product();
            if (productSearchCriteria.PharmacyId == null)
            {
                productToSearch.Nombre = productSearchCriteria.Nombre;
            }
            else
            {
                Pharmacy pharmacySaved = _pharmacyRepository.GetOneByExpression(p => p.Id == productSearchCriteria.PharmacyId);
                if (pharmacySaved != null)
                {
                    productToSearch.Nombre = productSearchCriteria.Nombre;
                    productToSearch.Pharmacy = pharmacySaved;
                }
                else
                {
                    throw new ResourceNotFoundException("The pharmacy to get products of does not exist.");
                }
            }
            return _productRepository.GetAllByExpression(productSearchCriteria.Criteria(productToSearch));
        }
        public Product GetById(int id)
        {
            Product retrievedProduct = _productRepository.GetOneByExpression(d => d.Id == id);
            if (retrievedProduct == null)
            {
                throw new ResourceNotFoundException("The product does not exist.");
            }

            return retrievedProduct;
        }

        public Product CreatePurchase(Product product, string token)
        {
            if (product == null)
            {
                throw new ResourceNotFoundException("Please create a product before inserting it.");
            }

            var guidToken = new Guid(token);
            Session session = _sessionRepository.GetOneByExpression(s => s.Token == guidToken);
            var userId = session.UserId;
            User user = _userRepository.GetOneDetailByExpression(u => u.Id == userId);

            Pharmacy pharmacyOfProduct = _pharmacyRepository.GetOneByExpression(p => p.Name == user.Pharmacy.Name);
            if (pharmacyOfProduct == null)
            {
                throw new ResourceNotFoundException("The pharmacy of the product does not exist.");
            }

            if (string.IsNullOrEmpty(product.Nombre))
            {
                throw new InvalidResourceException("Empty Name");
            }
            if (string.IsNullOrEmpty(product.Descripcion))
            {
                throw new InvalidResourceException("Empty Description");
            }
            if (product.Precio == null)
            {
                throw new InvalidResourceException("Empty Price");
            }
            if (product.Descripcion.Length > 70)
            {
                throw new InvalidResourceException("Invalid Description");
            }
            if (product.Precio <= 0)
            {
                throw new InvalidResourceException("Invalid Price");
            }
            if (product.Nombre.Length > 30)
            {
                {
                    throw new InvalidResourceException("Invalid Name");
                }
            }


            var random = new System.Random();

            product.Pharmacy.Id = pharmacyOfProduct.Id;
            _productRepository.InsertOne(product);
            _productRepository.Save();

            return product;



        }

        public void Delete(int id)
        {
            var productSaved = _productRepository.GetOneByExpression(d => d.Id == id);
            if (productSaved == null)
            {
                throw new ResourceNotFoundException("The product to delete does not exist.");
            }

            _productRepository.DeleteOne(productSaved);
            _productRepository.Save();
        }
        
        public IEnumerable<Product> GetAllByUser(string token)
        {
            var guidToken = new Guid(token);
            Session session = _sessionRepository.GetOneByExpression(s => s.Token == guidToken);
            var userId = session.UserId;
            User user = _userRepository.GetOneDetailByExpression(u => u.Id == userId);
            Pharmacy pharmacy = user.Pharmacy;
            return _productRepository.GetAllByExpression(d => d.Pharmacy.Id == pharmacy.Id);
        }
        public Product Update(int id, Product updateProduct)
        {
            if (updateProduct == null)
            {
                throw new ResourceNotFoundException("The updated product is invalid.");
            }
            var productSaved = _productRepository.GetOneByExpression(d => d.Id == id);
            if (productSaved == null)
            {
                throw new ResourceNotFoundException("The product to update does not exist.");
            }
            if (updateProduct.Descripcion.Length > 70)
            {
                throw new InvalidResourceException("Invalid Description");
            }
            if (updateProduct.Precio <= 0)
            {
                throw new InvalidResourceException("Invalid Price");
            }
            if (updateProduct.Nombre.Length > 30)
            {
                throw new InvalidResourceException("Invalid Name");
            }
            productSaved.Nombre = updateProduct.Nombre;
            productSaved.Precio = updateProduct.Precio;
            productSaved.Descripcion = updateProduct.Descripcion;
            _productRepository.UpdateOne(productSaved);
            _productRepository.Save();
            return productSaved;
        }

    }
}
