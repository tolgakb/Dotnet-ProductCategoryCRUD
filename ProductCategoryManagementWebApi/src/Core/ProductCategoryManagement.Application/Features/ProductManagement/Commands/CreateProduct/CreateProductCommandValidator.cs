using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoryManagement.Application.Features.ProductManagement.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters.");

            RuleFor(p => p.ProductDescription)
                .NotEmpty().WithMessage("Product description is required.")
                .MaximumLength(150).WithMessage("Product description cannot exceed 150 characters.");

            RuleFor(p => p.ProductPrice)
                .NotEmpty().WithMessage("Product price is required.");

            RuleFor(p => p.CategoryName)
                .NotEmpty().WithMessage("Category name is required.");
        }
    }
}
