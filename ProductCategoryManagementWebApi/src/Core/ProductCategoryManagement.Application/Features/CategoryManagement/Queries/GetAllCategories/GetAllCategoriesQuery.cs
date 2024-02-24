using MediatR;
using ProductCategoryManagement.Application.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoryManagement.Application.Features.CategoryManagement.Queries.GetAllCategories
{
    public record GetAllCategoriesQuery() : IRequest<List<CategoryViewDto>>;
    
    
}
