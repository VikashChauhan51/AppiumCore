using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace AppiumCore;

public interface IApp
{
     Platform Platform { get; }
     string Context { get; set; }
     string PageSource { get; }
     Uri ServiceUrl { get; }
     bool IsServerRunning { get; }
     void Lock();
     void IsLocked();
     void Unlock();
     string GetClipboardText();
     void SetClipboardText(string text, string label);
     void HideKeyboard();
     bool IsKeyboardShown();
     ScreenOrientation Orientation { get; set; }
     void SwitchToWebView();
     void SwitchToNativeApp();
     IAppResult FindElementByAccessibilityId(string id);
     IAppResult FindElementById(string id);
     IAppResult FindElementByXPath(string locator);
     IAppResult FindElementByName(string name);
     IReadOnlyCollection<IAppResult> FindElementsByAccessibilityId(string id);
     IReadOnlyCollection<IAppResult> FindElementsById(string id);
     IReadOnlyCollection<IAppResult> FindElementsByXPath(string locator);
     object ExecuteScript(string command, params object[] args);
}
