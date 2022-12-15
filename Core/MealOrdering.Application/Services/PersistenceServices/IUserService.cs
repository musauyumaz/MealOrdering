using MealOrdering.Application.Features.Users.DTOs;

namespace MealOrdering.Application.Services.PersistenceServices
{
    public interface IUserService
    {
        Task<ListUserDTO> GetAllUsers();
    }
}
