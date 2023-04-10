namespace MealOrdering.Shared.DTOs
{
    public class OrderItemDTO
    {
        public Guid Id { get; set; }
        public Guid CreatedUserId { get; set; }
        public Guid OrderId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUserFullName { get; set; }
        public bool IsActive { get; set; }
        public string OrderName { get; set; }
    }
}
