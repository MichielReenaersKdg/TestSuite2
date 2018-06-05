using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.XPath;

namespace TestSuite
{
  public class IIQHelper
  {
    public static bool CheckMustHaveLinkWith(string identityId, string linkName)
    {
      bool hasLink = false;

      string identityDetails = GetIIQObject("Identity", identityId);

      JObject results = (JObject) JsonConvert.DeserializeObject(identityDetails);

      string xmlResult = results["objects"][0]["xml"].ToString();

      XPathDocument doc = new XPathDocument(new StringReader(xmlResult));
      XPathNavigator nav = doc.CreateNavigator();
      XPathNodeIterator iterator = nav.Select($"/Identity/Links/Link/ApplicationRef/Reference");

      foreach (XPathNavigator item in iterator)
      {
        string applicationName = item.GetAttribute("name", "");

        if(applicationName.Equals(linkName))
        {
          hasLink = true;
          break;
        }
      }


      return hasLink;
    }

    public static bool CheckXpathMustMatch(string identityId, string xpath)
    {
      string identityDetails = GetIIQObject("Identity", identityId);

      JObject results = (JObject)JsonConvert.DeserializeObject(identityDetails);

      string xmlResult = results["objects"][0]["xml"].ToString();

      XPathDocument doc = new XPathDocument(new StringReader(xmlResult));
      XPathNavigator nav = doc.CreateNavigator();
      XPathNodeIterator iterator = nav.Select(xpath);

      return iterator.Count > 0;
    }

    public static Dictionary<string, string> GetIIQObjectAttributes(string objectId, string objectType = "Identity")
    {
      Dictionary<string, string> returnValue = new Dictionary<string, string>();

      string identityDetails = GetIIQObject(objectType, objectId);

      JObject results = (JObject)JsonConvert.DeserializeObject(identityDetails);

      if(!results["objects"].HasValues)
      {
        return null;
      }

      string xmlResult = results["objects"][0]["xml"].ToString();

      XPathDocument doc = new XPathDocument(new StringReader(xmlResult));
      XPathNavigator nav = doc.CreateNavigator();
      XPathNodeIterator iterator = nav.Select($"/Identity/Attributes/Map/entry");

      foreach (XPathNavigator item in iterator)
      {
        string key = item.GetAttribute("key", "");
        string value = item.GetAttribute("value", "");

        returnValue.Add(key, value);
      }

      return returnValue;
    }

    public class DataObject
    {
      public string Name { get; set; }
    }

    private static string GetIIQObject(string objectType, string objectId)
    {
      using (HttpClient client = new HttpClient())
      {
        client.BaseAddress = new Uri($"{Properties.Settings.Default.IIQBaseUrl}/rest/debug/{objectType}/{objectId}");

        ASCIIEncoding encoding = new ASCIIEncoding();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
          Convert.ToBase64String(encoding.GetBytes(string.Format("{0}:{1}",
          Properties.Settings.Default.SPAdminUsername, Properties.Settings.Default.SPAdminPassword))));

        // Add an Accept header for JSON format.
        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

        // List data response.
        HttpResponseMessage response = client.GetAsync(string.Empty).Result;  // Blocking call!

        if (response.IsSuccessStatusCode)
        {
          // Parse the response body. Blocking!
          return response.Content.ReadAsStringAsync().Result;
        }
        else
        {
          Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
      }

      return string.Empty;
    }
  }
}
