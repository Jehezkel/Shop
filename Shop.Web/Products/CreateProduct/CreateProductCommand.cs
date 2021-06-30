using System.Net.Cache;
using System.Threading;
using System.Reflection.Metadata;
using System.Collections.Generic;
using MediatR;
using Shop.Web.DAL;
using Shop.Web.Models;
using System.Threading.Tasks;

namespace Shop.Web.Products.Commands.CreateProduct
{
    // public class AddedImageDTO
    // {
    //     public int ProductImageId { get; set; }
    //     public bool IsMainImage { get; set; }
    // }
    public class CreateProductCommand : IRequest<int>
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductDescription { get; set; }
        public List<ProductImage> Images { get; set; } = new List<ProductImage>();
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly AppDbContext _context;
        public CreateProductCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ProductName = request.ProductName,
                Price = request.Price
            };
            // product.ProductImages = request.Images;
            request.Images.ForEach(i =>
           {
               var currImage = _context.ProductImages.Find(i.ProductImageId);
               currImage.ImageOrder = i.ImageOrder;
               product.ProductImages.Add(currImage);
           });
            product.ProductDescription = new ProductDescription
            {
                Description = request.ProductDescription
            };
            _context.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product.ProductId;
        }
    }
}