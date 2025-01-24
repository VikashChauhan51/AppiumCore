using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.VirtualAuth;

namespace AppiumCore;

public interface IApp : IHasSessionDetails,
        IHasLocation,
        IHidesKeyboard, IInteractsWithFiles,
    IFindsByFluentSelector<AppiumElement>,
    IInteractsWithApps, IRotatable, IContextAware,
    IWebDriver,
    IJavaScriptExecutor, IFindsElement,
    ITakesScreenshot, ISupportsPrint,
    IActionExecutor, IAllowsFileDetection,
    IHasCapabilities, IHasCommandExecutor,
    IHasSessionId,
    ICustomDriverCommandExecutor,
    IHasVirtualAuthenticator

{
    void SwitchToWebView();
    void SwitchToNativeApp();
    Platform Platform { get; }
    Uri? ServiceUrl { get; }
    bool IsServerRunning { get; }
    new AppiumElement FindElement(By by);
    new ReadOnlyCollection<AppiumElement> FindElements(By by);


    void SetClipboard(ClipboardContentType contentType, string base64Content);

    string GetClipboard(ClipboardContentType contentType);

    void SetClipboardText(string textContent, string label);


    string GetClipboardText();

    void SetClipboardUrl(string url);

    string GetClipboardUrl();

    void SetClipboardImage(Image image);

    Image GetClipboardImage();
    void SetSetting(string setting, object value);

    Dictionary<string, object> Settings { set; get; }

}
