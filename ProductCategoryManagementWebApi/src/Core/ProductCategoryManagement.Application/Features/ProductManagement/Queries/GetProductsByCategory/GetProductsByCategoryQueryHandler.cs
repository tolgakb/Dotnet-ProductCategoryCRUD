using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductCategoryManagement.Application.Common.Dto;
using ProductCategoryManagement.Application.Common.Interfaces;
using ProductCategoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoryManagement.Application.Features.ProductManagement.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategory, List<ProductViewDto>>
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;
        private readonly ILogger<GetProductsByCategoryQueryHandler> _logger;
        public GetProductsByCategoryQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetProductsByCategoryQueryHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<List<ProductViewDto>> Handle(GetProductsByCategory request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsByCategory(request.categoryName);

            var viewModel = _mapper.Map<List<ProductViewDto>>(products);

            _logger.LogInformation("Products name are : {categoryName} have been been successfully received according to category name.", request.categoryName);

            return viewModel;
        }
    }
}
