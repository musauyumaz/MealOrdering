namespace MealOrdering.Shared.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
