using System.Collections.Generic;

namespace TestSuite.Models
{
  public class TestCase
  {
    public TestCase()
    {
      this.Steps = new List<Step>();
      this.Checks = new List<Check>();
    }

    public TestCase(List<Step> steps, List<Check> checks)
    {
      this.Steps = new List<Step>();
      this.Steps.AddRange(steps);

      this.Checks = new List<Check>();
      this.Checks.AddRange(checks);
    }

    public string Name { get; set; }

    public List<Step> Steps { get; set; }

    public List<Check> Checks { get; set; }
  }
}
