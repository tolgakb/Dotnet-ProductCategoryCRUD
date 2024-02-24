using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoryManagement.Application.Features.ProductManagement.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters.");

            RuleFor(p => p.ProductDescription)
                .NotEmpty().WithMessage("Product description is required.")
                .MaximumLength(150).WithMessage("Product description cannot exceed 150 characters.");

            RuleFor(p => p.ProductPrice)
                .NotEmpty().WithMessage("Product price is required.");

        }
    }
}
