using MealOrdering.Server.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealOrdering.Server.Data.Models
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }

        public virtual User User { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
