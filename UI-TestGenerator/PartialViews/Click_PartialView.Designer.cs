namespace TestSuite.UI_TestGenerator.PartialViews
{
    partial class Click_PartialView
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Sleep = new System.Windows.Forms.CheckBox();
            this.Sleep_Value = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(30, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(494, 26);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // Sleep
            // 
            this.Sleep.AutoSize = true;
            this.Sleep.Location = new System.Drawing.Point(30, 140);
            this.Sleep.Name = "Sleep";
            this.Sleep.Size = new System.Drawing.Size(76, 24);
            this.Sleep.TabIndex = 2;
            this.Sleep.Text = "Sleep";
            this.Sleep.UseVisualStyleBackColor = true;
            // 
            // Sleep_Value
            // 
            this.Sleep_Value.Location = new System.Drawing.Point(136, 137);
            this.Sleep_Value.Name = "Sleep_Value";
            this.Sleep_Value.Size = new System.Drawing.Size(100, 26);
            this.Sleep_Value.TabIndex = 3;
            this.Sleep_Value.Visible = false;
            // 
            // Click_PartialView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 493);
            this.Controls.Add(this.Sleep_Value);
            this.Controls.Add(this.Sleep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Click_PartialView";
            this.Text = "Click_PartialView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Sleep;
        private System.Windows.Forms.TextBox Sleep_Value;
    }
}