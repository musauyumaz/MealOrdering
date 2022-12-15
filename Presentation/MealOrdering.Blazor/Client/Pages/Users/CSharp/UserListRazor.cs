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
            HttpResponseMessage httpResponse = await _httpClient.GetAsync("api/Users/GetAllUser");
            var data = await httpResponse.Content.ReadFromJsonAsync<List<UserListJson>>();

            if (data != null)
                Console.WriteLine();
                //users = data;
        }
    }
}
