using Blazored.Modal;
using Blazored.Modal.Services;
using MealOrdering.Client.CustomComponents.ModalComponents;

namespace MealOrdering.Client.Utils
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
            ModalParameters modalParameters = new();
            modalParameters.Add("Message", message);
            IModalReference modalReference = _modalService.Show<ShowMessagePopupComponent>(title, modalParameters);

            if (duration > 0)
            {
                await Task.Delay(duration);
                modalReference.Close();
            }
        }
        public async Task<bool> ShowConfirmationAsync(string title, string message)
        {
            ModalParameters modalParameters = new();
            modalParameters.Add("Message", message);
            IModalReference modalReference = _modalService.Show<ConfirmationPopupComponent>(title, modalParameters);
            ModalResult result = await modalReference.Result;
            return !result.Cancelled;
        }
    }
}
