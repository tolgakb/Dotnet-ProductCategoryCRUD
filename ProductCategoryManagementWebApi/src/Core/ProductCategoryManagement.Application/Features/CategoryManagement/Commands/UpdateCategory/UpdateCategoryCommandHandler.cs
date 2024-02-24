using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductCategoryManagement.Application.Common.Dto;
using ProductCategoryManagement.Application.Common.Interfaces;
using ProductCategoryManagement.Application.Features.CategoryManagement.Commands.CreateCategory;
using ProductCategoryManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoryManagement.Application.Features.CategoryManagement.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryViewDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateCategoryCommandHandler> _logger;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork, ILogger<UpdateCategoryCommandHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        public async Task<CategoryViewDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            var validationResult = await new UpdateCategoryCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                _logger.LogError("Validation failed while updating category. {errors}", errors);
            }

            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                _logger.LogError("The category with id: {Id} could not found.", request.Id);
                throw new CategorytNotFoundException(request.Id);
            }

            var updatedCategory = _mapper.Map(request, category);

            await _categoryRepository.UpdateAsync(updatedCategory);

            await _unitOfWork.SaveChangesAsync();

            var viewModel = _mapper.Map<CategoryViewDto>(updatedCategory);

            _logger.LogInformation("Category name : {CategoryName} has been updated successfully.", request.CategoryName);

            return viewModel;
        }
    }
}
