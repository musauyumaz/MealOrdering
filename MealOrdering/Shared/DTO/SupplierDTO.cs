namespace MealOrdering.Shared.DTO
{
    public class SupplierDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string WebURL { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }

    }
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public Guid SupplierId { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }

        public string UserFullName { get; set; }
        public string SupplierName { get; set; }


    }
    public class OrderItemDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SupplierId { get; set; }
        public Guid OrderId { get; set; }
        public string Description { get; set; }

        public string OrderName { get; set; }
        public string UserFullName { get; set; }

    }
}
