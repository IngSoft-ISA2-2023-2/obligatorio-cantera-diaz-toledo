using PharmaGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace PharmaGo.Domain.SearchCriterias
{
    public class ProductSearchCriteria
    {
        public string? Nombre { get; set; }
        public int? PharmacyId { get; set; }

        public Expression<Func<Product, bool>> Criteria(Product product)
        {
            if (!string.IsNullOrEmpty(Nombre) && PharmacyId != null)
            {
                return d => d.Nombre == product.Nombre && d.Pharmacy == product.Pharmacy;
            }
            else if (string.IsNullOrEmpty(Nombre) && PharmacyId != null)
            {
                return d => d.Pharmacy == product.Pharmacy;
            }
            else if (!string.IsNullOrEmpty(Nombre) && PharmacyId == null)
            {
                return d => d.Nombre == product.Nombre;
            }
            else
            {
                return d => d.Nombre == d.Nombre;
            }
        }
    }
}