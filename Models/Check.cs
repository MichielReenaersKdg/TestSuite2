namespace TestSuite.Models
{
  public class Check
  {
    public Check(string condition, string name, string value)
    {
      this.Condition = condition;
      this.Name = name;
      this.Value = value;
      this.Status = CheckStatus.Pending;
    }

    public string Condition { get; set; }

    public string Name { get; set; }

    public string Value { get; set; }

    public CheckStatus Status { get; set; }

  }

  public enum CheckStatus
  {
    Pending, Completed, Error
  }
}
