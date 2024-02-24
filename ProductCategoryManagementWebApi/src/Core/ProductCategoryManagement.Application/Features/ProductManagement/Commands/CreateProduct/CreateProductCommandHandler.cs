using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductCategoryManagement.Application.Common.Dto;
using ProductCategoryManagement.Application.Common.Interfaces;
using ProductCategoryManagement.Application.Features.CategoryManagement.Commands.CreateCategory;
using ProductCategoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoryManagement.Application.Features.ProductManagement.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductViewDto>
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateProductCommandHandler> _logger;
        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork, ILogger<CreateProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<ProductViewDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await new CreateProductCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                _logger.LogError("Validation failed while creating product. {errors}", errors);
            }

            var product = _mapper.Map<Product>(request);

            await _productRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            var viewModel = _mapper.Map<ProductViewDto>(product);

            _logger.LogInformation("Product name is : {ProductName} has been created successfully.", request.ProductName);

            return viewModel;
        }
    }
}
