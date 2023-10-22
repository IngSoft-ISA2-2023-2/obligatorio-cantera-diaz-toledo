using PharmaGo.Domain.Entities;

namespace PharmaGo.WebApi.Models.Out
{
    public class ProductBasicModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public PharmacyBasicModel Pharmacy { get; set; }

        public ProductBasicModel(Product product)
        {
            Id = product.Id;
            Nombre = product.Nombre;
            Precio = product.Precio;
            Descripcion = product.Descripcion;
            Pharmacy = new PharmacyBasicModel(product.Pharmacy);
        }
    }
}