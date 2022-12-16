using MealOrdering.Application.Features.Users.DTOs;

namespace MealOrdering.Application.Services.PersistenceServices
{
    public interface IUserService
    {
        Task<List<ListUserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(string id);
        Task<bool> CreateUser(CreateUserDTO createUserDTO);
        Task<bool> UpdateUser(UpdateUserDTO updateUserDTO);
        Task<bool> DeleteUserById(string id);
        Task<string> Login(string email,string password);
    }

}
