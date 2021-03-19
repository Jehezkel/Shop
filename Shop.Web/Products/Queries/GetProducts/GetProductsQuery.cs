using System.Reflection.Metadata;
using System;
using AutoMapper;
using Shop.Web.DAL;
using MediatR;
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Shop.Web.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<ProductListDTO>
    {

    }
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ProductListDTO>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductListDTO> Handle(GetProductsQuery getProductsQuery, CancellationToken cancellationToken)
        {
            return new ProductListDTO
            {
                Products = await _context.Products.ProjectTo<ProductDTO>(_mapper.ConfigurationProvider).ToListAsync()
            };
        }


    }
}