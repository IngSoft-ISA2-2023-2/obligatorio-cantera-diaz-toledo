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
    public class ModificarProductoStepDefinitions
    {
        private ProductController _productController;
        private Mock<IProductManager> _productManagerMock;
        private string token = "c80da9ed-1b41-4768-8e34-b728cae25d2f";
        private readonly ScenarioContext context;
        private Product _product;
        private UpdateProductModel _productModel;
        private Pharmacy _pharmacy;

        public ModificarProductoStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }

        [When(@"se presiona el boton modificar producto")]
        public void WhenSePresionaElBotonModificarProducto()
        {
            _product = context.Get<Product>("product");

            _productModel = new UpdateProductModel()
            {
                Nombre = _product.Nombre,
                Descripcion = _product.Descripcion,
                Precio = _product.Precio
            };

            _pharmacy = new Pharmacy() { Id = 1, Name = "pharmacy", Address = "address", Users = new List<User>() };
            _product.Pharmacy = _pharmacy;

            _productManagerMock = new Mock<IProductManager>(MockBehavior.Strict);
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["Authorization"] = token;
            _productController = new ProductController(_productManagerMock.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            _productManagerMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Product>())).Returns(_product);
            var result = _productController.Update(_product.Id, _productModel);
            context.Set(result as ObjectResult, "result");
        }
    }
}
