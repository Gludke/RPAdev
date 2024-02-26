using OpenQA.Selenium;

namespace RPAdev.Domain.Shared
{
    public static class SeleniumHelper
    {
        public static string GetTextByClass(this IWebElement webElement, string className)
        {
            return webElement.FindElement(By.ClassName(className)).Text;
        }

        public static string GetAttributeByTag(this IWebElement webElement, string atribute, string tag)
        {
            return webElement.FindElement(By.TagName("a")).GetAttribute("href");
        }

        public static IList<IWebElement> FindElementsByXPath(this IWebDriver webDriver, string xPath)
        {
            return webDriver.FindElements(By.XPath(xPath));
        }

        public static string GetTextByXPath(this IWebDriver webDriver, string xPath)
        {
            return webDriver.FindElement(By.XPath(xPath)).Text;
        }

        public static string GetTextByClass(this IWebDriver webDriver, string className)
        {
            return webDriver.FindElement(By.ClassName(className)).Text;
        }

        /// <summary>
        /// Retorna uma string única com palavras divididas por ','
        /// </summary>
        public static string GetTextOfElementsByClass(this IWebDriver webDriver, string className)
        {
            var txt = webDriver.FindElements(By.ClassName(className)).Select(e => e.Text).Distinct();
            return txt.First() + string.Join(", ", txt.Skip(1)).TrimEnd(',');
        }

        public static async Task MinimizeAndGoToUrl(this IWebDriver webDriver, string url)
        {
            webDriver.Manage().Window.Minimize();
            await Task.Delay(20);
            webDriver.Navigate().GoToUrl(url);
        }
    }
}
