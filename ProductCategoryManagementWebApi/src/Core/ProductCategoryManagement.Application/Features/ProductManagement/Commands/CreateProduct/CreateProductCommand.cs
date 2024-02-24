using MediatR;
using ProductCategoryManagement.Application.Common.Dto;
using ProductCategoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoryManagement.Application.Features.ProductManagement.Commands.CreateProduct
{
    //public sealed record CreateProductCommand(
    //    string ProductName, 
    //    string ProductDescription, 
    //    decimal ProductPrice, 
    //    string ProductColor, 
    //    string CategoryName) : IRequest<CategoryViewDto>;

    public class CreateProductCommand : IRequest<ProductViewDto>
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductColor { get; set; }

        //public Guid CategoryId { get; init; }
        public string CategoryName { get; init; }
    }
}
