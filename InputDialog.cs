using System;
using System.Windows.Forms;

namespace TestSuite
{
  public partial class InputDialog : Form
  {
    public InputDialog()
    {
      InitializeComponent();
    }

    public string GetInput()
    {
      return txtInput.Text;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      txtInput.Text = txtInput.Text.Trim();
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}
