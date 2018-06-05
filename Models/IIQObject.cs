namespace TestSuite.Models
{
  class IIQObject
  {
    public IIQObject()
    {

    }

    public IIQObject(string id, string displayName)
    {
      this.Id = id;
      this.DisplayName = displayName;
    }

    public string Id { get; set; }

    public string DisplayName { get; set; }

    public override string ToString()
    {
      return $"{DisplayName} ({Id})";
    }

  }
}
