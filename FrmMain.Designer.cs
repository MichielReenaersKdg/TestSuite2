namespace TestSuite
{
  partial class FrmMain
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPlayAll = new System.Windows.Forms.ToolStripButton();
            this.btnPlay = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.GenerateButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlstpProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpTest = new System.Windows.Forms.GroupBox();
            this.dgvActions = new System.Windows.Forms.DataGridView();
            this.clmAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstTestCases = new System.Windows.Forms.DataGridView();
            this.rwStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grpCheck = new System.Windows.Forms.GroupBox();
            this.dgvChecks = new System.Windows.Forms.DataGridView();
            this.clmCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCheckValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtActiveObject = new System.Windows.Forms.TextBox();
            this.btnSetActiveObject = new System.Windows.Forms.Button();
            this.lblActiveObject = new System.Windows.Forms.Label();
            this.XMLFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grpTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstTestCases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grpCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecks)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1200, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeAllTestsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::TestSuite.Properties.Resources.OpenFile_16x;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(203, 30);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeAllTestsToolStripMenuItem
            // 
            this.closeAllTestsToolStripMenuItem.Image = global::TestSuite.Properties.Resources.CloseDocument_16x;
            this.closeAllTestsToolStripMenuItem.Name = "closeAllTestsToolStripMenuItem";
            this.closeAllTestsToolStripMenuItem.Size = new System.Drawing.Size(203, 30);
            this.closeAllTestsToolStripMenuItem.Text = "Close all tests";
            this.closeAllTestsToolStripMenuItem.Click += new System.EventHandler(this.closeAllTestsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::TestSuite.Properties.Resources.Exit_16x;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(203, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("settingsToolStripMenuItem.Image")));
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(160, 30);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(158, 30);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpen,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.btnPlayAll,
            this.btnPlay,
            this.btnStop,
            this.GenerateButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 35);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1200, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnOpen
            // 
            this.tsbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnOpen.Image = global::TestSuite.Properties.Resources.OpenFile_16x;
            this.tsbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpen.Name = "tsbtnOpen";
            this.tsbtnOpen.Size = new System.Drawing.Size(28, 28);
            this.tsbtnOpen.Text = "Open a test case...";
            this.tsbtnOpen.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::TestSuite.Properties.Resources.CloseDocument_16x;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.closeAllTestsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // btnPlayAll
            // 
            this.btnPlayAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPlayAll.Image = global::TestSuite.Properties.Resources.PlayStepGroup_16x;
            this.btnPlayAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlayAll.Name = "btnPlayAll";
            this.btnPlayAll.Size = new System.Drawing.Size(28, 28);
            this.btnPlayAll.Text = "Play all loaded test cases";
            this.btnPlayAll.Click += new System.EventHandler(this.btnPlayAll_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPlay.Enabled = false;
            this.btnPlay.Image = global::TestSuite.Properties.Resources.Run_16x;
            this.btnPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(28, 28);
            this.btnPlay.Text = "Play currently selected test case...";
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Enabled = false;
            this.btnStop.Image = global::TestSuite.Properties.Resources.Stop_16x;
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(28, 28);
            this.btnStop.Text = "Stop test case currently running...";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // GenerateButton
            // 
            this.GenerateButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GenerateButton.BackgroundImage")));
            this.GenerateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GenerateButton.Image = ((System.Drawing.Image)(resources.GetObject("GenerateButton.Image")));
            this.GenerateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(28, 28);
            this.GenerateButton.Text = "toolStripButton1";
            this.GenerateButton.ToolTipText = "Generate";
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstpProgress,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 826);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1200, 31);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlstpProgress
            // 
            this.tlstpProgress.Name = "tlstpProgress";
            this.tlstpProgress.Size = new System.Drawing.Size(150, 25);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(140, 26);
            this.lblStatus.Text = "Doing nothing...";
            // 
            // grpTest
            // 
            this.grpTest.Controls.Add(this.dgvActions);
            this.grpTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTest.Location = new System.Drawing.Point(0, 0);
            this.grpTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTest.Name = "grpTest";
            this.grpTest.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTest.Size = new System.Drawing.Size(831, 380);
            this.grpTest.TabIndex = 4;
            this.grpTest.TabStop = false;
            this.grpTest.Text = "Test";
            // 
            // dgvActions
            // 
            this.dgvActions.AllowUserToAddRows = false;
            this.dgvActions.AllowUserToDeleteRows = false;
            this.dgvActions.AllowUserToResizeRows = false;
            this.dgvActions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmAction,
            this.clmCategory,
            this.clmName,
            this.clmValue});
            this.dgvActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActions.Location = new System.Drawing.Point(4, 24);
            this.dgvActions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvActions.MultiSelect = false;
            this.dgvActions.Name = "dgvActions";
            this.dgvActions.RowHeadersVisible = false;
            this.dgvActions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActions.ShowCellToolTips = false;
            this.dgvActions.ShowEditingIcon = false;
            this.dgvActions.ShowRowErrors = false;
            this.dgvActions.Size = new System.Drawing.Size(823, 351);
            this.dgvActions.TabIndex = 0;
            this.dgvActions.SelectionChanged += new System.EventHandler(this.dgvActions_SelectionChanged);
            // 
            // clmAction
            // 
            this.clmAction.HeaderText = "Action";
            this.clmAction.Name = "clmAction";
            this.clmAction.ReadOnly = true;
            // 
            // clmCategory
            // 
            this.clmCategory.HeaderText = "Category";
            this.clmCategory.Name = "clmCategory";
            this.clmCategory.ReadOnly = true;
            // 
            // clmName
            // 
            this.clmName.HeaderText = "Name";
            this.clmName.Name = "clmName";
            // 
            // clmValue
            // 
            this.clmValue.HeaderText = "Value";
            this.clmValue.Name = "clmValue";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 66);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstTestCases);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1200, 760);
            this.splitContainer1.SplitterDistance = 363;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 5;
            // 
            // lstTestCases
            // 
            this.lstTestCases.AllowUserToAddRows = false;
            this.lstTestCases.AllowUserToDeleteRows = false;
            this.lstTestCases.AllowUserToResizeColumns = false;
            this.lstTestCases.AllowUserToResizeRows = false;
            this.lstTestCases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lstTestCases.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.lstTestCases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstTestCases.ColumnHeadersVisible = false;
            this.lstTestCases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rwStatus,
            this.TestName});
            this.lstTestCases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTestCases.Location = new System.Drawing.Point(0, 0);
            this.lstTestCases.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstTestCases.MultiSelect = false;
            this.lstTestCases.Name = "lstTestCases";
            this.lstTestCases.ReadOnly = true;
            this.lstTestCases.RowHeadersVisible = false;
            this.lstTestCases.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.lstTestCases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lstTestCases.ShowCellErrors = false;
            this.lstTestCases.ShowCellToolTips = false;
            this.lstTestCases.ShowEditingIcon = false;
            this.lstTestCases.ShowRowErrors = false;
            this.lstTestCases.Size = new System.Drawing.Size(363, 760);
            this.lstTestCases.TabIndex = 0;
            this.lstTestCases.SelectionChanged += new System.EventHandler(this.lstTestCases_SelectedIndexChanged);
            // 
            // rwStatus
            // 
            this.rwStatus.FillWeight = 10F;
            this.rwStatus.HeaderText = "Status";
            this.rwStatus.Name = "rwStatus";
            this.rwStatus.ReadOnly = true;
            this.rwStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.rwStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TestName
            // 
            this.TestName.HeaderText = "TestName";
            this.TestName.Name = "TestName";
            this.TestName.ReadOnly = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grpTest);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grpCheck);
            this.splitContainer2.Size = new System.Drawing.Size(831, 760);
            this.splitContainer2.SplitterDistance = 380;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 5;
            // 
            // grpCheck
            // 
            this.grpCheck.Controls.Add(this.dgvChecks);
            this.grpCheck.Controls.Add(this.panel1);
            this.grpCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCheck.Location = new System.Drawing.Point(0, 0);
            this.grpCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCheck.Name = "grpCheck";
            this.grpCheck.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCheck.Size = new System.Drawing.Size(831, 374);
            this.grpCheck.TabIndex = 0;
            this.grpCheck.TabStop = false;
            this.grpCheck.Text = "Checks";
            // 
            // dgvChecks
            // 
            this.dgvChecks.AllowUserToAddRows = false;
            this.dgvChecks.AllowUserToDeleteRows = false;
            this.dgvChecks.AllowUserToOrderColumns = true;
            this.dgvChecks.AllowUserToResizeRows = false;
            this.dgvChecks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChecks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChecks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCondition,
            this.clmName2,
            this.clmCheckValue});
            this.dgvChecks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChecks.Location = new System.Drawing.Point(4, 61);
            this.dgvChecks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvChecks.Name = "dgvChecks";
            this.dgvChecks.RowHeadersVisible = false;
            this.dgvChecks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChecks.Size = new System.Drawing.Size(823, 308);
            this.dgvChecks.TabIndex = 0;
            this.dgvChecks.SelectionChanged += new System.EventHandler(this.dgvChecks_SelectionChanged);
            // 
            // clmCondition
            // 
            this.clmCondition.HeaderText = "Condition";
            this.clmCondition.Name = "clmCondition";
            // 
            // clmName2
            // 
            this.clmName2.HeaderText = "Name";
            this.clmName2.Name = "clmName2";
            // 
            // clmCheckValue
            // 
            this.clmCheckValue.HeaderText = "Value";
            this.clmCheckValue.Name = "clmCheckValue";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtActiveObject);
            this.panel1.Controls.Add(this.btnSetActiveObject);
            this.panel1.Controls.Add(this.lblActiveObject);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 37);
            this.panel1.TabIndex = 1;
            // 
            // txtActiveObject
            // 
            this.txtActiveObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtActiveObject.Location = new System.Drawing.Point(103, 0);
            this.txtActiveObject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtActiveObject.Name = "txtActiveObject";
            this.txtActiveObject.ReadOnly = true;
            this.txtActiveObject.Size = new System.Drawing.Size(656, 26);
            this.txtActiveObject.TabIndex = 4;
            // 
            // btnSetActiveObject
            // 
            this.btnSetActiveObject.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSetActiveObject.Location = new System.Drawing.Point(759, 0);
            this.btnSetActiveObject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSetActiveObject.Name = "btnSetActiveObject";
            this.btnSetActiveObject.Size = new System.Drawing.Size(64, 37);
            this.btnSetActiveObject.TabIndex = 5;
            this.btnSetActiveObject.Text = "Set";
            this.btnSetActiveObject.UseVisualStyleBackColor = true;
            this.btnSetActiveObject.Click += new System.EventHandler(this.btnSetActiveObject_Click);
            // 
            // lblActiveObject
            // 
            this.lblActiveObject.AutoSize = true;
            this.lblActiveObject.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblActiveObject.Location = new System.Drawing.Point(0, 0);
            this.lblActiveObject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActiveObject.Name = "lblActiveObject";
            this.lblActiveObject.Size = new System.Drawing.Size(103, 20);
            this.lblActiveObject.TabIndex = 3;
            this.lblActiveObject.Text = "Active object:";
            // 
            // XMLFileDialog
            // 
            this.XMLFileDialog.FileName = "XmlFile";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 857);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.Text = "IIQ Test Suite";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActions)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstTestCases)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grpCheck.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecks)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton btnPlay;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    private System.Windows.Forms.GroupBox grpTest;
    private System.Windows.Forms.DataGridView dgvActions;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmAction;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmCategory;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmValue;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.ToolStripProgressBar tlstpProgress;
    private System.Windows.Forms.ToolStripButton btnStop;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.GroupBox grpCheck;
    private System.Windows.Forms.DataGridView dgvChecks;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TextBox txtActiveObject;
    private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    private System.Windows.Forms.ToolStripMenuItem closeAllTestsToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton tsbtnOpen;
    private System.Windows.Forms.ToolStripButton toolStripButton2;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton btnPlayAll;
    private System.Windows.Forms.DataGridView lstTestCases;
    private System.Windows.Forms.DataGridViewImageColumn rwStatus;
    private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
    private System.Windows.Forms.Button btnSetActiveObject;
    private System.Windows.Forms.Label lblActiveObject;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmCondition;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmName2;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmCheckValue;
        private System.Windows.Forms.ToolStripButton GenerateButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.OpenFileDialog XMLFileDialog;
    }
}

