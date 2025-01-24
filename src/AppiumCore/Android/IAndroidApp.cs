using OpenQA.Selenium.Appium.Android.Interfaces;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;

namespace AppiumCore.Android;
public interface IAndroidApp : IApp, IStartsActivity,
        IHasNetworkConnection, INetworkActions, IHasPerformanceData,
        ISendsKeyEvents,
        IPushesFiles
{
}
