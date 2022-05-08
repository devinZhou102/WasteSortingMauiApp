using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasteSortingMauiApp.Service
{
    public class AlertService
    {

        private static readonly Lazy<AlertService> lazy =
          new Lazy<AlertService>(() => new AlertService());

        public static AlertService Instance { get { return lazy.Value; } }
        public void Toast(string message)
        {
            UserDialogs.Instance.Toast(message);
        }

        public void DisplayAlert(string title, string content, string actionName)
        {
            UserDialogs.Instance.Alert(content, title, actionName);
        }

        public async Task<bool> ConfirmAlertAsync(string message, string title = null, string okText = null, string cancelText = null)
        {
            return await UserDialogs.Instance.ConfirmAsync(message, title, okText, cancelText);
        }

        public async Task DisplayAlertAsync(string title, string content, string actionName)
        {
            await UserDialogs.Instance.AlertAsync(content, title, actionName);
        }
    }
}
