using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductCategoryManagement.Application.Common.Dto;
using ProductCategoryManagement.Application.Common.Interfaces;
using ProductCategoryManagement.Application.Features.CategoryManagement.Commands.UpdateCategory;
using ProductCategoryManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoryManagement.Application.Features.ProductManagement.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductViewDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateProductCommandHandler> _logger;
        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork, ILogger<UpdateProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        public async Task<ProductViewDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await new UpdateProductCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                _logger.LogError("Validation failed while updating product. {errors}", errors);
            }

            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                _logger.LogError("The product with id: {Id} could not found.", request.Id);
                throw new ProductNotFoundException(request.Id);
            }

            var updatedProduct = _mapper.Map(request, product);

            await _productRepository.UpdateAsync(updatedProduct);
            await _unitOfWork.SaveChangesAsync();

            var viewModel = _mapper.Map<ProductViewDto>(updatedProduct);

            _logger.LogInformation("Product name is : {ProductName} has been updated successfully.", request.ProductName);

            return viewModel;
        }
    }
}
