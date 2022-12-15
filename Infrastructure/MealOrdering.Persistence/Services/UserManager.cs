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

        public async Task<ListUserDTO> GetAllUsers()
            => new()
            {
                Users = await _userRepository.Table.Select(u => new
                {
                    Id = u.Id,
                    FullName = $"{u.FirstName} {u.LastName}",
                    Email = u.EmailAddress,
                    CreatedAt = u.CreatedDate,
                    Status = u.IsActive
                }).ToListAsync()
            };

    }
}
