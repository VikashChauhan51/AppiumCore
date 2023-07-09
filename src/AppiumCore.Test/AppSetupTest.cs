
namespace AppiumCore.Test;

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
