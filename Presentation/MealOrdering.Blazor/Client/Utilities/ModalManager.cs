using Blazored.Modal;
using Blazored.Modal.Services;
using MealOrdering.Blazor.Client.CustomComponents.ModalComponents;


namespace MealOrdering.Client.Utilities
{
    public class ModalManager
    {
        private readonly IModalService _modalService;

        public ModalManager(IModalService modalService)
        {
            _modalService = modalService;
        }

        public async Task ShowMessageAsync(string title, string message, int duration = 0)
        {
            ModalParameters mParams = new();
            mParams.Add("message", message);
            var modalRef = _modalService.Show<ShowMessagePopupComponent>(title, mParams);

            if (duration > 0)
            {
                await Task.Delay(duration);
                modalRef.Close();
            }
        }

        public async Task<bool> ShowConfirmationAsync(string title, string message)
        {
            ModalParameters mParams = new();
            mParams.Add("message", message);
            var modalRef = _modalService.Show<ConfirmationPopupComponent>(title, mParams);
            var modalResult = await modalRef.Result;

            return !modalResult.Cancelled;
        }
    }
}
