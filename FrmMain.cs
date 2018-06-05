using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using TestSuiteModels.Models;
using SailpointToyotaDLL.Functionality;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace TestSuite
{
  public partial class FrmMain : Form
  {
    private List<TestCase> _testCases;
    private int _activeTestCaseIndex;
    private BL.StepExecutor executor;
    private IIQObject _activeObject;
    private bool _allChecksSuccessfull = false;
    private Timer _checkWaitTimer = null;
    private StringBuilder _errorLog;
    private bool _playingAllTests = false;
    private int _currentlyPlayingTest;
    private bool _executingChecks;

    private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public FrmMain()
    {
      InitializeComponent();

      log.Debug("Starting application");

      this._testCases = new List<TestCase>();
      this._activeTestCaseIndex = 0;
      this._currentlyPlayingTest = -1;
      
      _errorLog = new StringBuilder();
      this._executingChecks = false;
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FrmSettings settingsForm = new FrmSettings();
      settingsForm.ShowDialog();
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.DefaultExt = "xml";
      openFileDialog.CheckFileExists = true;
      openFileDialog.Multiselect = true;

      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        XmlDocument doc = new XmlDocument();
        foreach (string fileName in openFileDialog.FileNames)
        {
          doc.Load(fileName);

          //testcase
          foreach (XmlNode testcase in doc.ChildNodes)
          {
            List<Step> currentSteps = new List<Step>();
            List<Check> currentChecks = new List<Check>();

            foreach (XmlElement childNode in testcase.ChildNodes)
            {
              if (childNode.Name == "steps")
              {
                //steps
                foreach (XmlNode step in childNode)
                {
                  string action = step.Attributes["action"]?.InnerText;
                  string category = step.Attributes["category"]?.InnerText;
                  string name = step.Attributes["name"]?.InnerText;
                  string value = step.Attributes["value"]?.InnerText;

                  currentSteps.Add(new Step(action, category, name, value));
                }
              }

              if (childNode.Name == "checks")
              {
                foreach (XmlNode check in childNode)
                {
                  if (check.NodeType == XmlNodeType.Element)
                  {
                    string condition = check.Attributes["condition"]?.InnerText;
                    string name = check.Attributes["Name"]?.InnerText;
                    string value = check.Attributes["value"]?.InnerText;

                    currentChecks.Add(new Check(condition, name, value));
                  }
                }
              }
            }

            TestCase newTestCase = new TestCase(currentSteps, currentChecks) { Name = testcase.Attributes["name"].Value };
            
            this._testCases.Add(newTestCase);
          }

          this._activeTestCaseIndex = this._testCases.Count - 1;
          this.lstTestCases.Rows.Add(Properties.Resources.Task_16x, _testCases.Last().Name);
          this.lstTestCases.Rows[this.lstTestCases.Rows.Count - 1].Selected = true;
        }
      }
    }

    private void LoadSteps(TestCase testCase = null)
    {
      dgvActions.Rows.Clear();

      if (testCase == null)
      {
        testCase = this._testCases[this._activeTestCaseIndex];
      }

      foreach (Step currentStep in testCase.Steps)
      {
        dgvActions.Rows.Add(new[] { currentStep.Action, currentStep.Category, currentStep.Name, currentStep.Value });

        foreach (DataGridViewCell cell in dgvActions.Rows[dgvActions.Rows.Count - 1].Cells)
        {
          cell.Style.BackColor = currentStep.Status == StepStatus.Completed ? Color.LightGreen : currentStep.Status == StepStatus.Error ? Color.Red : Color.Yellow;
        }
      }
    }

    private void LoadChecks(TestCase testCase = null)
    {
      dgvChecks.Rows.Clear();

      if (testCase == null)
      {
        testCase = this._testCases[this._activeTestCaseIndex];
      }

      foreach (Check currentCheck in testCase.Checks)
      {
        dgvChecks.Rows.Add(new[] { currentCheck.Condition, currentCheck.Name, currentCheck.Value });

        foreach (DataGridViewCell cell in dgvChecks.Rows[dgvChecks.Rows.Count - 1].Cells)
        {
          cell.Style.BackColor = currentCheck.Status == CheckStatus.Completed ? Color.LightGreen : currentCheck.Status == CheckStatus.Error ? Color.Red : Color.Yellow;
        }
      }
    }

    private void btnPlay_Click(object sender, EventArgs e)
    {
      bool errorInStep = false;
      log.Debug("Starting execution of currently selected step");

      lblStatus.Text = "Now executing steps...";

      lstTestCases.SelectedRows[0].Cells[0].Value = Properties.Resources.Run_16x;

      tlstpProgress.ProgressBar.Style = ProgressBarStyle.Marquee;
      tlstpProgress.ProgressBar.MarqueeAnimationSpeed = 30;

      executor.StepCompleted += Executor_StepCompleted;
      executor.AllStepsCompleted += this.Executor_AllStepsCompleted;

      btnStop.Enabled = true;

            try
            {
                executor.ExecuteSteps(this._testCases[this._activeTestCaseIndex].Steps);
            } catch (Exception ex)
            {
                errorInStep = true;
            }

            if (!errorInStep)
            {
                Executor_AllStepsCompleted(this);
            }
      
    }

        private void Executor_AllStepsCompleted(object sender)
        {
            if (!this._executingChecks)
            {
                log.Debug(">Executor_AllStepsCompleted");


                //start checks
                if (this._testCases[this._activeTestCaseIndex].Checks != null)
                {
                    this._executingChecks = true;

                    executor.ChecksExecuted += Executor_ChecksExecuted;
                    executor.AllChecksSuccessfull += Executor_AllChecksSuccessfull;

                    executor.ExecuteChecks(this._testCases[this._activeTestCaseIndex].Checks);
                }
                else
                {
                    tlstpProgress.ProgressBar.Style = ProgressBarStyle.Continuous;
                    tlstpProgress.ProgressBar.MarqueeAnimationSpeed = 0;
                }
            }
        }

        private void btnPlayAll_Click(object sender, EventArgs e)
    {
      log.Debug("Play all clicked");

      _playingAllTests = true;
      _currentlyPlayingTest = this._activeTestCaseIndex;

      //start the active test
      btnPlay_Click(this, new EventArgs());
    }

    

    private void Executor_AllChecksSuccessfull(object sender, EventArgs e)
    {
      //safety
      if (this._executingChecks)
      {
        log.Debug(">Executor_AllChecksSuccessfull");
      
        this._executingChecks = false;
        if(_checkWaitTimer != null)
        {
          _checkWaitTimer.Stop();
          _checkWaitTimer.Dispose();
        }

        lstTestCases.SelectedRows[0].Cells[0].Value = Properties.Resources.Checkmark_green_12x_16x;

        //start next test if we're playing all tests
        if (_playingAllTests)
        {
          _currentlyPlayingTest++;

          //if there are more tests to run
          if (_currentlyPlayingTest < _testCases.Count)
          {
            //select the next test
            lstTestCases.Rows[_currentlyPlayingTest].Selected = true;

            this.Refresh();

            //start the active test
            btnPlay_Click(this, new EventArgs());

            return;
          }
        }

        var confirmResult = MessageBox.Show("All checks successfull!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        lblStatus.Text = "All checks successfull!";
        btnStop.Enabled = false;
      }
    }

    private void Executor_ChecksExecuted(object sender, bool allChecksSuccessfull)
    {
      log.Debug(">Executor_ChecksExecuted");

      if (this._executingChecks)
      {
        tlstpProgress.ProgressBar.Style = ProgressBarStyle.Continuous;
        tlstpProgress.ProgressBar.MarqueeAnimationSpeed = 0;

        this._allChecksSuccessfull = allChecksSuccessfull;
        LoadChecks(this._testCases[this._activeTestCaseIndex]);

        this.Refresh();

        if (!allChecksSuccessfull)
        {
          lblStatus.Text = "Not all checks successfull yet. Trying again in a few seconds...";

          _checkWaitTimer = new Timer();
          _checkWaitTimer.Interval = 10000;
          _checkWaitTimer.Tick += CheckWaitTimer_Tick;
          _checkWaitTimer.Start();
        }
      }
    }

    private void CheckWaitTimer_Tick(object sender, EventArgs e)
    {
      log.Debug(">CheckWaitTimer_Tick");

      if (_executingChecks)
      {
        _checkWaitTimer.Stop();
        lblStatus.Text = "Now executing checks...";

        //executor.ExecuteChecks(this._testCases[this._activeTestCaseIndex].Checks, this._activeObject);
      }
    }

    private void Executor_StepCompleted(object sender, bool success, string message)
    {
      if (!this._executingChecks)
      {
        log.Debug(">Executor_StepCompleted");

        if (!success)
        {
          var confirmResult = MessageBox.Show($"Step not successfull. Error message: {message}",
                                 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        LoadSteps(this._testCases[lstTestCases.SelectedRows[0].Index]);
        LoadChecks(this._testCases[lstTestCases.SelectedRows[0].Index]);
      }
    }

    private void lstTestCases_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (lstTestCases.SelectedRows[0].Index > -1)
      {
        LoadSteps(this._testCases[lstTestCases.SelectedRows[0].Index]);
        LoadChecks(this._testCases[lstTestCases.SelectedRows[0].Index]);
        this._activeTestCaseIndex = lstTestCases.SelectedRows[0].Index;

        btnPlay.Enabled = true;
      }
    }

    private void lstTestCases_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Delete)
      {
        if (this._activeTestCaseIndex == lstTestCases.SelectedRows[0].Index)
        {
          dgvActions.Rows.Clear();
        }

        lstTestCases.Rows.RemoveAt(this._activeTestCaseIndex);
        this._activeTestCaseIndex = -1;

        //select the first item
        if (lstTestCases.Rows.Count > 0)
        {
          lstTestCases.Rows[0].Selected = true;
        }

        openToolStripMenuItem.Enabled = false;
      }
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
      if (this.executor != null)
      {
        //this.executor.StopAfterCurrentStep();

        tlstpProgress.ProgressBar.Style = ProgressBarStyle.Continuous;
        tlstpProgress.ProgressBar.MarqueeAnimationSpeed = 0;

        btnStop.Enabled = false;
        btnPlay.Enabled = true;
      }
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FrmAbout about = new FrmAbout();
      about.ShowDialog();
    }

    private void closeAllTestsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var confirmResult = MessageBox.Show("Are you sure you want to close all test cases?",
                                     "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (confirmResult == DialogResult.Yes)
      {
        //stop execution
        btnStop_Click(this, new EventArgs());

        //lstTestCases.Rows.Clear();
        dgvActions.Rows.Clear();
        dgvChecks.Rows.Clear();
        _testCases = new List<TestCase>();
        _activeTestCaseIndex = 0;
        _activeObject = null;
        txtActiveObject.Text = string.Empty;
        btnPlay.Enabled = false;
        lblStatus.Text = "Doing nothing...";
      }
    }

    private void dgvActions_SelectionChanged(object sender, EventArgs e)
    {
      dgvActions.ClearSelection();
    }

    private void dgvChecks_SelectionChanged(object sender, EventArgs e)
    {
      dgvChecks.ClearSelection();
    }

    private void btnSetActiveObject_Click(object sender, EventArgs e)
    {
      InputDialog inputDialog = new InputDialog();
      DialogResult result = inputDialog.ShowDialog();
      if (result == DialogResult.OK)
      {
        string input = inputDialog.GetInput();

        //if(executor.SetActiveObject(input))
        //{
        //  txtActiveObject.Text = inputDialog.GetInput();
        //}
        //else
        //{
        //  var confirmResult = MessageBox.Show("IIQ does not contain an object with that id",
        //                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
      }
    }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            Form Generator = new TestFileGenerator();
            Generator.Show();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (XMLFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.executor = new BL.StepExecutor(XMLFileDialog.FileName);
            } else
            {
                MessageBox.Show("Something went wrong while retrieving the requested File. Please try again.");
            }
            
        }
    }
}