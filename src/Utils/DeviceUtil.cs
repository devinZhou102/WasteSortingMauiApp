using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasteSortingMauiApp.Utils
{
    internal class DeviceUtil
    {

        public static Boolean IsUserDialogsOk()
        {
            DevicePlatform platform = DeviceInfo.Platform;
            return platform == DevicePlatform.Android || platform == DevicePlatform.iOS || platform == DevicePlatform.MacCatalyst;
        }

    }
}
