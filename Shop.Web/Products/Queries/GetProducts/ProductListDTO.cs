using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Shop.Web.Mappings;
using Shop.Web.Models;

namespace Shop.Web.Products.Queries.GetProducts
{
    public class ProductDTO : IMapFrom<Product>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductImage { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDTO>().ForMember(d => d.ProductImage, opt => opt.MapFrom(s => s.ProductImages.FirstOrDefault().fullFilePath));
        }
    }
    public class ProductListDTO
    {
        public IList<ProductDTO> Products { get; set; }
    }
}