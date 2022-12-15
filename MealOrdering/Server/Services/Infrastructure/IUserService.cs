using MealOrdering.Shared.DTO;

namespace MealOrdering.Server.Services.Infrastructure
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserById(Guid id);
        public Task<List<UserDTO>> GetUsers();
        public Task<UserDTO> CreateUser(UserDTO userDTO);
        public Task<UserDTO> UpdateUser(UserDTO userDTO);
        public Task<bool> DeleteUserById(Guid id);
    }
}
