using System.Drawing;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;


namespace AppiumCore.Android;

public sealed class AndroidApp : AppBase, IAndroidApp
{

    private readonly AndroidDriver driver;

    public override Platform Platform => Platform.Android;

    public string CurrentActivity => driver.CurrentActivity;

    public ConnectionType ConnectionType { get => driver.ConnectionType; set => driver.ConnectionType = value; }
    public override Dictionary<string, object> Settings { get => driver.Settings; set => driver.Settings = value; }

    public AndroidApp(AppiumLocalService Service, AndroidDriver driver) : base(Service, driver)
    {
        this.driver = driver;
    }

    public AndroidApp(AndroidDriver driver) : base(driver)
    {
        this.driver = driver;
    }

    public void StartActivity(string appPackage, string appActivity, string appWaitPackage = "", string appWaitActivity = "", bool stopApp = true) =>
        driver.StartActivity(appPackage, appActivity, appWaitPackage, appWaitActivity, stopApp);

    public void StartActivityWithIntent(string appPackage, string appActivity, string intentAction, string appWaitPackage = "", string appWaitActivity = "", string intentCategory = "", string intentFlags = "", string intentOptionalArgs = "", bool stopApp = true) =>
        driver.StartActivityWithIntent(appPackage, appActivity, intentAction, appWaitPackage, appWaitActivity, intentCategory, intentFlags, intentOptionalArgs, stopApp);

    public void ToggleAirplaneMode() => driver.ToggleAirplaneMode();

    public void ToggleData() => driver.ToggleData();

    public void ToggleWifi()=> driver.ToggleWifi();

    public void ToggleLocationServices()=> driver.ToggleLocationServices();

    public void MakeGsmCall(string phoneNumber, GsmCallActions gsmCallAction)=> driver.MakeGsmCall(phoneNumber, gsmCallAction);

    public void SendSms(string phoneNumber, string message)=> driver.SendSms(phoneNumber, message); 

    public void SetGsmSignalStrength(GsmSignalStrength gsmSignalStrength)=> driver.SetGsmSignalStrength(gsmSignalStrength);

    public void SetGsmVoice(GsmVoiceState gsmVoiceState)=> driver.SetGsmVoice(gsmVoiceState);

    public override void SetClipboard(ClipboardContentType contentType, string base64Content)=> driver.SetClipboard(contentType, base64Content); 

    public override string GetClipboard(ClipboardContentType contentType)=> driver.GetClipboard(contentType);

    public override void SetClipboardText(string textContent, string label)=> driver.SetClipboardText(textContent, label);   

    public override string GetClipboardText()=> driver.GetClipboardText();

    public override void SetClipboardUrl(string url) => driver.SetClipboardUrl(url);

    public override string GetClipboardUrl()=> driver.GetClipboardUrl();

    public override void SetClipboardImage(Image image)=> driver.SetClipboardImage(image);   

    public override Image GetClipboardImage()=> driver.GetClipboardImage();

    public IList<object> GetPerformanceData(string packageName, string performanceDataType)=> driver.GetPerformanceData(packageName, performanceDataType);

    public IList<object> GetPerformanceData(string packageName, string performanceDataType, int dataReadAttempts) => driver.GetPerformanceData(packageName, performanceDataType, dataReadAttempts);

    public IList<string> GetPerformanceDataTypes()=> driver.GetPerformanceDataTypes();

    public void PressKeyCode(int keyCode, int metastate = 0)=> driver.PressKeyCode(keyCode, metastate); 
    public void PressKeyCode(KeyEvent keyEvent) => driver.PressKeyCode(keyEvent);
    public void LongPressKeyCode(KeyEvent keyEvent)=> driver.PressKeyCode(keyEvent);
    public void LongPressKeyCode(int keyCode, int metastate = 0) => driver.LongPressKeyCode(keyCode, metastate);

    public void PushFile(string pathOnDevice, string base64Data)=> driver.PushFile(pathOnDevice, base64Data);

    public void PushFile(string pathOnDevice, byte[] base64Data) => driver.PushFile(pathOnDevice, base64Data);

    public void PushFile(string pathOnDevice, FileInfo file)=> driver.PushFile(pathOnDevice, file); 

    public override void SetSetting(string setting, object value)=> driver.SetSetting(setting, value);

    public void IgnoreUnimportantViews(bool compress)=> driver.IgnoreUnimportantViews(compress);

    public void ConfiguratorSetWaitForIdleTimeout(int timeout)=> driver.ConfiguratorSetWaitForIdleTimeout(timeout);

    public void ConfiguratorSetWaitForSelectorTimeout(int timeout)=> driver.ConfiguratorSetWaitForSelectorTimeout(timeout);

    public void ConfiguratorSetScrollAcknowledgmentTimeout(int timeout)=> driver.ConfiguratorSetScrollAcknowledgmentTimeout(timeout);

    public void ConfiguratorSetKeyInjectionDelay(int delay)=> driver.ConfiguratorSetKeyInjectionDelay(delay);

    public void ConfiguratorSetActionAcknowledgmentTimeout(int timeout) => driver.ConfiguratorSetActionAcknowledgmentTimeout(timeout);
}
