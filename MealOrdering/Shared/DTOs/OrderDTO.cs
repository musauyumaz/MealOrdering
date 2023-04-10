namespace MealOrdering.Shared.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public Guid CreatedUserId { get; set; }
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedUserFullName { get; set; }
        public string SupplierName { get; set; }
    }
}
