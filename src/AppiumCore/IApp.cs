using OpenQA.Selenium;

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
     void Unlock(string key, string type);
     string GetClipboardText();
     void SetClipboardText(string text, string label);
     void HideKeyboard();
     bool IsKeyboardShown();
     ScreenOrientation Orientation { get; set; }
     void SwitchToWebView();
     void SwitchToNativeApp();
     IAppResult FindElement(By by);
     IReadOnlyCollection<IAppResult> FindElements(By by);
     object ExecuteScript(string command, params object[] args);
}
