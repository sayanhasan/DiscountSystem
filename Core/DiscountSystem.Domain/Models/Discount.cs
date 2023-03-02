using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountSystem.Domain.Models
{
    public class Discount : BaseEntity
    {
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal Rate { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
