using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Shop.Web.Products.Queries.GetProducts;
using Shop.Web.Products.Commands.CreateProduct;
using Shop.Web.Products.Queries.GetProductDetails;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Web.Controllers
{
    [Authorize]
    public class ProductsController : ApiControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ProductListDTO>> GetProducts()
        {
            return await Mediator.Send(new GetProductsQuery());
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailsDTO>> GetProductDetail(int id)
        {
            return await Mediator.Send(new GetProductDetailsQuery
            {
                ProductId = id
            });
        }


    }
}