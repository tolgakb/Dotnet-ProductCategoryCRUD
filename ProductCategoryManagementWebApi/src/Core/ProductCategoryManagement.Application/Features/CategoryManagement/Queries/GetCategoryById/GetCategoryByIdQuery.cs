using MediatR;
using ProductCategoryManagement.Application.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoryManagement.Application.Features.CategoryManagement.Queries.GetCategoryById
{
    public record GetCategoryByIdQuery(Guid Id): IRequest<CategoryViewDto>;
   
}
