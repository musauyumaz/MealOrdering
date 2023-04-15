using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace MealOrdering.Client.Utils
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;
        private readonly AuthenticationState anonymous;
        public AuthStateProvider(ILocalStorageService localStorageService, HttpClient httpClient)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
            anonymous = new AuthenticationState(new(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string apiToken = await _localStorageService.GetItemAsStringAsync("token");

            if (string.IsNullOrEmpty(apiToken))
                return anonymous;
            string email = await _localStorageService.GetItemAsStringAsync("email");

            ClaimsPrincipal claimsPrincipal = new(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }, "jwtAuthType"));
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", apiToken);

            return new AuthenticationState(claimsPrincipal);
        }

        public async Task NotifyUserLoginAsync(string email)
        {
            ClaimsPrincipal claimsPrincipal = new(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }, "jwtAuthType"));
            Task<AuthenticationState> authenticationState = Task.FromResult(new AuthenticationState(claimsPrincipal));
            NotifyAuthenticationStateChanged(authenticationState);
        }
        public void NotifyUserLogout()
        {
            Task<AuthenticationState> authenticationState = Task.FromResult(anonymous);
            NotifyAuthenticationStateChanged(authenticationState);
        }
    }
}
