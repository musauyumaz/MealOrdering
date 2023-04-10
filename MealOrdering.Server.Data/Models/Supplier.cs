namespace MealOrdering.Server.Data.Models
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string WebURL { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
