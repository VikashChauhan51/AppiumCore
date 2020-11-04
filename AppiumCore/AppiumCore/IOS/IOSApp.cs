using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppiumCore.IOS
{
    public class IOSApp : IApp
    {
        public readonly IOSDriver<IOSElement> driver;
        public readonly AppiumLocalService localService;
        public IOSApp(IOSDriver<IOSElement> driver, AppiumLocalService localService)
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
        public Platform Platform => Platform.iOS;
        public string Context { get => driver.Context; set => driver.Context = value; }

        public string PageSource => driver.PageSource;

        public Uri ServiceUrl => localService.ServiceUrl;

        public bool IsServerRunning => localService.IsRunning;
        public void Lock() => driver.Lock();
        public void IsLocked() => driver.IsLocked();
        public void Unlock() => driver.Unlock();
        public string GetClipboardText() => driver.GetClipboardText();
        public void SetClipboardText(string text, string label) => driver.SetClipboardText(text, label);
        public void HideKeyboard() => driver.HideKeyboard();
        public bool IsKeyboardShown() => driver.IsKeyboardShown();
        public ScreenOrientation Orientation { get => driver.Orientation; set => driver.Orientation = value; }

        public IAppResult FindElementByAccessibilityId(string id)
        {
            var element = driver.FindElementByAccessibilityId(id);
            return iOSElementToAppResult(element);
        }

        public IAppResult FindElementById(string id)
        {
            var element = driver.FindElementById(id);
            return iOSElementToAppResult(element);
        }

        public IReadOnlyCollection<IAppResult> FindElementsByXPath(string locator)
        {
            var elements = driver.FindElementsByXPath(locator);
            return GetAppResult(elements);
        }
        public IAppResult FindElementByXPath(string locator)
        {
            var element = driver.FindElementByXPath(locator);
            return iOSElementToAppResult(element);
        }
        public IAppResult FindElementByName(string name)
        {
            var element = driver.FindElementByName(name);
            return iOSElementToAppResult(element);
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

        private IAppResult iOSElementToAppResult(IOSElement element)
        {
            if (element == null)
                return null;

            return new IOSResult(element);

        }
        private IReadOnlyCollection<IAppResult> GetAppResult(IReadOnlyCollection<IOSElement> elements)
        {
            List<IAppResult> result = new List<IAppResult>();
            if (elements != null && elements.Count > 0)
            {
                foreach (IOSElement item in elements)
                {
                    if (item != null)
                        result.Add(iOSElementToAppResult(item));
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
}
