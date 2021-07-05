using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.Baskets.Commands.AddToBasket;
using Shop.Web.Baskets.Queries.GetBasket;

namespace Shop.Web.Controllers
{
    public class BasketController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<BasketDTO>> AddProductToBasket(AddToBasketCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet]
        public async Task<ActionResult<BasketDTO>> GetUserBasket()
        {
            return await Mediator.Send(new GetBasketQuery());
        }
    }
}