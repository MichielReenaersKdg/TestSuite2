using System.Xml.Serialization;

namespace TestSuite.Model
{
  [XmlRoot("Retailer")]
  public class Retailer
  {
    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("Code")]
    public string Code { get; set; }

    [XmlElement("Address")]
    public string Address { get; set; }

    [XmlElement("City")]
    public string City { get; set; }

    [XmlElement("PostalCode")]
    public string PostalCode { get; set; }

    [XmlElement("RegionZone")]
    public string RegionZone { get; set; }

    [XmlElement("Phone")]
    public string Phone { get; set; }

    [XmlElement("LexusOrToyota")]
    public string LexusOrToyota { get; set; }

    [XmlElement("UOID")]
    public string UOID { get; set; }
  }
}
