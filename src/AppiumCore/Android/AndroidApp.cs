using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppiumCore.Android;

public class AndroidApp : IApp
{
    public readonly AndroidDriver<AndroidElement> driver;
    public readonly AppiumLocalService localService;
    public AndroidApp(AndroidDriver<AndroidElement> driver, AppiumLocalService localService)
    {
        if (driver == null)
        {
            throw new ArgumentNullException(nameof(driver));
        }
        if (localService == null)
        {
            throw new ArgumentNullException(nameof(localService));
        }
        this.driver = driver;
        this.localService = localService;
    }

    public Platform Platform => Platform.Android;

    public string Context { get => driver.Context; set => driver.Context = value; }

    public string PageSource => driver.PageSource;

    public Uri ServiceUrl => localService.ServiceUrl;

    public bool IsServerRunning => localService.IsRunning;

    public void ToggleData() => driver.ToggleData();
    public void ToggleWifi() => driver.ToggleWifi();
    public void ToggleAirplaneMode() => driver.ToggleAirplaneMode();
    public void ToggleLocationServices() => driver.ToggleLocationServices();
    public IDictionary<string, object> GetSystemBars() => driver.GetSystemBars();
    public void Lock() => driver.Lock();
    public void IsLocked() => driver.IsLocked();
    public void Unlock() => driver.Unlock();
    public void OpenNotifications() => driver.OpenNotifications();
    public string GetClipboardText() => driver.GetClipboardText();
    public void SetClipboardText(string text, string label) => driver.SetClipboardText(text, label);
    public void SetSetting(string setting, object value) => driver.SetSetting(setting, value);
    public void HideKeyboard() => driver.HideKeyboard();
    public bool IsKeyboardShown() => driver.IsKeyboardShown();
    public ConnectionType ConnectionType => driver.ConnectionType;
    public ScreenOrientation Orientation { get => driver.Orientation; set => driver.Orientation = value; }

    public IAppResult FindElementByAccessibilityId(string id)
    {
        var element = driver.FindElementByAccessibilityId(id);
        return AndroidElementToAppResult(element);
    }

    public IAppResult FindElementById(string id)
    {
        var element = driver.FindElementById(id);
        return AndroidElementToAppResult(element);
    }

    public IReadOnlyCollection<IAppResult> FindElementsByXPath(string locator)
    {
        var elements = driver.FindElementsByXPath(locator);
        return GetAppResult(elements);
    }
    public IAppResult FindElementByXPath(string locator)
    {
        var element = driver.FindElementByXPath(locator);
        return AndroidElementToAppResult(element);
    }
    public IAppResult FindElementByName(string name)
    {
        var element = driver.FindElementByName(name);
        return AndroidElementToAppResult(element);
    }
    public void SwitchToNativeApp()
    {

        // Wait for web appear
        List<string> AllContexts = new List<string>();
        foreach (var context in (driver.Contexts))
        {
            AllContexts.Add(context);
        }
        // Switch to web View
        driver.Context = (AllContexts.FirstOrDefault(stringToCheck => stringToCheck.Contains("NATIVE_APP")));
    }

    public void SwitchToWebView()
    {
        // Wait for web appear
        List<string> AllContexts = new List<string>();
        foreach (var context in (driver.Contexts))
        {

            AllContexts.Add(context);
        }
        // Switch to web View
        driver.Context = (AllContexts.FirstOrDefault(stringToCheck => stringToCheck.Contains("WEBVIEW")));
    }

    private IAppResult AndroidElementToAppResult(AndroidElement element)
    {
        if (element == null)
            return null;

        return new AndroidResult(element);

    }
    private IReadOnlyCollection<IAppResult> GetAppResult(IReadOnlyCollection<AndroidElement> elements)
    {
        List<IAppResult> result = new List<IAppResult>();
        if (elements != null && elements.Count > 0)
        {
            foreach (AndroidElement item in elements)
            {
                if (item != null)
                    result.Add(AndroidElementToAppResult(item));
            }
        }
        return result;
    }

    public IReadOnlyCollection<IAppResult> FindElementsByAccessibilityId(string id)
    {
        var elements = driver.FindElementsByAccessibilityId(id);
        return GetAppResult(elements);
    }

    public IReadOnlyCollection<IAppResult> FindElementsById(string id)
    {
        var elements = driver.FindElementsById(id);
        return GetAppResult(elements);
    }
    public object ExecuteScript(string command, params object[] args)
    {
        return driver.ExecuteScript(command, args);
    }
}
