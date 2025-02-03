using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BulkyWeb.Models;
using BulkyWeb.ViewModels.Categorys;
using BulkyWeb.ViewModels.Products;

namespace BulkyWeb.ViewModels.Mappings
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryRequest, Category>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<ProductViewModel, Product>();  // Ánh xạ từ ProductViewModel -> Product
            CreateMap<Product, ProductViewModel>();  // Ánh xạ ngược từ Product -> ProductViewModel
        }
    }
}