using OpenQA.Selenium.Interactions.Internal;
using System.Drawing;


namespace AppiumCore;

	/// <summary>
	/// Result return by app query
	/// </summary>
 public interface IAppResult
{
		 string Id { get; }
		 string Text { get; }
		 string Name { get; }
		 bool Displayed { get; }
		 bool Enabled { get; }
		 bool Selected { get; }
		 Point Location { get; }
		 Size Size { get; }
		 Rectangle Rect { get; }
		 ICoordinates Coordinates { get; }
		 void Click();
		 void Clear();
		 void SendKeys(string text);
		 void Submit();
		 string GetAttribute(string attributeName);
		 string GetCssValue(string propertyName);
		 string GetProperty(string propertyName);
	}
