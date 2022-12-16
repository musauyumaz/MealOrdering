using MealOrdering.Blazor.Client.Pages.Users.Html;
using MealOrdering.Blazor.Shared.Contracts.Users;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;

namespace MealOrdering.Blazor.Client.Pages.Users.CSharp
{
    public class UserListRazor : ComponentBase
    {

        HttpClient _httpClient = HttpClientFactory.Create();
        protected List<UserListJson> users;


        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }
        protected async Task LoadData()
        {
            _httpClient.BaseAddress = new Uri("https://localhost:7268/");
            var data = await _httpClient.GetFromJsonAsync<List<UserListJson>>("api/Users/GetAllUser");

            if (data != null)
                users = data;
                //users = data;
        }
    }
}
