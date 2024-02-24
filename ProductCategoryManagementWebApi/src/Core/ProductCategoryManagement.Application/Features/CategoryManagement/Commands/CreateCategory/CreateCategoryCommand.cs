using MediatR;
using ProductCategoryManagement.Application.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoryManagement.Application.Features.CategoryManagement.Commands.CreateCategory
{
    public sealed record CreateCategoryCommand(string CategoryName, string CategoryDescription) : IRequest<CategoryViewDto>;


    ////{
    ////    public string CategoryName { get; set; }
    ////public string CategoryDescription { get; set; }
    ////}
    ///

    //public class CreateCategoryCommand : IRequest<CategoryViewDto>
    //{
    //    public string CategoryName { get; set; }
    //    public string CategoryDescription { get; set; }
    //}
}
