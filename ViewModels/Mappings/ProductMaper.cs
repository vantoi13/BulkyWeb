using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BulkyWeb.Models;
using BulkyWeb.ViewModels.Products;

namespace BulkyWeb.ViewModels.Mappings
{
    public class ProductMaper : Profile
    {
        public ProductMaper()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name));
            CreateMap<ProductRequest, Product>();
            CreateMap<ProductViewModel, Product>()
                 .ForMember(dest => dest.Category, opt => opt.Ignore()) // Bỏ qua Category để tránh lỗi ánh xạ vòng
                 .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
        }
    }
}