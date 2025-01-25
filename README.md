# AppiumCore

![Appium](appium-logo-horiz.png)
      
![AppiumCore](icon.png)

This is a [Appium](https://appium.io/docs/en/latest/) client wrapper to test cross platform mobile application with same code base using C#.


## Quick Start Example (Nunit Framework):

```C#

using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using AppiumCore;

[TestFixture(Platform.iOS)]
[TestFixture(Platform.Android)]
public class AppSetupTest
{
    private readonly IApp app;
    public AppSetupTest(Platform platform)
    {
        switch (platform)
        {
            case Platform.Android:
                // update `AppiumOptions` and `AppiumLocalService` as per you requirment.
                app = ConfigureApp.Android.StartApp(new AppiumOptions(), AppiumLocalService.BuildDefaultService());
                break;
            case Platform.iOS:
                // update `AppiumOptions` and `AppiumLocalService` as per you requirment.
                app = ConfigureApp.iOS.StartApp(new AppiumOptions(), AppiumLocalService.BuildDefaultService());
                break;
            default:
                break;
        }


    }

   [Test]
    public void SampleTest()
    {
        app.FindElement(By.Id("app")).Click();
        Assert.Pass();
    }
}

```

*Here `SampleTest()` will execute on both `iOS` and `Android`, and `app.FindElement(By.Id("app")).Click()` will internally switch to the respective driver as we configured at startup.*

This will reduce your codebase size and maintenance cost. 😊


We have three interfaces: `IApp`, `IAndroidApp`, and `IIOSApp`. The `IApp` interface provides common APIs available in the Appium driver for both platforms, and the platform-specific interfaces provide complete platform-specific APIs available in the respective platform-specific drivers.


Please use `AppiumLocalService` at startup if your mobile app is hybrid, where the application redirects to a web browser for functionalities like signup/sign-in. In this case, the app will switch from Native view to Web view. We have also added an additional APIs(`SwitchToWebView()` and `SwitchToNativeApp()`) to handle this in your script before calling any action method of the APIs. For documentation, please refer to their official documentation, as linked below.


## Reference
- Inspired from [Xamarin.UITest](https://learn.microsoft.com/en-us/appcenter/test-cloud/frameworks/uitest/).
- [Appium Dotnet](https://appium.io/docs/en/latest/quickstart/test-dotnet/).