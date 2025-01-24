using System.Drawing;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;

namespace AppiumCore.IOS;

public sealed class IOSApp : AppBase, IIOSApp
{
    private readonly IOSDriver driver;

    public override Platform Platform => Platform.iOS;

    public override Dictionary<string, object> Settings { get => driver.Settings; set => driver.Settings = value; }

    public IOSApp(AppiumLocalService Service, IOSDriver driver) : base(Service, driver)
    {
        this.driver = driver;
    }


    public IOSApp(IOSDriver driver) : base(driver)
    {
        this.driver = driver;
    }

    public void ShakeDevice() => driver.ShakeDevice();

    public void PerformTouchID(bool match) => driver.PerformTouchID(match);

    public override void SetClipboard(ClipboardContentType contentType, string base64Content) => driver.SetClipboard(contentType, base64Content);

    public override string GetClipboard(ClipboardContentType contentType) => driver.GetClipboard(contentType);

    public override void SetClipboardText(string textContent, string label) => driver.SetClipboardText(textContent, label);

    public override string GetClipboardText() => driver.GetClipboardText();

    public override void SetClipboardUrl(string url) => driver.SetClipboardUrl(url);

    public override string GetClipboardUrl() => driver.GetClipboardUrl();

    public override void SetClipboardImage(Image image) => driver.SetClipboardImage(image);

    public override Image GetClipboardImage() => driver.GetClipboardImage();
    public override void SetSetting(string setting, object value) => driver.SetSetting(setting, value);


}
