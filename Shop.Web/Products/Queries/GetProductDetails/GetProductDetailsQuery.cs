using AutoMapper;
using Shop.Web.DAL;
using MediatR;
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Shop.Web.Common.Exceptions;
using Shop.Web.Models;
using System.Linq;
using System.Reflection.Metadata;
using System;


namespace Shop.Web.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQuery : IRequest<ProductDetailsDTO>
    {
        public int ProductId { get; set; }
    }
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsDTO>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public GetProductDetailsQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductDetailsDTO> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.Where(p => p.ProductId == request.ProductId)
                                                .ProjectTo<ProductDetailsDTO>(_mapper.ConfigurationProvider)
                                                .FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }
            return entity;
        }
    }
}