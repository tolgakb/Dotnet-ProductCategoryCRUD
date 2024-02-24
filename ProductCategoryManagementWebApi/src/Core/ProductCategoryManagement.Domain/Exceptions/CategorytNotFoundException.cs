using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoryManagement.Domain.Exceptions
{
    public sealed class CategorytNotFoundException : NotFoundException
    {
        public CategorytNotFoundException(Guid id)
            : base($"The category with id : {id} could not found.")
        {
        }
    }
}
