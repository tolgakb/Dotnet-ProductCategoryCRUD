using AutoMapper;
using ProductCategoryManagement.Application.Common.Dto;
using ProductCategoryManagement.Application.Features.CategoryManagement.Commands.CreateCategory;
using ProductCategoryManagement.Application.Features.CategoryManagement.Commands.DeleteCategory;
using ProductCategoryManagement.Application.Features.CategoryManagement.Commands.UpdateCategory;
using ProductCategoryManagement.Application.Features.ProductManagement.Commands.CreateProduct;
using ProductCategoryManagement.Application.Features.ProductManagement.Commands.DeleteProduct;
using ProductCategoryManagement.Application.Features.ProductManagement.Commands.UpdateProduct;
using ProductCategoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoryManagement.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, DeleteProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();


            CreateMap<Category, CategoryViewDto>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

        }
    }
}
