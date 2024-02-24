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

namespace ProductCategoryManagement.Application.Features.CategoryManagement.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CategoryViewDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteCategoryCommandHandler> _logger;
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork, ILogger<DeleteCategoryCommandHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<CategoryViewDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null) 
            {
                _logger.LogError("The category with id: {Id} could not found.", request.Id);
                throw new CategorytNotFoundException(request.Id);
            }

            await _categoryRepository.DeleteAsync(category);
            await _unitOfWork.SaveChangesAsync();

            var viewModel = _mapper.Map<CategoryViewDto>(category);

            _logger.LogInformation("Category id : {Id} has been deleted successfully.", request.Id);

            return viewModel;
        }
    }
}
