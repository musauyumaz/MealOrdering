using MealOrdering.Blazor.Client.CustomExceptions;
using System.Net.Http.Json;

namespace MealOrdering.Blazor.Client.Utilities
{
    public static class HttpClientExtension
    {
        public static async Task<T> GetServiceResponseAsync<T>(this HttpClient httpClient, string url, bool throwWhenNotSuccess = false)
        {
            var response = await httpClient.GetFromJsonAsync<T>(url);
            if (response != null && throwWhenNotSuccess)
                throw new ApiException("Hata");

            return response;
        }
    }
}
