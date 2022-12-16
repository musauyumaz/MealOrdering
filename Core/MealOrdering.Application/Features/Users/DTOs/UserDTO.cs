namespace MealOrdering.Application.Features.Users.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}
