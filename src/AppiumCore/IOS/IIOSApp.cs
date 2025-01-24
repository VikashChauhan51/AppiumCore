using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.iOS.Interfaces;

namespace AppiumCore.IOS;
public interface IIOSApp : IApp, IHidesKeyboardWithKeyName,
         IPerformsTouchID, IHasClipboard,
    IHasSettings
{
    void ShakeDevice();
}
