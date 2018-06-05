namespace TestSuite.Models
{
  public class Step
  {
    public Step(string action, string category, string name, string value)
    {
      this.Action = action;
      this.Category = category;
      this.Name = name;
      this.Value = value;
      this.Status = StepStatus.Pending;
    }
    public string Action { get; set; }
    public string Category { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public StepStatus Status { get; set; }

  }

  public enum StepStatus
  {
    Pending, Completed, Error
  }
}
