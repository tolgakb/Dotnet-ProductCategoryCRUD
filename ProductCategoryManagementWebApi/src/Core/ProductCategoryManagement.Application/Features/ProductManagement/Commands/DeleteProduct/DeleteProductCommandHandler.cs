using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductCategoryManagement.Application.Common.Dto;
using ProductCategoryManagement.Application.Common.Interfaces;
using ProductCategoryManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoryManagement.Application.Features.ProductManagement.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductViewDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteProductCommandHandler> _logger;
        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork, ILogger<DeleteProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        public async Task<ProductViewDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null) 
            {
                _logger.LogError("The product with id: {Id} could not found.", request.Id);
                throw new ProductNotFoundException(request.Id);
            }

            await _productRepository.DeleteAsync(product);
            await _unitOfWork.SaveChangesAsync();

            var viewModel = _mapper.Map<ProductViewDto>(product);

            _logger.LogInformation("Product id is : {Id} has been deleted successfully.", request.Id);

            return viewModel;
        }
    }
}
