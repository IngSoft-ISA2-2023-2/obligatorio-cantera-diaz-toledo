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
    public class BajaProductoStepDefinitions
    {

        private ProductController _productController;
        private Mock<IProductManager> _productManagerMock;
        private string token = "c80da9ed-1b41-4768-8e34-b728cae25d2f";
        private readonly ScenarioContext context;
        private readonly Product _product = new Product();

        public BajaProductoStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"el id del producto (.*)")]
        public void GivenElIdDelProducto(int p0)
        {
            _product.Id = p0;
            context.Set(_product, "product");
        }

        [When(@"se presiona el boton eliminar producto")]
        public void WhenSePresionaElBoton()
        {

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

            _productManagerMock.Setup(x => x.Delete(It.IsAny<int>()));
            var result = _productController.Delete(_product.Id);
            context.Set(result as ObjectResult, "result");
        }
    }
}
