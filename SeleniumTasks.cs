using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace TestSuite
{
  internal class SeleniumTasks
  {
    private const int maxTries = 30;


    internal static void LoginAsSPAdmin(RemoteWebDriver driver, string baseURL, string username, string password)
    {
      driver.Navigate().GoToUrl(baseURL);
      LoginAs(driver, baseURL, username, password);
    }

    internal static void LoginAs(RemoteWebDriver driver, string baseURL, string username, string password)
    {
      driver.Navigate().GoToUrl(baseURL);

      driver.FindElement(By.Id("loginForm:accountId")).SendKeys(username);
      driver.FindElement(By.Id("loginForm:password")).SendKeys(password);
      driver.FindElement(By.Id("loginForm:loginButton")).Click();

      //check if the login was successfull
      //WaitForForm(driver, "Home");

    }

    internal static void ClickQuicklink(RemoteWebDriver driver, string menuName, string quicklinkName)
    {
      Console.WriteLine($"Clicking quick link {menuName}.{quicklinkName}");

      driver.WaitGetElement(By.Id("quicklinkButton")).Click();
      driver.WaitGetElement(By.Id(menuName)).Click();
      driver.WaitGetElement(By.XPath($"//a[contains(text(), '{quicklinkName}')]")).Click();

      CheckForErrors(driver);
    }

    internal static void ClickRadioButton(RemoteWebDriver driver, string name, string value)
    {
      string elementName = string.IsNullOrEmpty(name) ? "value" : "id";
      string checkValue = (elementName.Equals("id") ? name : value);

      Console.WriteLine($"Clicking radio button {checkValue}");

      driver.WaitGetElement(By.XPath($"//input[contains(@{elementName}, '{checkValue}')]")).Click();

      CheckForErrors(driver);
    }

    internal static void ClickButton(RemoteWebDriver driver, string buttonName, bool inputElement = false)
    {
      Console.WriteLine($"Clicking button {buttonName}");

      if (inputElement)
      {
        driver.FindElement(By.XPath($"//input[value='{buttonName}']")).Click();
      }
      else
      {
        driver.WaitGetElement(By.XPath($"//button[contains(text(), '{buttonName}')]")).Click();
      }

      CheckForErrors(driver);
    }

    internal static void WaitForForm(RemoteWebDriver driver, string formHeader)
    {
      Console.WriteLine($"Waiting for form with header {formHeader}");

      WaitForXPath(driver, $"//span/b[contains(text(), '{formHeader}')]");

      CheckForErrors(driver);
    }

    internal static void WaitForXPath(RemoteWebDriver driver, string xpath)
    {
      driver.WaitGetElement(By.XPath(xpath));

      CheckForErrors(driver);
    }

    internal static void SetTextValue(RemoteWebDriver driver, string fieldName, string value, bool blurAfterwards = true)
    {
      Console.WriteLine($"Set text field {fieldName} to {value}");

      IWebElement element = driver.WaitGetElement(By.XPath($"//input[contains(@id, '{fieldName}')]"));
      element.SendKeys(value);
      string id = element.GetAttribute("id");

      if(blurAfterwards)
      {
        driver.ExecuteScript($"$('#{id}').blur();");
      }

      CheckForErrors(driver);
    }

    internal static void SetDateValue(RemoteWebDriver driver, string fieldName, DateTime value)
    {
      Console.WriteLine($"Set date field {fieldName} to {value}");

      driver.WaitGetElement(By.XPath($"//input[contains(@id, '{fieldName}')]")).SendKeys(value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture));

      CheckForErrors(driver);
    }

    internal static void SetOptionValue(RemoteWebDriver driver, string fieldName, string value)
    {
      Console.WriteLine($"Set option {fieldName} to {value}");

      driver.WaitGetElement(By.XPath($"//input[contains(@id, '{fieldName}')]")).SendKeys(value);
      driver.WaitGetElement(By.XPath($"//a[contains(@aria-label, '{value}')]")).Click();

      CheckForErrors(driver);
    }

    internal static void WaitForHomeScreen(RemoteWebDriver driver)
    {
      int tries = 0;

      while(!driver.Url.Equals(Properties.Settings.Default.IIQBaseUrl + "/home.jsf") || tries > maxTries)
      {
        Thread.Sleep(1000);
        tries++;
      }
    }

    internal static void ExecuteTask(RemoteWebDriver driver, string taskName)
    {
      int tries = 0;

      string fullUrl = Properties.Settings.Default.IIQBaseUrl + "/monitor/tasks/viewTasks.jsf";

      driver.Url = fullUrl;


      while (!driver.Url.Equals(fullUrl) || tries > maxTries)
      {
        Thread.Sleep(1000);
        tries++;
      }

      driver.WaitGetElement(By.XPath("//div[contains(text(), '" + taskName + "')]")).FindElement(By.XPath("../../../../../../../../..")).Click();

      //Actions builder = new Actions(driver);
      
      //Thread.Sleep(1000);
      //builder.SendKeys(Keys.ArrowDown);
      //Thread.Sleep(1000);
      //builder.SendKeys(Keys.ArrowDown);
      //Thread.Sleep(1000);
      //builder.SendKeys(Keys.ArrowDown);
      //Thread.Sleep(1000);
      //builder.SendKeys(Keys.Enter);

      //go back to home
      driver.Url = Properties.Settings.Default.IIQBaseUrl;

    }

    internal static void WaitForInputToHaveContent(RemoteWebDriver driver, string fieldName, string blurField)
    {
      string fieldValue = string.Empty;
      int nrOfAttempts = 0;

      while (string.IsNullOrEmpty(fieldValue) && nrOfAttempts < 50)
      {
        fieldValue = driver.FindElement(By.XPath("//input[contains(@id, '" + fieldName + "')]")).GetAttribute("value");

        Thread.Sleep(1000);

        BlurInputField(driver, blurField);

        nrOfAttempts++;
      }
    }

    internal static void BlurInputField(RemoteWebDriver driver, string fieldName)
    {
      IWebElement element = driver.FindElement(By.XPath("//input[contains(@id, '" + fieldName + "')]"));
      String id = element.GetAttribute("id");

      driver.ExecuteScript("$('#" + id + "').blur();");
    }

    internal static string ReadValue(RemoteWebDriver driver, string fieldName)
    {
      return driver.FindElement(By.XPath("//input[contains(@id, '" + fieldName + "')]")).GetAttribute("value");
    }

    internal static void CheckForErrors(RemoteWebDriver driver)
    {
      try
      {
        IWebElement element = driver.FindElement(By.ClassName("text-danger"));

        if(element != null)
        {
          throw new Exception($"This error was shown to the end user: {element.Text}");
        }
      }
      catch
      {
        //element not found, no action.
      }
    }
  }
}
