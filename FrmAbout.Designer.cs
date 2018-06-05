namespace TestSuite
{
  partial class FrmAbout
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
            this.lblIIQTestSuite = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblIIQTestSuite
            // 
            this.lblIIQTestSuite.AutoSize = true;
            this.lblIIQTestSuite.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIIQTestSuite.Location = new System.Drawing.Point(219, 58);
            this.lblIIQTestSuite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIIQTestSuite.Name = "lblIIQTestSuite";
            this.lblIIQTestSuite.Size = new System.Drawing.Size(277, 48);
            this.lblIIQTestSuite.TabIndex = 0;
            this.lblIIQTestSuite.Text = "IIQ Test Suite";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(18, 160);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(71, 20);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version: ";
            // 
            // FrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 551);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblIIQTestSuite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmAbout";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblIIQTestSuite;
    private System.Windows.Forms.Label lblVersion;
  }
}