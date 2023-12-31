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
    public class AltaProductoStepDefinitions
    {
        private ProductModelRequest productModel;
        private ProductController _productController;
        private Mock<IProductManager> _productManagerMock;
        private Pharmacy _pharmacy;
        private string token = "c80da9ed-1b41-4768-8e34-b728cae25d2f";
        private readonly ScenarioContext context;
        private readonly Product _product = new Product();

        public AltaProductoStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }


        [Given(@"el nombre del producto ""([^""]*)""")]
        public void GivenElNombreDelProducto(string p0)
        {
            _product.Nombre = p0;
            context.Set(_product, "product");
        }

        [Given(@"la descripcion ""([^""]*)""")]
        public void GivenLaDescripcion(string p0)
        {
            _product.Descripcion = p0;
            context.Set(_product, "product");
        }

        [Given(@"el precio (.*)")]
        public void GivenElPrecio(int p0)
        {
            _product.Precio = p0;
            context.Set(_product, "product");
        }

        [Then(@"se muestra en la respuesta el codigo ""([^""]*)""")]
        public void ThenSeMuestraEnLaRespuestaElCodigo(string p0)
        {
            context.Get<ObjectResult>("result").StatusCode.Should().Equals(p0);
        }


        [Then(@"se muestra el mensaje de error ""([^""]*)""")]
        public void ThenSeMuestraElMensajeDeError(string p0)
        {
            context.Get<ObjectResult>("result").ToString().Should().Equals(p0);
        }

        [When(@"se presiona el boton alta producto")]
        public void WhenSePresionaElBoton()
        {
            productModel = new ProductModelRequest()
            {
                Nombre = _product.Nombre,
                Descripcion = _product.Descripcion,
                Precio = _product.Precio,
                PharmacyName = ""
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

            _productManagerMock.Setup(x => x.CreatePurchase(It.IsAny<Product>(), token)).Returns(_product);
            var result = _productController.CreateProduct(productModel);
            context.Set(result as ObjectResult, "result");
        }
    }
}
