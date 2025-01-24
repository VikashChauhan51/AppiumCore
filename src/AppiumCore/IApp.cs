using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;

namespace AppiumCore;

public interface IApp : IHasSessionDetails,
        IHasLocation,
        IHidesKeyboard, IInteractsWithFiles, IFindsByFluentSelector<AppiumElement>,
        IInteractsWithApps, IRotatable, IContextAware
{
    void SwitchToWebView();
    void SwitchToNativeApp();

    Uri? ServiceUrl { get; }
    bool IsServerRunning { get; }

    AppiumElement FindElement(By by);
    ReadOnlyCollection<AppiumElement> FindElements(By by);
}
