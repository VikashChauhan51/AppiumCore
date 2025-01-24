﻿using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;


namespace AppiumCore.Android;

public sealed class AndroidApp : IApp
{
    public readonly AndroidDriver driver;
    public readonly AppiumLocalService localService;
    public AndroidApp(AndroidDriver driver, AppiumLocalService localService)
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
    public void Unlock(string key, string type) => driver.Unlock(key, type);
    public void OpenNotifications() => driver.OpenNotifications();
    public string GetClipboardText() => driver.GetClipboardText();
    public void SetClipboardText(string textContent, string label) => driver.SetClipboardText(textContent, label);
    public void SetSetting(string setting, object value) => driver.SetSetting(setting, value);
    public void HideKeyboard() => driver.HideKeyboard();
    public bool IsKeyboardShown() => driver.IsKeyboardShown();
    public ConnectionType ConnectionType => driver.ConnectionType;
    public ScreenOrientation Orientation { get => driver.Orientation; set => driver.Orientation = value; }

    public Dictionary<string, object> Settings => driver.Settings;

    public IAppResult FindElement(By by)
    {
        var element = driver.FindElement(by);
        return AndroidElementToAppResult(element);
    }

    public IReadOnlyCollection<IAppResult> FindElements(By by)
    {
        var elements = driver.FindElements(by);
        return GetAppResult(elements);
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

    public void Lock(int? seconds = null) => driver.Lock(seconds);
    public string GetClipboard(ClipboardContentType contentType) => driver.GetClipboard(contentType);
    public void SetClipboard(ClipboardContentType contentType, string base64Content) => driver.SetClipboard(contentType, base64Content);
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

    private IAppResult AndroidElementToAppResult(AppiumElement element)
    {
        if (element == null)
            return null;

        return new AndroidResult(element);

    }
    private IReadOnlyCollection<IAppResult> GetAppResult(IReadOnlyCollection<AppiumElement> elements)
    {
        List<IAppResult> result = new List<IAppResult>();
        if (elements != null && elements.Count > 0)
        {
            foreach (AppiumElement item in elements)
            {
                if (item != null)
                    result.Add(AndroidElementToAppResult(item));
            }
        }
        return result;
    }


    public object ExecuteScript(string command, params object[] args)
    {
        return driver.ExecuteScript(command, args);
    }
}
