namespace MealOrdering.Shared.DTOs
{
    public class UserLoginResponseDTO
    {
        public string ApiToken { get; set; }
        public UserDTO User { get; set; }
    }
}
