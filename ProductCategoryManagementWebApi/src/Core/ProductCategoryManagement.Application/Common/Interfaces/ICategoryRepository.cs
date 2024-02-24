using ProductCategoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoryManagement.Application.Common.Interfaces
{
    public interface ICategoryRepository : IGenericRepositoryAsync<Category>
    {
    }
}
