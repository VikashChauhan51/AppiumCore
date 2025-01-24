using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Enums;

namespace AppiumCore;

public interface IApp
{
     Platform Platform { get; }
     string Context { get; set; }
     string PageSource { get; }
     Uri ServiceUrl { get; }
     bool IsServerRunning { get; }
    Dictionary<string, object> Settings { get; }
    void Lock(int? seconds = null);
     void IsLocked();
     void Unlock(string key, string type);
    string GetClipboard(ClipboardContentType contentType);
    string GetClipboardText();
    void SetClipboard(ClipboardContentType contentType, string base64Content);
    void SetClipboardText(string textContent, string label = null);
     void HideKeyboard();
     bool IsKeyboardShown();
     ScreenOrientation Orientation { get; set; }
     void SwitchToWebView();
     void SwitchToNativeApp();
    void SetSetting(string setting, object value);
     IAppResult FindElement(By by);
     IReadOnlyCollection<IAppResult> FindElements(By by);
     object ExecuteScript(string command, params object[] args);
}
