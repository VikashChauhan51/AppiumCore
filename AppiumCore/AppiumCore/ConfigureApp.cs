using AppiumCore.Android;
using AppiumCore.IOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppiumCore
{
    public static class ConfigureApp
    {
        public static AndroidConfiguration Android
        {
            get
            {
                return new AndroidConfiguration();
            }
        }

        public static IOSConfiguration iOS
        {
            get
            {
                return new IOSConfiguration();
            }
        }
    }
}
