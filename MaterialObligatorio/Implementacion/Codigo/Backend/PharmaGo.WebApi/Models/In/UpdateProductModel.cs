using PharmaGo.Domain.Entities;
using PharmaGo.Domain.Enums;

namespace PharmaGo.WebApi.Models.In
{
    public class UpdateProductModel
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }

        public Product ToEntity()
        {
            return new Product()
            {
                Nombre = this.Nombre,
                Precio = this.Precio,
                Descripcion = this.Descripcion,           
                Pharmacy = new Pharmacy(),
            };
        }
    }
}