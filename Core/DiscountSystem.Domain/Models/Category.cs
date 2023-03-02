using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountSystem.Domain.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
