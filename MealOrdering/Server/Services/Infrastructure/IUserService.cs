using MealOrdering.Shared.DTOs;

namespace MealOrdering.Server.Services.Infrastructure
{
    public interface IUserService
    {
        Task<UserDTO> GetUserById(Guid id);
        Task<List<UserDTO>> GetUsers();
        Task<UserDTO> CreateUser(UserDTO userDTO);
        Task<UserDTO> UpdateUser(UserDTO userDTO);
        Task<bool> DeleteUserById(Guid id);
        Task<string> Login(string email,string password);
    }
}
