using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shop.Web.Baskets.Queries.GetBasket;
using Shop.Web.DAL;
using Shop.Web.Models;
using Shop.Web.Services;

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
        public AddToBasketCommandHandler(AppDbContext context, IMapper mapper, CurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }


        public async Task<BasketDTO> Handle(AddToBasketCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.ProductID);
            var userId = _currentUserService.Userid;
            //working user extract - to do create basket/add item
            throw new System.NotImplementedException();
        }
    }
}