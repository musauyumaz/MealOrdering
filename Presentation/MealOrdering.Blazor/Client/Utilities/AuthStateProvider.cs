using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace MealOrdering.Blazor.Client.Utilities
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly AuthenticationState anonymous;
        private readonly HttpClient _httpClient;
        public AuthStateProvider(ILocalStorageService localStorageService, HttpClient httpClient)
        {
            _localStorageService = localStorageService;
            anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string apiToken = await _localStorageService.GetItemAsStringAsync("token");
            string email = await _localStorageService.GetItemAsStringAsync("email");

            if (string.IsNullOrEmpty(apiToken))
                return anonymous;

            var claimsPrinciple = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) },"jwtAuthType"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
            return new(claimsPrinciple);
        }
        public async Task NotifyUserLogin(string email)
        {
            var claimsPrinciple = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }, "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(claimsPrinciple));
            NotifyAuthenticationStateChanged(authState);
        }
        public async Task NotifyUserLogout()
        {
            var authState = Task.FromResult(anonymous);
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
