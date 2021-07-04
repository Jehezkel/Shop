using System.Runtime.InteropServices;
using System.Buffers;
using System.Collections.Generic;
using AutoMapper;
using Shop.Web.Mappings;
using Shop.Web.Models;
using Shop.Web.Products.Queries.GetProducts;

namespace Shop.Web.Baskets.Queries.GetBasket
{
    public class BasketItemDTO : IMapFrom<BasketItem>
    {
        public ProductDTO Product { get; set; }
        public int Qty { get; set; }
        public decimal EntryPrice { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<BasketItem, BasketItemDTO>()
            .ForMember(d => d.Product, opt => opt.MapFrom(s => s.Product))
            .ForMember(d => d.Qty, opt => opt.MapFrom(s => s.Quantity))
            .ForMember(d => d.EntryPrice, opt => opt.MapFrom(s => s.EntryPrice));
        }

    }
    public class BasketDTO : IMapFrom<Basket>
    {
        public IList<BasketItemDTO> BasketItems { get; set; }
        public decimal TotalAmount { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Basket, BasketDTO>()
            .ForMember(d => d.BasketItems, opt => opt.MapFrom(s => s.BasketItems))
            .ForMember(d => d.TotalAmount, opt => opt.MapFrom(s => s.TotalAmount));
        }
    }
}