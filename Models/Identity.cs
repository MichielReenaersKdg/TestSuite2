using System;
using System.Xml.Serialization;

namespace TestSuite.Model
{
  [XmlRoot("Identity")]
  public class Identity
  {
    [XmlElement("FirstName")]
    public string FirstName { get; set; }

    [XmlElement("MiddleName")]
    public string MiddleName { get; set; }

    [XmlElement("LastName")]
    public string LastName { get; set; }

    [XmlElement("DateOfBirth")]
    public DateTime DateOfBirth { get; set; }

    [XmlElement("Gender")]
    public string Gender { get; set; }

    [XmlElement("Email")]
    public string Email { get; set; }

    [XmlElement("ContactEmail")]
    public string ContactEmail { get; set; }

    [XmlElement("BusinessMobilePhone")]
    public string BusinessMobilePhone { get; set; }

    [XmlElement("Username")]
    public string Username { get; set; }

    [XmlElement("Password")]
    public string Password { get; set; }
  }
}
