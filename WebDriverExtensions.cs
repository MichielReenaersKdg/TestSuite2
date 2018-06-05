using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Threading;
using SeleniumExtras.WaitHelpers;

namespace TestSuite
{
  public static class WebDriverExtensions
  {

    public static IWebElement WaitGetElement(this IWebDriver driver, By by, int failAfterTimeoutInSeconds = 60, By refreshButton = null, int timeoutInSeconds = 2, bool checkIsVisible = true)
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();

      IWebElement element = null;

      while (element == null)
      {
       var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

        try
        {
          if (checkIsVisible)
          {
            
            element = wait.Until(ExpectedConditions.ElementIsVisible(by));
          }
          else
          {
            element = wait.Until(ExpectedConditions.ElementExists(by));
          }
        }
        catch (NoSuchElementException) { element = null; }
        catch (WebDriverTimeoutException) { element = null; }
        catch (TimeoutException) { element = null; }

        if(stopwatch.Elapsed.TotalSeconds > failAfterTimeoutInSeconds)
        {
          throw new TimeoutException($"Test failed! Element '{by.ToString()}' was not found within the alotted time frame.");
        }

        //refresh if a refresh button is specified
        if(refreshButton != null)
        {
          driver.WaitGetElement(refreshButton).Click();
          Thread.Sleep(1000);
        }
      }

      return element;
    }

    public static void FireEvent(this IWebDriver driver, By by, string eventName)
    {
      string id = driver.FindElement(by).GetAttribute("id");
      Console.WriteLine(id);
      System.IO.File.WriteAllText("test.log", id);
      ((IJavaScriptExecutor)driver).ExecuteScript($"return document.getElementById('{id}').{eventName}()");
    }

  }
}