using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PharmaGo.Domain.Entities;
using PharmaGo.IBusinessLogic;
using PharmaGo.WebApi.Controllers;
using PharmaGo.WebApi.Models.In;
using System;
using TechTalk.SpecFlow;

namespace PharmaGo.Sepc.StepDefinitions
{
    [Binding]
    public class ComprarProductoStepDefinitions
    {
        private PurchasesController _purchasesController;
        private Mock<IPurchasesManager> _purchasesManagerMock;
        private readonly ScenarioContext context;
        private Product _product;
        private Pharmacy _pharmacy = new Pharmacy();
        private Purchase _purchase;
        private List<PurchaseDetailProduct> _purchaseDetail;
        private PurchaseModelRequest _purchaseModelRequest;
        private ICollection<PurchaseModelRequest.PurchaseDetailProductModelRequest> _purchaseModelDetailRequest;

        public ComprarProductoStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"el id de la farmacia (.*)")]
        public void GivenElIdDeLaFarmacia(int p0)
        {
            _pharmacy.Id = p0;
            context.Set(_pharmacy, "pharmacy");
        }

        [When(@"se presiona el boton comprar producto")]
        public void WhenSePresionaElBotonComprarProducto()
        {
            _product = context.Get<Product>("product");

            _purchaseDetail = new List<PurchaseDetailProduct> {
                new PurchaseDetailProduct{Id = _product.Id, Quantity = 1, Price = new decimal(100), Product = _product, Pharmacy = _pharmacy, Status = "Pending"}
            };

            _purchase = new Purchase
            {
                Id = 1,
                BuyerEmail = "roberto.perez@gmail.com",
                PurchaseDate = new DateTime(2022, 09, 19, 14, 34, 44),
                TotalAmount = new decimal(450),
                TrackingCode = "FROR7HWPUH5JWW4C",
                detailsProduct = _purchaseDetail
            };

            ICollection<PurchaseModelRequest.PurchaseDetailProductModelRequest> _purchaseModelDetailRequest =
                new List<PurchaseModelRequest.PurchaseDetailProductModelRequest>
            {
                new PurchaseModelRequest.PurchaseDetailProductModelRequest { Id = _product.Id, Quantity = 1, PharmacyId = _pharmacy.Id },
            };

            _purchaseModelRequest = new PurchaseModelRequest()
            {
                BuyerEmail = "roberto.perez@gmail.com",
                PurchaseDate = new DateTime(2022, 09, 19, 14, 34, 44),
                DetailsProduct = _purchaseModelDetailRequest,
                Details = new List<PurchaseModelRequest.PurchaseDetailModelRequest>()
            };

            _pharmacy = new Pharmacy() { Id = 1, Name = "pharmacy", Address = "address", Users = new List<User>() };
            _product.Pharmacy = _pharmacy;

            _purchasesManagerMock = new Mock<IPurchasesManager>(MockBehavior.Strict);
            _purchasesController = new PurchasesController(_purchasesManagerMock.Object);

            _purchasesManagerMock.Setup(x => x.CreatePurchase(It.IsAny<Purchase>())).Returns(_purchase);
            var result = _purchasesController.CreatePurchase(_purchaseModelRequest);
            context.Set(result as ObjectResult, "result");
        }
    }
}
