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
        app.FindElementById("app").Click();
        Assert.Pass();
    }
}

```

## Reference
- Inspired from [Xamarin.UITest](https://learn.microsoft.com/en-us/appcenter/test-cloud/frameworks/uitest/).
- [Appium Dotnet](https://appium.io/docs/en/latest/quickstart/test-dotnet/).