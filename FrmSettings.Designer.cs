namespace TestSuite
{
  partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpConnectionSettings = new System.Windows.Forms.GroupBox();
            this.txtSpAdminPassword = new System.Windows.Forms.TextBox();
            this.txtSpAdminUserName = new System.Windows.Forms.TextBox();
            this.lblSpAdminPassword = new System.Windows.Forms.Label();
            this.lblSpAdminUserName = new System.Windows.Forms.Label();
            this.txtIIQAddress = new System.Windows.Forms.TextBox();
            this.lblIIQAddress = new System.Windows.Forms.Label();
            this.IExplorerButton = new System.Windows.Forms.Button();
            this.FFButton = new System.Windows.Forms.Button();
            this.GCButton = new System.Windows.Forms.Button();
            this.grpConnectionSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(946, 328);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(825, 328);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpConnectionSettings
            // 
            this.grpConnectionSettings.Controls.Add(this.GCButton);
            this.grpConnectionSettings.Controls.Add(this.FFButton);
            this.grpConnectionSettings.Controls.Add(this.IExplorerButton);
            this.grpConnectionSettings.Controls.Add(this.txtSpAdminPassword);
            this.grpConnectionSettings.Controls.Add(this.txtSpAdminUserName);
            this.grpConnectionSettings.Controls.Add(this.lblSpAdminPassword);
            this.grpConnectionSettings.Controls.Add(this.lblSpAdminUserName);
            this.grpConnectionSettings.Controls.Add(this.txtIIQAddress);
            this.grpConnectionSettings.Controls.Add(this.lblIIQAddress);
            this.grpConnectionSettings.Location = new System.Drawing.Point(18, 18);
            this.grpConnectionSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpConnectionSettings.Name = "grpConnectionSettings";
            this.grpConnectionSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpConnectionSettings.Size = new System.Drawing.Size(1041, 275);
            this.grpConnectionSettings.TabIndex = 2;
            this.grpConnectionSettings.TabStop = false;
            this.grpConnectionSettings.Text = "Connection settings";
            // 
            // txtSpAdminPassword
            // 
            this.txtSpAdminPassword.Location = new System.Drawing.Point(182, 117);
            this.txtSpAdminPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSpAdminPassword.Name = "txtSpAdminPassword";
            this.txtSpAdminPassword.Size = new System.Drawing.Size(236, 26);
            this.txtSpAdminPassword.TabIndex = 5;
            this.txtSpAdminPassword.UseSystemPasswordChar = true;
            // 
            // txtSpAdminUserName
            // 
            this.txtSpAdminUserName.Location = new System.Drawing.Point(182, 77);
            this.txtSpAdminUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSpAdminUserName.Name = "txtSpAdminUserName";
            this.txtSpAdminUserName.Size = new System.Drawing.Size(236, 26);
            this.txtSpAdminUserName.TabIndex = 4;
            // 
            // lblSpAdminPassword
            // 
            this.lblSpAdminPassword.AutoSize = true;
            this.lblSpAdminPassword.Location = new System.Drawing.Point(15, 123);
            this.lblSpAdminPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpAdminPassword.Name = "lblSpAdminPassword";
            this.lblSpAdminPassword.Size = new System.Drawing.Size(144, 20);
            this.lblSpAdminPassword.TabIndex = 3;
            this.lblSpAdminPassword.Text = "Spadmin password";
            // 
            // lblSpAdminUserName
            // 
            this.lblSpAdminUserName.AutoSize = true;
            this.lblSpAdminUserName.Location = new System.Drawing.Point(15, 82);
            this.lblSpAdminUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpAdminUserName.Name = "lblSpAdminUserName";
            this.lblSpAdminUserName.Size = new System.Drawing.Size(155, 20);
            this.lblSpAdminUserName.TabIndex = 2;
            this.lblSpAdminUserName.Text = "Spadmin user name:";
            // 
            // txtIIQAddress
            // 
            this.txtIIQAddress.Location = new System.Drawing.Point(182, 37);
            this.txtIIQAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIIQAddress.Name = "txtIIQAddress";
            this.txtIIQAddress.Size = new System.Drawing.Size(848, 26);
            this.txtIIQAddress.TabIndex = 1;
            this.txtIIQAddress.TextChanged += new System.EventHandler(this.txtIIQAddress_TextChanged);
            // 
            // lblIIQAddress
            // 
            this.lblIIQAddress.AutoSize = true;
            this.lblIIQAddress.Location = new System.Drawing.Point(10, 42);
            this.lblIIQAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIIQAddress.Name = "lblIIQAddress";
            this.lblIIQAddress.Size = new System.Drawing.Size(96, 20);
            this.lblIIQAddress.TabIndex = 0;
            this.lblIIQAddress.Text = "IIQ address:";
            // 
            // IExplorerButton
            // 
            this.IExplorerButton.BackColor = System.Drawing.Color.Gray;
            this.IExplorerButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("IExplorerButton.BackgroundImage")));
            this.IExplorerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.IExplorerButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.IExplorerButton.FlatAppearance.BorderSize = 0;
            this.IExplorerButton.ForeColor = System.Drawing.Color.Black;
            this.IExplorerButton.Location = new System.Drawing.Point(182, 151);
            this.IExplorerButton.Name = "IExplorerButton";
            this.IExplorerButton.Size = new System.Drawing.Size(53, 42);
            this.IExplorerButton.TabIndex = 6;
            this.IExplorerButton.UseVisualStyleBackColor = false;
            this.IExplorerButton.Click += new System.EventHandler(this.IExplorerButton_Click);
            // 
            // FFButton
            // 
            this.FFButton.BackColor = System.Drawing.Color.Gray;
            this.FFButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FFButton.BackgroundImage")));
            this.FFButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FFButton.Location = new System.Drawing.Point(253, 151);
            this.FFButton.Name = "FFButton";
            this.FFButton.Size = new System.Drawing.Size(53, 42);
            this.FFButton.TabIndex = 7;
            this.FFButton.UseVisualStyleBackColor = false;
            this.FFButton.Click += new System.EventHandler(this.FFButton_Click);
            // 
            // GCButton
            // 
            this.GCButton.BackColor = System.Drawing.Color.Gray;
            this.GCButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GCButton.BackgroundImage")));
            this.GCButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GCButton.Location = new System.Drawing.Point(326, 151);
            this.GCButton.Name = "GCButton";
            this.GCButton.Size = new System.Drawing.Size(53, 42);
            this.GCButton.TabIndex = 8;
            this.GCButton.UseVisualStyleBackColor = false;
            this.GCButton.Click += new System.EventHandler(this.GCButton_Click);
            // 
            // FrmSettings
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1077, 382);
            this.Controls.Add(this.grpConnectionSettings);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmSettings";
            this.Text = "Settings";
            this.grpConnectionSettings.ResumeLayout(false);
            this.grpConnectionSettings.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.GroupBox grpConnectionSettings;
    private System.Windows.Forms.TextBox txtIIQAddress;
    private System.Windows.Forms.Label lblIIQAddress;
    private System.Windows.Forms.TextBox txtSpAdminPassword;
    private System.Windows.Forms.TextBox txtSpAdminUserName;
    private System.Windows.Forms.Label lblSpAdminPassword;
    private System.Windows.Forms.Label lblSpAdminUserName;
        private System.Windows.Forms.Button GCButton;
        private System.Windows.Forms.Button FFButton;
        private System.Windows.Forms.Button IExplorerButton;
    }
}