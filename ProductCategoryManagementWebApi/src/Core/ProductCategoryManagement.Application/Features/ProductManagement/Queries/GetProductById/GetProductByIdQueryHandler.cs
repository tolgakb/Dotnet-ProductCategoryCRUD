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

namespace ProductCategoryManagement.Application.Features.ProductManagement.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductViewDto>
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;
        private readonly ILogger<GetProductByIdQueryHandler> _logger;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetProductByIdQueryHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductViewDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                _logger.LogError("The product with id: {Id} could not found.", request.Id);
                throw new ProductNotFoundException(request.Id);
            }

            var viewModel = _mapper.Map<ProductViewDto>(product);

            _logger.LogInformation("Product id is : {Id} has been been successfully received according to id number.", request.Id);

            return viewModel;
        }
    }
}
