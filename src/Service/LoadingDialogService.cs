using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteSortingMauiApp.Utils;

namespace WasteSortingMauiApp.Service
{
    public class LoadingDialogService
    {

        private static readonly Lazy<LoadingDialogService> lazy =
          new Lazy<LoadingDialogService>(() => new LoadingDialogService());

        public static LoadingDialogService Instance { get { return lazy.Value; } }

        public void Loading()
        {
            if(DeviceUtil.IsUserDialogsOk())
            {
                UserDialogs.Instance.ShowLoading();
            }
        }

        public void HideLoading()
        {
            if (DeviceUtil.IsUserDialogsOk())
            {
                UserDialogs.Instance.HideLoading();
            }
        }

    }
}
