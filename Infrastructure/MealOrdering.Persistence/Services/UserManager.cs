using MealOrdering.Application.Features.Users.DTOs;
using MealOrdering.Application.Repositories.Users;
using MealOrdering.Application.Services.PersistenceServices;
using Microsoft.EntityFrameworkCore;

namespace MealOrdering.Persistence.Services
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateUser(CreateUserDTO createUserDTO)
        {
            await _userRepository.AddAsync(new() { FirstName = createUserDTO.FirstName, LastName = createUserDTO.LastName, EmailAddress = createUserDTO.EmailAddress });
            return await _userRepository.SaveAsync() > 0;
        }

        public async Task<bool> DeleteUserById(string id)
        {
            var user = await _userRepository.GetByIdAsync(id, true);
            if (user == null)
                throw new Exception("User Not Found");

            _userRepository.Remove(user);
            return await _userRepository.SaveAsync() > 0;
        }

        public async Task<List<ListUserDTO>> GetAllUsers()
        {
            List<ListUserDTO> users = await _userRepository.Table.Select(u => new ListUserDTO
            {
                Id = u.Id.ToString(),
                FullName = $"{u.FirstName} {u.LastName}",
                Email = u.EmailAddress,
                CreatedAt = u.CreatedDate,
                Status = u.IsActive
            }).ToListAsync();

            return users;
        }

        public async Task<UserDTO> GetUserById(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
                return new()
                {
                    Id = user.Id.ToString(),
                    FullName = $"{user.FirstName} {user.LastName}",
                    Email = user.EmailAddress,
                    Status = user.IsActive,
                    CreatedAt = user.CreatedDate
                };
            else
                throw new Exception("User Not Found");

        }

        public async Task<bool> UpdateUser(UpdateUserDTO updateUserDTO)
        {
            var user = await _userRepository.GetByIdAsync(updateUserDTO.Id, true);

            if (user == null)
                throw new Exception("User Not Found");

            return _userRepository.Update(user);
        }
    }
}
