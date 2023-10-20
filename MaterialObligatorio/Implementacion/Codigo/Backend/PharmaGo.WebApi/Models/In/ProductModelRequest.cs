using PharmaGo.Domain.Entities;

namespace PharmaGo.WebApi.Models.In
{
    public class ProductModelRequest
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public string PharmacyName { get; set; }


        public Product ToEntity()
        {
            return new Product()
            {
                Nombre = this.Nombre,
                Descripcion = this.Descripcion,
                Precio = this.Precio,
                Pharmacy = new Pharmacy() { Name = this.PharmacyName }
            };
        }
    }
}
