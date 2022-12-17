using MealOrdering.Application.Features.Users.DTOs;

namespace MealOrdering.Blazor.Shared.Contracts.Users
{
    public class UserLoginResponseDTO
    {
        public string ApiToken { get; set; }
        public UserDTO User { get; set; }
    }
}
