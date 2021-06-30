using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Shop.Web.Baskets.Queries.GetBasket
{
    public class GetBasketQuery : IRequest<BasketDTO>
    {

    }
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, BasketDTO>
    {
        public Task<BasketDTO> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}