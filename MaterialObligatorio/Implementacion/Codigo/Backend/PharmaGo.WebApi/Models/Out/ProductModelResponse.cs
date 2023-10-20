using PharmaGo.Domain.Entities;

namespace PharmaGo.WebApi.Models.Out
{
    public class ProductModelResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public PharmacyBasicModel Pharmacy { get; set; }

        public ProductModelResponse(Product product)
        {
            Id = product.Id;
            Nombre = product.Nombre;
            Descripcion = product.Descripcion;
            Precio = product.Precio;
            Pharmacy = new PharmacyBasicModel(product.Pharmacy);
        }
    }
}
