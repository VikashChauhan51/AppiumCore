using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using System;

namespace AppiumCore.Android;

public class AndroidConfiguration
{
    private TimeSpan m_implicitWait;
    private static readonly TimeSpan DEFAULT_TIMEOUT;

    static AndroidConfiguration()
    {
        DEFAULT_TIMEOUT = TimeSpan.FromSeconds(180);
    }
    public AndroidConfiguration()
    {
        m_implicitWait = DEFAULT_TIMEOUT;
    }

    public AndroidConfiguration SetImplicitWaitTime(TimeSpan implicitWait)
    {
        m_implicitWait = implicitWait;
        return this;
    }


    public AndroidApp StartApp(AppiumOptions appiumOptions, AppiumLocalService localService)
    {
        AndroidDriver<AndroidElement> driver;

        if (appiumOptions == null)
        {
            throw new ArgumentException("appiumOptions can't be null");
        }
        if (localService == null)
        {
            throw new ArgumentException("appium local server can't be null");
        }

        driver = new AndroidDriver<AndroidElement>(localService.ServiceUrl, appiumOptions, m_implicitWait);
        driver.Manage().Timeouts().ImplicitWait = m_implicitWait;
        return new AndroidApp(driver, localService);
    }
}
