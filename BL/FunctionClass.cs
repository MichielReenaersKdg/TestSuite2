using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestSuiteModels.Extensions;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TestSuite.BL
{
    public class FunctionClass
    {
        public XPathNavigator XpathNavigator(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            return doc.CreateNavigator().SelectSingleNode("*");
        }

        public string XpathValue(string xpath, string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            return doc.DocumentElement.SelectSingleNode(xpath).Value;
        }

        public XPathNavigator FindAndReplaceTokens(XPathNavigator nav, string[,] paramList)
        {
            foreach (XPathNavigator n in nav.Select("//@*"))
            {
                for (int i = 0; i < paramList.GetLength(0); i++)
                {
                    if (n.Value.Contains(paramList[i, 0]))
                    {
                        n.SetValue(n.Value.Replace(paramList[i, 0], paramList[i, 1]));
                    }

                }
            }

            return nav;
        }

        public string CodeCreator(XPathNavigator p, string fileName)
        {
            string result = "";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using (FileStream fs = File.Create(fileName))
            {
                CodeGenerator cg = new CodeGenerator();
                Byte[] info = new UTF8Encoding(true).GetBytes(cg.createTextFile(p.SelectSingleNode("@value").Value));
                fs.Write(info, 0, info.Length);
            }
            if (CodeCompiler.CompileExecutable(fileName))
            {
                result = Process.Start(fileName.Split('.').FirstOrDefault() + ".exe").StandardOutput.ReadToEnd();
                
            }
            return result;
        }

        public void ExecuteSQL(string sqlCommand, string connectionString)
        {
            SqlConnection sc = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = sqlCommand;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = sc;

            sc.Open();

            reader = cmd.ExecuteReader();

            sc.Close();
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

        public static Dictionary<string, string> GetIIQObjectAttributes(string objectId, string objectType = "Identity")
        {
            Dictionary<string, string> returnValue = new Dictionary<string, string>();

            string identityDetails = GetIIQObject(objectType, objectId);

            JObject results = (JObject)JsonConvert.DeserializeObject(identityDetails);

            if (!results["objects"].HasValues)
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

    }
}
