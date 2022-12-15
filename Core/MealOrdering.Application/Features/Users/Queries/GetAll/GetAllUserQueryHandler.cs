using MealOrdering.Application.Services.PersistenceServices;
using MediatR;

namespace MealOrdering.Application.Features.Users.Queries.GetAll
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
    {
        private IUserService _userService;

        public GetAllUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
            => new() { Users = await _userService.GetAllUsers() };

    }
}
