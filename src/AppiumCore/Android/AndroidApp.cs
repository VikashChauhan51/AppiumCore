using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;


namespace AppiumCore.Android;

public sealed class AndroidApp : AndroidDriver, IAndroidApp
{
    private readonly AppiumLocalService Service;
    private const string NativeApp = "NATIVE_APP";
    private const string WebApp = "WEBVIEW";
    Uri? IApp.ServiceUrl => Service?.ServiceUrl;
    bool IApp.IsServerRunning => Service?.IsRunning ?? false;

    public Platform Platform => Platform.Android;

    public AndroidApp(DriverOptions driverOptions) : base(driverOptions)
    {
    }

    public AndroidApp(ICommandExecutor commandExecutor, DriverOptions driverOptions) : base(commandExecutor, driverOptions)
    {
    }

    public AndroidApp(DriverOptions driverOptions, TimeSpan commandTimeout) : base(driverOptions, commandTimeout)
    {
    }

    public AndroidApp(AppiumServiceBuilder builder, DriverOptions driverOptions) : base(builder, driverOptions)
    {
    }

    public AndroidApp(Uri remoteAddress, DriverOptions driverOptions) : base(remoteAddress, driverOptions)
    {
    }

    public AndroidApp(AppiumLocalService service, DriverOptions driverOptions) : base(service, driverOptions)
    {
        this.Service = service;
    }

    public AndroidApp(AppiumServiceBuilder builder, DriverOptions driverOptions, TimeSpan commandTimeout) : base(builder, driverOptions, commandTimeout)
    {
    }

    public AndroidApp(Uri remoteAddress, DriverOptions driverOptions, TimeSpan commandTimeout) : base(remoteAddress, driverOptions, commandTimeout)
    {
    }

    public AndroidApp(AppiumLocalService service, DriverOptions driverOptions, TimeSpan commandTimeout) : base(service, driverOptions, commandTimeout)
    {
        this.Service = service;
    }

    public AndroidApp(Uri remoteAddress, DriverOptions driverOptions, AppiumClientConfig clientConfig) : base(remoteAddress, driverOptions, clientConfig)
    {
    }

    public AndroidApp(AppiumLocalService service, DriverOptions driverOptions, AppiumClientConfig clientConfig) : base(service, driverOptions, clientConfig)
    {
        this.Service = service;
    }

    public AndroidApp(Uri remoteAddress, DriverOptions driverOptions, TimeSpan commandTimeout, AppiumClientConfig clientConfig) : base(remoteAddress, driverOptions, commandTimeout, clientConfig)
    {
    }

    public AndroidApp(AppiumLocalService service, DriverOptions driverOptions, TimeSpan commandTimeout, AppiumClientConfig clientConfig) : base(service, driverOptions, commandTimeout, clientConfig)
    {
        this.Service = service;
    }
    public void SwitchToNativeApp()
    {

        // Wait for web appear
        List<string> AllContexts = [];
        foreach (var context in Contexts)
        {
            AllContexts.Add(context);
        }
        // Switch to web View
        this.Context = AllContexts.Find(stringToCheck => stringToCheck.Contains(NativeApp));
    }
    public void SwitchToWebView()
    {
        // Wait for web appear
        List<string> AllContexts = [];
        foreach (var context in Contexts)
        {

            AllContexts.Add(context);
        }
        // Switch to web View
        this.Context = AllContexts.Find(stringToCheck => stringToCheck.Contains(WebApp));
    }
}
