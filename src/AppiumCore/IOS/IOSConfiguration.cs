﻿using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;

namespace AppiumCore.IOS;

public class IOSConfiguration
{
    private TimeSpan m_implicitWait;
    private static readonly TimeSpan DEFAULT_TIMEOUT = TimeSpan.FromSeconds(180);
    public IOSConfiguration()
    {
        m_implicitWait = DEFAULT_TIMEOUT;
    }

    public IOSConfiguration SetImplicitWaitTime(TimeSpan implicitWait)
    {
        m_implicitWait = implicitWait;
        return this;
    }


    public IIOSApp StartApp(AppiumOptions appiumOptions, AppiumLocalService localService)
    {
        IOSDriver driver;

        if (appiumOptions == null)
        {
            throw new ArgumentException("appiumOptions can't be null");
        }
        if (localService == null)
        {
            throw new ArgumentException("appium local server can't be null");
        }

        driver = new IOSDriver(localService, appiumOptions, m_implicitWait);
        driver.Manage().Timeouts().ImplicitWait = m_implicitWait;
        return new IOSApp(localService, driver);
    }

    public IIOSApp StartApp(AppiumOptions appiumOptions)
    {
        IOSDriver driver;

        if (appiumOptions == null)
        {
            throw new ArgumentException("appiumOptions can't be null");
        }
        driver = new IOSDriver(appiumOptions, m_implicitWait);
        driver.Manage().Timeouts().ImplicitWait = m_implicitWait;
        return new IOSApp(driver);
    }
}
