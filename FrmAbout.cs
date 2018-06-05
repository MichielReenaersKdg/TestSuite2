using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace TestSuite
{
  public partial class FrmAbout : Form
  {
    public FrmAbout()
    {
      InitializeComponent();

      Assembly assembly = Assembly.GetExecutingAssembly();
      lblVersion.Text = FileVersionInfo.GetVersionInfo(assembly.Location).ToString();
    }
  }
}
