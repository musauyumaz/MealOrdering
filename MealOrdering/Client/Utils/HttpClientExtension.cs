using MealOrdering.Shared.CustomExceptions;
using MealOrdering.Shared.ResponseModels;
using System.Net.Http.Json;

namespace MealOrdering.Client.Utils
{
    public static class HttpClientExtension
    {
        public async static Task<T> GetServiceResponseAsync<T>(this HttpClient httpClient,string url, bool throwWhenNotSuccess = false)
        {
            ServiceResponse<T> serviceResponse = await httpClient.GetFromJsonAsync<ServiceResponse<T>>(url);

            if (!serviceResponse.Success && throwWhenNotSuccess)
                throw new ApiException(serviceResponse.Message);

            return serviceResponse.Value;
        }
    }
}
