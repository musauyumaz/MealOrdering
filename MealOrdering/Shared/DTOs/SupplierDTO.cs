namespace MealOrdering.Shared.DTOs
{
    public class SupplierDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string WebURL { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
