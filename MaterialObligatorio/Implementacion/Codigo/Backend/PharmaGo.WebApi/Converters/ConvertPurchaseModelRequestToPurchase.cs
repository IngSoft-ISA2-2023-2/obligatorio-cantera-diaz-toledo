using PharmaGo.Domain.Entities;
using PharmaGo.WebApi.Models.In;

namespace PharmaGo.WebApi.Converters
{
    public class PurchaseModelRequestToPurchaseConverter
    {

        public Purchase Convert(PurchaseModelRequest model)
        {

            var purchase = new Purchase();
            purchase.PurchaseDate = model.PurchaseDate;
            purchase.BuyerEmail = model.BuyerEmail;
            purchase.details = new List<PurchaseDetail>();
            purchase.detailsProduct = new List<PurchaseDetailProduct>();
            foreach (var detail in model.Details)
            {
                purchase.details
                    .Add(new PurchaseDetail
                    {
                        Quantity = detail.Quantity,
                        Drug = new Drug { Code = detail.Code },
                        Pharmacy = new()
                        {
                            Id = detail.PharmacyId
                        }
                    });
            }

            foreach (var detail in model.DetailsProduct)
            {
                purchase.detailsProduct
                    .Add(new PurchaseDetailProduct
                    {
                        Quantity = detail.Quantity,
                        Product = new Product { Id = detail.Id },
                        Pharmacy = new()
                        {
                            Id = detail.PharmacyId
                        }
                    });
            }

            return purchase;
        }

    }
}
