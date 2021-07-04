using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Shop.Web.Baskets.Queries.GetBasket;
using Shop.Web.DAL;
using Shop.Web.Models;
using Shop.Web.Services;
using Microsoft.EntityFrameworkCore;

namespace Shop.Web.Baskets.Commands.AddToBasket
{
    public class AddToBasketCommand : IRequest<BasketDTO>
    {
        public int ProductID { get; set; }
        public int Qty { get; set; }
    }
    public class AddToBasketCommandHandler : IRequestHandler<AddToBasketCommand, BasketDTO>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly CurrentUserService _currentUserService;
        private readonly ILogger _logger;

        public AddToBasketCommandHandler(AppDbContext context, IMapper mapper, CurrentUserService currentUserService, ILogger<AddToBasketCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _logger = logger;
        }


        public async Task<BasketDTO> Handle(AddToBasketCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.ProductID);
            if (product == null)
            {
                _logger.LogError("Product with specified ID({request.ProductID}) does not exist", request.ProductID);
                throw new KeyNotFoundException($"Product with specified ID({request.ProductID}) does not exist");
            }
            var userId = _currentUserService.Userid;
            //working user extract - to do create basket/add item
            var curr_userBasket = _context.Baskets.Where(b => b.AppUserId == userId).Include(i =>i.BasketItems).ThenInclude(p => p.Product).FirstOrDefault();
            if (curr_userBasket == null)
            {
                _logger.LogInformation("Basket for user not found, creating new basket.");
                curr_userBasket = new Basket { AppUserId = userId };
                _context.Baskets.Add(curr_userBasket);
            }
            var basketItem = curr_userBasket.BasketItems.Where(i => i.Product.ProductId == request.ProductID).FirstOrDefault();
            if (basketItem != null)
            {
                _logger.LogInformation("Item found already in basket - updating quantity");
                basketItem.Quantity += request.Qty;
            }
            else
            {
                _logger.LogInformation("Item not found yet - adding as new basketItem");
                curr_userBasket.BasketItems.Add(new BasketItem
                {
                    Product = product,
                    Quantity = request.Qty
                });
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<BasketDTO>(curr_userBasket);
        }

    }
}