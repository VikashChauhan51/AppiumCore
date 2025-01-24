using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.VirtualAuth;

namespace AppiumCore;
public abstract class AppBase : IApp
{
    protected const string NativeApp = "NATIVE_APP";
    protected const string WebApp = "WEBVIEW";
    protected readonly AppiumDriver Driver;
    protected readonly AppiumLocalService? Service;

    protected AppBase(AppiumDriver driver)
    {
        this.Driver = driver;
    }
    protected AppBase(AppiumLocalService Service, AppiumDriver driver)
    {
        this.Service = Service;
        this.Driver = driver;
    }

    public Uri? ServiceUrl => Service?.ServiceUrl;
    public bool IsServerRunning => Service?.IsRunning ?? false;

    public abstract Platform Platform { get; }

    public IDictionary<string, object> SessionDetails => Driver.SessionDetails;

    public string PlatformName => Driver.PlatformName;

    public string AutomationName => Driver.AutomationName;

    public bool IsBrowser => Driver.IsBrowser;

    public Location Location { get => Driver.Location; set => Driver.Location = value; }
    public ScreenOrientation Orientation { get => Driver.Orientation; set => Driver.Orientation = value; }
    public string Context { get => Driver.Context; set => Driver.Context = value; }

    public ReadOnlyCollection<string> Contexts => Driver.Contexts;

    public string Url { get => Driver.Url; set => Driver.Url = value; }

    public string Title => Driver.Title;

    public string PageSource => Driver.PageSource;

    public string CurrentWindowHandle => Driver.CurrentWindowHandle;

    public ReadOnlyCollection<string> WindowHandles => Driver.WindowHandles;

    public bool IsActionExecutor => Driver.IsActionExecutor;

    public IFileDetector FileDetector { get => Driver.FileDetector; set => Driver.FileDetector = value; }

    public ICapabilities Capabilities => Driver.Capabilities;

    public ICommandExecutor CommandExecutor => Driver.CommandExecutor;

    public SessionId SessionId => Driver.SessionId;

    public abstract Dictionary<string, object> Settings { get; set; }

    public void SwitchToWebView()
    {
        // Wait for web appear
        List<string> AllContexts = [];
        foreach (var context in Contexts)
        {

            AllContexts.Add(context);
        }
        // Switch to web View

        var ctx = AllContexts.Find(static stringToCheck => stringToCheck.Contains(WebApp));
        if (ctx != null)
        {
            this.Context = ctx;

        }
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
        var ctx = AllContexts.Find(static stringToCheck => stringToCheck.Contains(NativeApp));
        if (ctx != null)
        {
            this.Context = ctx;

        }
    }

    public AppiumElement FindElement(By by) => Driver.FindElement(by);

    public ReadOnlyCollection<AppiumElement> FindElements(By by) => Driver.FindElements(by);

    public object GetSessionDetail(string detail) => Driver.GetSessionDetail(detail);

    public void HideKeyboard() => Driver.HideKeyboard();

    public void HideKeyboard(string key) => Driver.HideKeyboard(key);

    public void HideKeyboard(string strategy, string key) => Driver.HideKeyboard(strategy, key);
    public bool IsKeyboardShown() => Driver.IsKeyboardShown();

    public byte[] PullFile(string pathOnDevice) => Driver.PullFile(pathOnDevice);

    public byte[] PullFolder(string remotePath) => Driver.PullFolder(remotePath);

    public AppiumElement FindElement(string by, string value) => Driver.FindElement(by, value);

    public IReadOnlyCollection<AppiumElement> FindElements(string selector, string value) => Driver.FindElements(selector, value);

    public void InstallApp(string appPath) => Driver.InstallApp(appPath);

    public bool IsAppInstalled(string bundleId) => Driver.IsAppInstalled(bundleId);

    public void BackgroundApp() => Driver.BackgroundApp();

    public void BackgroundApp(TimeSpan timepSpan) => Driver.BackgroundApp(timepSpan);

    public void RemoveApp(string appId) => Driver.RemoveApp(appId);

    public void ActivateApp(string appId) => Driver.InstallApp(appId);

    public bool TerminateApp(string appId) => Driver.TerminateApp(appId);

    public bool TerminateApp(string appId, TimeSpan timeout) => Driver.TerminateApp(appId, timeout);

    public AppState GetAppState(string appId) => Driver.GetAppState(appId);

    public Response Execute(string commandName, Dictionary<string, object> parameters)
    {
        return Task.Run(() => ExecuteAsync(commandName, parameters)).GetAwaiter().GetResult();
    }

    public Response Execute(string driverCommand)
    {
        return Task.Run(() => ExecuteAsync(driverCommand, null!)).GetAwaiter().GetResult();
    }

    protected virtual async Task<Response> ExecuteAsync(string driverCommandToExecute, Dictionary<string, object> parameters)
    {
        Command commandToExecute = new Command(Driver.SessionId, driverCommandToExecute, parameters);
        Response response;
        try
        {
            response = await Driver.CommandExecutor.ExecuteAsync(commandToExecute).ConfigureAwait(continueOnCapturedContext: false);
        }
        catch (HttpRequestException value)
        {
            response = new Response
            {
                Status = WebDriverResult.UnhandledError,
                Value = value
            };
        }

        if (response.Status != 0)
        {
            UnpackAndThrowOnError(response, driverCommandToExecute);
        }

        return response;
    }
    public void Close() => Driver.Close();
    public void Quit() => Driver.Quit();
    public IOptions Manage() => Driver.Manage();
    public INavigation Navigate() => Driver.Navigate();

    public ITargetLocator SwitchTo() => Driver.SwitchTo();

    IWebElement ISearchContext.FindElement(By by) => Driver.FindElement(by);

    ReadOnlyCollection<IWebElement> ISearchContext.FindElements(By by) => ((ISearchContext)Driver).FindElements(by);

    public object ExecuteScript(string script, params object[] args) => Driver.ExecuteScript(script, args);

    public object ExecuteScript(PinnedScript script, params object[] args) => Driver.ExecuteScript(script, args);

    public object ExecuteAsyncScript(string script, params object[] args) => Driver.ExecuteScript(script, args);

    IWebElement IFindsElement.FindElement(string mechanism, string value) => Driver.FindElement(mechanism, value);

    ReadOnlyCollection<IWebElement> IFindsElement.FindElements(string mechanism, string value) => ((IFindsElement)Driver).FindElements(mechanism, value);

    public Screenshot GetScreenshot() => Driver.GetScreenshot();

    public PrintDocument Print(PrintOptions options) => Driver.Print(options);

    public void PerformActions(IList<ActionSequence> actionSequenceList) => Driver.PerformActions(actionSequenceList);

    public void ResetInputState() => Driver.ResetInputState();

    public object ExecuteCustomDriverCommand(string driverCommandToExecute, Dictionary<string, object> parameters) => Driver.ExecuteCustomDriverCommand(driverCommandToExecute, parameters);
    public void RegisterCustomDriverCommands(IReadOnlyDictionary<string, CommandInfo> commands) => Driver.RegisterCustomDriverCommands(commands);

    public bool RegisterCustomDriverCommand(string commandName, CommandInfo commandInfo) => Driver.RegisterCustomDriverCommand(commandName, commandInfo);

    public string AddVirtualAuthenticator(VirtualAuthenticatorOptions options) => Driver.AddVirtualAuthenticator(options);

    public void RemoveVirtualAuthenticator(string id) => Driver.RemoveVirtualAuthenticator(id);

    public void AddCredential(Credential credential) => Driver.AddCredential(credential);

    public List<Credential> GetCredentials() => Driver.GetCredentials();

    public void RemoveCredential(byte[] credentialId) => Driver.RemoveCredential(credentialId);

    public void RemoveCredential(string credentialId) => Driver.RemoveCredential(credentialId);

    public void RemoveAllCredentials() => Driver.RemoveAllCredentials();

    public void SetUserVerified(bool verified) => Driver.SetUserVerified(verified);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            this.Driver.Dispose();
            this.Service?.Dispose();
        }
    }

    private static void UnpackAndThrowOnError(Response errorResponse, string commandToExecute)
    {
        if (errorResponse.Status == WebDriverResult.Success)
        {
            return;
        }

        if (errorResponse.Value is Dictionary<string, object> dictionary && dictionary is not null)
        {
            string message = new ErrorResponse(dictionary!).Message;
            switch (errorResponse.Status)
            {
                case WebDriverResult.NoSuchElement:
                    throw new NoSuchElementException(message);
                case WebDriverResult.NoSuchFrame:
                    throw new NoSuchFrameException(message);
                case WebDriverResult.UnknownCommand:
                    throw new NotImplementedException(message);
                case WebDriverResult.ObsoleteElement:
                    throw new StaleElementReferenceException(message);
                case WebDriverResult.ElementClickIntercepted:
                    throw new ElementClickInterceptedException(message);
                case WebDriverResult.ElementNotInteractable:
                    throw new ElementNotInteractableException(message);
                case WebDriverResult.ElementNotDisplayed:
                    throw new ElementNotVisibleException(message);
                case WebDriverResult.InvalidElementState:
                case WebDriverResult.ElementNotSelectable:
                    throw new InvalidElementStateException(message);
                case WebDriverResult.UnhandledError:
                    throw new WebDriverException(message);
                case WebDriverResult.NoSuchDocument:
                    throw new NoSuchElementException(message);
                case WebDriverResult.Timeout:
                    throw new WebDriverTimeoutException(message);
                case WebDriverResult.NoSuchWindow:
                    throw new NoSuchWindowException(message);
                case WebDriverResult.InvalidCookieDomain:
                    throw new InvalidCookieDomainException(message);
                case WebDriverResult.UnableToSetCookie:
                    throw new UnableToSetCookieException(message);
                case WebDriverResult.AsyncScriptTimeout:
                    throw new WebDriverTimeoutException(message);
                case WebDriverResult.UnexpectedAlertOpen:
                    {
                        string alertText = string.Empty;
                        if (dictionary.ContainsKey("alert"))
                        {
                            if (dictionary["alert"] is Dictionary<string, object> dictionary2 && dictionary2.ContainsKey("text"))
                            {
                                alertText = dictionary2["text"].ToString();
                            }
                        }
                        else if (dictionary.ContainsKey("data") && dictionary["data"] is Dictionary<string, object> dictionary3 && dictionary3.ContainsKey("text"))
                        {
                            alertText = dictionary3["text"].ToString();
                        }

                        throw new UnhandledAlertException(message, alertText);
                    }
                case WebDriverResult.NoAlertPresent:
                    throw new NoAlertPresentException(message);
                case WebDriverResult.InvalidSelector:
                    throw new InvalidSelectorException(message);
                case WebDriverResult.NoSuchDriver:
                    throw new WebDriverException(message);
                case WebDriverResult.InvalidArgument:
                    throw new WebDriverArgumentException(message);
                case WebDriverResult.UnexpectedJavaScriptError:
                    throw new JavaScriptException(message);
                case WebDriverResult.MoveTargetOutOfBounds:
                    throw new MoveTargetOutOfBoundsException(message);
                case WebDriverResult.NoSuchShadowRoot:
                    throw new NoSuchShadowRootException(message);
                case WebDriverResult.DetachedShadowRoot:
                    throw new DetachedShadowRootException(message);
                case WebDriverResult.InsecureCertificate:
                    throw new InsecureCertificateException(message);
                default:
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "{0} ({1})", message, errorResponse.Status));
            }
        }

        throw new WebDriverException("The " + commandToExecute + " command returned an unexpected error. " + errorResponse.Value.ToString());
    }

    public abstract void SetClipboard(ClipboardContentType contentType, string base64Content);

    public abstract string GetClipboard(ClipboardContentType contentType);

    public abstract void SetClipboardText(string textContent, string label);

    public abstract string GetClipboardText();

    public abstract void SetClipboardUrl(string url);

    public abstract string GetClipboardUrl();

    public abstract void SetClipboardImage(Image image);

    public abstract Image GetClipboardImage();

    public abstract void SetSetting(string setting, object value);
}
