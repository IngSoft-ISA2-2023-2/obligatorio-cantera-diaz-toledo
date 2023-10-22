using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using PharmaGo.BusinessLogic;
using PharmaGo.Domain.Entities;
using PharmaGo.IBusinessLogic;
using PharmaGo.WebApi.Enums;
using PharmaGo.WebApi.Filters;
using PharmaGo.WebApi.Models.In;
using PharmaGo.WebApi.Models.Out;

namespace PharmaGo.WebApi.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager manager)
        {
            _productManager = manager;
        }
        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id)
        {
            Product product = _productManager.GetById(id);
            return Ok(new ProductModelResponse(product));
        }

        [HttpGet]
        [Route("[action]")]
        [AuthorizationFilter(new string[] { nameof(RoleType.Employee) })]
        public IActionResult User()
        {
            string token = HttpContext.Request.Headers["Authorization"];
            IEnumerable<Product> products = _productManager.GetAllByUser(token);
            IEnumerable<ProductBasicModel> productsToReturn = products.Select(d => new ProductBasicModel(d));
            return Ok(productsToReturn);
        }

        [HttpPost]
        [AuthorizationFilter(new string[] { nameof(RoleType.Employee) })]
        public IActionResult CreateProduct([FromBody] ProductModelRequest productModel)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            Product productCreated = _productManager.CreatePurchase(productModel.ToEntity(), token);
            ProductModelResponse productResponse = new ProductModelResponse(productCreated);
            return Ok(productResponse);
        }

        [HttpDelete("{id}")]
        [AuthorizationFilter(new string[] { nameof(RoleType.Employee) })]
        public IActionResult Delete([FromRoute] int id)
        {
            _productManager.Delete(id);
            return Ok(true);
        }

        [HttpPut("{id}")]
        [AuthorizationFilter(new string[] { nameof(RoleType.Employee) })]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateProductModel updatedProduct)
        {
            Product product = _productManager.Update(id, updatedProduct.ToEntity());
            return Ok(new ProductDetailModel(product));
        }
    }
}
