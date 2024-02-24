using ProductCategoryManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoryManagement.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductColor { get; set; }

        //public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        [ForeignKey("CategoryName")]
        public Category Category { get; set; }
    }
}
