namespace MealOrdering.Shared.ResponseModels
{
    public class ServiceResponse<T> : BaseResponse
    {
        public T ValueModel { get; set; }
    }
}
