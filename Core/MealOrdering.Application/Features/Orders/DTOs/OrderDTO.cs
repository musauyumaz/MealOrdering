namespace MealOrdering.Application.Features.Orders.DTOs
{
    public class OrderDTO
    {
        public string Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
