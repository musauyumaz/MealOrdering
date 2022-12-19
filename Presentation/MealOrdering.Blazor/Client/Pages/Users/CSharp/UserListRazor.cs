using MealOrdering.Blazor.Client.CustomExceptions;
using MealOrdering.Blazor.Client.Utilities;
using MealOrdering.Blazor.Shared.Contracts.Users;
using MealOrdering.Client.Utilities;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MealOrdering.Blazor.Client.Pages.Users.CSharp
{
    public class UserListRazor : ComponentBase
    {

        HttpClient _httpClient = HttpClientFactory.Create();
        protected List<UserListJson> users;

        [Inject]
        ModalManager ModalManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }
        protected async Task LoadData()
        {
            _httpClient.BaseAddress = new Uri("https://localhost:7268/");
            try
            {
                users = await _httpClient.GetServiceResponseAsync<List<UserListJson>>("api/Users/GetAllUser", true);
            }
            catch (Exception ex)
            {
                await ModalManager.ShowMessageAsync("Hata!", ex.Message);
            }

           

        }
    }
}
