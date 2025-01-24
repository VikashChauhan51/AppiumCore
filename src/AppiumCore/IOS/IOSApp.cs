using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;

namespace AppiumCore.IOS;

public sealed class IOSApp : IOSDriver, IIOSApp
{
    private readonly AppiumLocalService Service;
    private const string NativeApp = "NATIVE_APP";
    private const string WebApp = "WEBVIEW";
    Uri? IApp.ServiceUrl => Service?.ServiceUrl;
    bool IApp.IsServerRunning => Service?.IsRunning ?? false;


    public IOSApp(DriverOptions driverOptions) : base(driverOptions)
    {
    }

    public IOSApp(ICommandExecutor commandExecutor, DriverOptions driverOptions) : base(commandExecutor, driverOptions)
    {
    }

    public IOSApp(DriverOptions driverOptions, TimeSpan commandTimeout) : base(driverOptions, commandTimeout)
    {
    }

    public IOSApp(AppiumServiceBuilder builder, DriverOptions driverOptions) : base(builder, driverOptions)
    {
    }

    public IOSApp(Uri remoteAddress, DriverOptions driverOptions) : base(remoteAddress, driverOptions)
    {
    }

    public IOSApp(AppiumLocalService service, DriverOptions driverOptions) : base(service, driverOptions)
    {
        this.Service = service;

    }

    public IOSApp(AppiumServiceBuilder builder, DriverOptions driverOptions, TimeSpan commandTimeout) : base(builder, driverOptions, commandTimeout)
    {
    }

    public IOSApp(Uri remoteAddress, DriverOptions driverOptions, TimeSpan commandTimeout) : base(remoteAddress, driverOptions, commandTimeout)
    {
    }

    public IOSApp(AppiumLocalService service, DriverOptions driverOptions, TimeSpan commandTimeout) : base(service, driverOptions, commandTimeout)
    {
        this.Service = service;
    }

    public IOSApp(Uri remoteAddress, DriverOptions driverOptions, AppiumClientConfig clientConfig) : base(remoteAddress, driverOptions, clientConfig)
    {
    }

    public IOSApp(AppiumLocalService service, DriverOptions driverOptions, AppiumClientConfig clientConfig) : base(service, driverOptions, clientConfig)
    {
        this.Service = service;
    }

    public IOSApp(Uri remoteAddress, DriverOptions driverOptions, TimeSpan commandTimeout, AppiumClientConfig clientConfig) : base(remoteAddress, driverOptions, commandTimeout, clientConfig)
    {
    }

    public IOSApp(AppiumLocalService service, DriverOptions driverOptions, TimeSpan commandTimeout, AppiumClientConfig clientConfig) : base(service, driverOptions, commandTimeout, clientConfig)
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
