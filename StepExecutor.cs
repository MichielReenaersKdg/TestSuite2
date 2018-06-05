using log4net;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading;
using TestSuite.Model;
using TestSuite.Models;

namespace TestSuite
{
  internal class StepExecutor : IDisposable
  {
    private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    int stepIndex = 0;
    List<Step> steps;
    dynamic driver = null;
    private bool _stopAfterCurrentStep;
    private Identity _testPerson;
    private string _lastError = null;

    private string resultObjectId = null;
    private Dictionary<string, string> _activeObject;


    public void ExecuteSteps(List<Step> steps)
    {
      log.Debug($"Starting execution of steps: {steps.ToString()}");
      switch (Properties.Settings.Default.IIQBrowser)
            {
                case "IE": driver = new InternetExplorerDriver(); break;
                case "FF": driver = new FirefoxDriver(); break;
                case "GC": driver = new ChromeDriver(); break;
            }
      //driver = new InternetExplorerDriver();
      this.steps = steps;
      this.stepIndex = 0;
      this._stopAfterCurrentStep = false;

      if(this._testPerson == null)
      {
        log.Debug("Grabbing test person");
        this._testPerson = TestObjectsHelper.GrabTestPerson();
      }

      log.Debug("Triggering next step");
      TriggerNextStep(this.steps[stepIndex]);
    }

    public void Dispose()
    {
      DisposeDriver();
    }

    public void ExecuteChecks(List<Check> checks, IIQObject activeObject)
    {
      log.Debug("Starting check execution");

      bool allSuccessfull = true;

      foreach (Check check in checks)
      {
        check.Status = ExecuteCheck(check, activeObject);

        if (check.Status != CheckStatus.Completed)
        {
          allSuccessfull = false;
        }
      }

      ChecksExecuted(this, allSuccessfull);

      if (allSuccessfull)
      {
        AllChecksSuccessfull(this, new EventArgs());
      }
    }

    public void StopAfterCurrentStep()
    {
      this._stopAfterCurrentStep = true;
    }

    public void TriggerNextStep(Step step)
    {
      log.Debug($"Step {step.ToString()} triggered. Starting new thread.");

      Thread newThread = new Thread(unused => ExecuteStep(step));

      var bw = new BackgroundWorker();
      bw.DoWork += (sender, args) =>
      {
        ExecuteStep(step);
      };

      bw.RunWorkerCompleted += (sender, args) =>
      {
        log.Debug($"Thread completed. Step index is {stepIndex}");

        stepIndex++;
        bool stepSuccessfull = _lastError.Equals("success");
        step.Status = stepSuccessfull ? StepStatus.Completed : StepStatus.Error;

        log.Debug("Calling StepCompleted event handler");
        StepCompleted(this, stepSuccessfull, _lastError);

        log.Debug($"Total step count: {this.steps.Count}. Currently at step {stepIndex}");

        if (stepSuccessfull)
        {
          if (this.steps.Count > stepIndex && !_stopAfterCurrentStep)
          {
            log.Debug("Triggering next step");
            TriggerNextStep(this.steps[stepIndex]);
          }
          else
          {
            log.Debug("Final step detected. Calling AllStepsCompleted event handler");
            DisposeDriver();
            AllStepsCompleted(this, new IIQObject(this.resultObjectId, this.resultObjectId));
          }
        }
      };

      bw.RunWorkerAsync();
    }

    public void ExecuteStep(Step step, int numberOfRetryAttemptsAfterError = 5)
    {
      log.Debug(">ExecuteStep");

      try
      {
        switch (step.Action)
        {
          case "LoginAsSPAdmin":
            SailpointToyotaDLL.Class1.LoginAsSPAdmin(driver, Properties.Settings.Default.IIQBaseUrl + "/login.jsf",
              Properties.Settings.Default.SPAdminUsername, Properties.Settings.Default.SPAdminPassword);
            break;
          case "Quicklink":
            SailpointToyotaDLL.Class1.ClickQuicklink(driver, step.Category, step.Name);
            break;

          case "clickRadio":
            SailpointToyotaDLL.Class1.ClickRadioButton(driver, step.Name, step.Value);
            break;

          case "clickButton":
            SailpointToyotaDLL.Class1.ClickButton(driver, step.Name);
            break;

          case "setTextValue":
            SailpointToyotaDLL.Class1.SetTextValue(driver, step.Name, ParseValue(step.Value));
            break;

          case "waitForInputToHaveContent":
            SailpointToyotaDLL.Class1.WaitForInputToHaveContent(driver, step.Name, step.Name);
            break;

          case "waitForForm":
            SailpointToyotaDLL.Class1.WaitForForm(driver, step.Name);
            break;

          case "setOptionValue":
            SailpointToyotaDLL.Class1.SetOptionValue(driver, step.Name, step.Value);
            break;

          case "waitForHomeScreen":
            SailpointToyotaDLL.Class1.WaitForHomeScreen(driver, Properties.Settings.Default.IIQBaseUrl);
            break;

          case "readValue":
            this.resultObjectId = SailpointToyotaDLL.Class1.ReadValue(driver, step.Name);
            break;

          case "executeTask":
            SailpointToyotaDLL.Class1.ExecuteTask(driver, step.Value, Properties.Settings.Default.IIQBaseUrl);
            break;
        }

        _lastError = "success";
      }
      catch (Exception ex)
      {
        if (numberOfRetryAttemptsAfterError < 1)
        {
          _lastError = ex.Message;
        }
        else
        {
          ExecuteStep(step, numberOfRetryAttemptsAfterError--);
        }
      }

      log.Debug("<ExecuteStep");
    }

    public CheckStatus ExecuteCheck(Check check, IIQObject activeObject)
    {
            CheckStatus checkStatus = CheckStatus.Completed;
      log.Debug(">ExecuteCheck");

      try
      {
        switch (check.Condition)
        {
          case "mustHaveLinkWith":
            checkStatus = IIQHelper.CheckMustHaveLinkWith(activeObject.Id, check.Value) ? CheckStatus.Completed : CheckStatus.Pending;
            break;
          case "xpathMustMatch":
            checkStatus = IIQHelper.CheckXpathMustMatch(activeObject.Id, check.Value) ? CheckStatus.Completed : CheckStatus.Pending;
            break;
        }

        log.Debug("<ExecuteCheck");

        return checkStatus;

      }
      catch (Exception ex)
      {
        log.Error($"Check error: {check.ToString()}. Exception message: {ex.Message}");
        return CheckStatus.Error;
      }
    }


    public delegate void StepCompletedDelegate(object sender, bool success, string message);

    public event StepCompletedDelegate StepCompleted;

    public delegate void AllStepsCompletedDelegate(object sender, IIQObject iiqObject);

    public event AllStepsCompletedDelegate AllStepsCompleted;

    public delegate void AllChecksSuccessfullDelegate(object sender, EventArgs e);

    public event AllChecksSuccessfullDelegate AllChecksSuccessfull;

    public delegate void ChecksExecutedDelegate(object sender, bool checksSuccessfull);

    public event ChecksExecutedDelegate ChecksExecuted;

    private string ParseValue(string value)
    {
      MatchCollection matches = Regex.Matches(value, @"\[([^]]+)\]");

      foreach (Match match in matches)
      {
        string matchString = match.Groups[1].Value;
        string replaceValue = string.Empty;

        if (matchString.Contains("."))
        {
          string[] matchSplitted = matchString.Split('.');

          switch (matchSplitted[0])
          {
            case "ActiveObject":
              InitializeActiveObject();
              replaceValue = _activeObject[matchSplitted[1]];
              break;
            case "Identity":
              replaceValue = typeof(Identity).GetProperty(matchSplitted[1]).GetValue(this._testPerson).ToString();
              break;
          }
        }

        value = value.Replace($"[{matchString}]", replaceValue);

      }

      return value;
    }

    private void DisposeDriver()
    {
      if (driver != null)
      {
        driver.Close();
        driver.Dispose();
      }
    }

    public bool SetActiveObject(string objectId)
    {
      log.Debug(">SetActiveObject");

      Dictionary<string, string> activeObject = IIQHelper.GetIIQObjectAttributes(objectId);

      if(activeObject != null && activeObject.Count > 0)
      {
        this.resultObjectId = objectId;
        this._activeObject = activeObject;
        return true;
      }
      else
      {
        return false;
      }
    }

    private void InitializeActiveObject(bool force = false)
    {
      if (!string.IsNullOrEmpty(this.resultObjectId))
      {
        if(force || this._activeObject == null)
        this._activeObject = IIQHelper.GetIIQObjectAttributes(this.resultObjectId);
      }
    }
  }
}