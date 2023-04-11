using MealOrdering.Shared.DTOs;
using MealOrdering.Shared.ResponseModels;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MealOrdering.Client.Pages.Users
{
    public partial class UserListProcess : ComponentBase
    {
        [Inject]
        HttpClient HttpClient { get; set; }
        protected List<UserDTO> UserList { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await LoadListAsync();
        }

        protected async Task LoadListAsync()
        {
            ServiceResponse<List<UserDTO>> serviceResponse = await HttpClient.GetFromJsonAsync<ServiceResponse<List<UserDTO>>>("api/Users/GetUsers");
            if (serviceResponse.Success)
                UserList = serviceResponse.Value;
        }
    }
}
