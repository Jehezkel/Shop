using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop.Web.DAL;
using Shop.Web.Services;

namespace Shop.Web.Baskets.Queries.GetBasket
{
    public class GetBasketQuery : IRequest<BasketDTO>
    {

    }
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, BasketDTO>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly CurrentUserService _currentUserService;
        private readonly ILogger<GetBasketQueryHandler> _logger;

        public GetBasketQueryHandler(AppDbContext context, IMapper mapper, CurrentUserService currentUserService, ILogger<GetBasketQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _logger = logger;
        }
        public async Task<BasketDTO> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.Userid;
            var result = await _context.Baskets.Where(b => b.AppUserId == userId).ProjectTo<BasketDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            _logger.LogTrace("User {userid} basker: {basker}", userId, result);
            return result;
        }
    }
}