using System;
using System.Windows.Forms;

namespace TestSuite
{
  public partial class FrmSettings : Form
  {
        private string browser = Properties.Settings.Default.IIQBrowser;
    public FrmSettings()
    {
      InitializeComponent();
      txtIIQAddress.Text = Properties.Settings.Default.IIQBaseUrl;
      txtSpAdminUserName.Text = Properties.Settings.Default.SPAdminUsername;
      txtSpAdminPassword.Text = Properties.Settings.Default.SPAdminPassword;
      switch (browser)
            {
                case "IE":IExplorerButton.BackColor = System.Drawing.Color.White;break;
                case "FF": FFButton.BackColor = System.Drawing.Color.White; break;
                case "GC": GCButton.BackColor = System.Drawing.Color.White; break;
            }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
            TestSuite.Properties.Settings.Default.IIQBaseUrl = txtIIQAddress.Text;
            TestSuite.Properties.Settings.Default.SPAdminUsername = txtSpAdminUserName.Text;
            TestSuite.Properties.Settings.Default.SPAdminPassword = txtSpAdminPassword.Text;
            TestSuite.Properties.Settings.Default.IIQBrowser = browser;
            TestSuite.Properties.Settings.Default.Save();

      this.Close();
    }

    private void txtIIQAddress_TextChanged(object sender, EventArgs e)
    {

    }

        private void IExplorerButton_Click(object sender, EventArgs e)
        {
            IExplorerButton.BackColor = System.Drawing.Color.White;
            FFButton.BackColor = System.Drawing.Color.Gray;
            GCButton.BackColor = System.Drawing.Color.Gray;
            browser = "IE";
        }

        private void FFButton_Click(object sender, EventArgs e)
        {
            FFButton.BackColor = System.Drawing.Color.White;
            IExplorerButton.BackColor = System.Drawing.Color.Gray;
            GCButton.BackColor = System.Drawing.Color.Gray;
            browser = "FF";
        }

        private void GCButton_Click(object sender, EventArgs e)
        {
            GCButton.BackColor = System.Drawing.Color.White;
            IExplorerButton.BackColor = System.Drawing.Color.Gray;
            FFButton.BackColor = System.Drawing.Color.Gray;
            browser = "GC";
        }
    }
}
