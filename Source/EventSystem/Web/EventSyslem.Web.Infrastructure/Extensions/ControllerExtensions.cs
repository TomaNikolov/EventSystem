namespace EventSystem.Web.Infrastructure.Extensions
{
    using System.Web.Mvc;

    using Constants;
    using Notifications;

    public static class ControllerExtensions
    {
        public static ToastMessage AddToastMessage(this Controller controller, string title, string message, ToastType toastType = ToastType.Info)
        {
            Toastr toastr = controller.TempData[Notification.Toastr] as Toastr;
            toastr = toastr ?? new Toastr();

            var toastMessage = toastr.AddToastMessage(title, message, toastType);
            controller.TempData[Notification.Toastr] = toastr;
            return toastMessage;
        }
    }
}
