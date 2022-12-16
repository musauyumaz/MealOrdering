using MealOrdering.Application.Features.Users.DTOs;

namespace MealOrdering.Application.Features.Users.Queries.GetAll
{
    public class GetAllUserQueryResponse
    {
        public List<ListUserDTO> Users { get; set; }
    }
}
