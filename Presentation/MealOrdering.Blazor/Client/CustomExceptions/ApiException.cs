namespace MealOrdering.Blazor.Client.CustomExceptions
{
    public class ApiException : Exception
    {
        public ApiException(string message, Exception innerException) : base(message,innerException) { }
        public ApiException(string message) : base(message) { }
    }
}
