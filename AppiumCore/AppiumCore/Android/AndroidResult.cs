using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AppiumCore.Android
{
    public class AndroidResult : IAppResult
    {
        private readonly AndroidElement _element;
        public AndroidResult(AndroidElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            this._element = element;

        }

        public string Id => this._element.Id;

        public string Text => this._element.Text;

        public string Name => this._element.TagName;

        public bool Displayed => this._element.Displayed;

        public bool Enabled => this._element.Enabled;

        public bool Selected => this._element.Selected;

        public Point Location => this._element.Location;

        public Size Size => this._element.Size;

        public Rectangle Rect => this._element.Rect;
        public ICoordinates Coordinates => this._element.Coordinates;

        public void Click() => this._element.Click();
        public void Clear() => this._element.Clear();
        public void SendKeys(string text) => this._element.SendKeys(text);
        public void Submit() => this._element.Submit();
        public string GetAttribute(string attributeName) => this._element.GetAttribute(attributeName);
        public string GetCssValue(string propertyName) => this._element.GetCssValue(propertyName);
        public string GetProperty(string propertyName) => this._element.GetProperty(propertyName);

    }
}
