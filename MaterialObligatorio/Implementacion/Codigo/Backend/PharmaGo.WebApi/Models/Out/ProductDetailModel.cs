using PharmaGo.Domain.Entities;
using PharmaGo.Domain.Enums;

namespace PharmaGo.WebApi.Models.Out
{
    public class ProductDetailModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public PharmacyBasicModel Pharmacy { get; set; }

        public ProductDetailModel(Product product)
        {
            Id = product.Id;
            Nombre = product.Nombre;
            Precio = product.Precio;
            Descripcion = product.Descripcion;
            Pharmacy = new PharmacyBasicModel(product.Pharmacy);
        }
    }
}
