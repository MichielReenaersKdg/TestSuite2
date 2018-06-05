using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using SailpointToyotaDLL.Identities;

namespace TestSuite.BL
{
    public class TestObjectsHelper
    {
        private const string PersonFile = "TestPersons.csv";
        private const string RetailerFile = "TestRetailers.csv";

        internal static Identity GrabTestPerson()
        {
            Identity result = new Identity();

            //read the test persons csv file
            List<string> personLines = File.ReadLines(PersonFile).ToList();

            string[] splittedValues = personLines[1].Split(',');

            result.FirstName = splittedValues[2];
            result.LastName = splittedValues[4];
            result.MiddleName = splittedValues[3];
            result.DateOfBirth = DateTime.ParseExact(splittedValues[11], "M/d/yyyy", CultureInfo.InvariantCulture);
            result.Gender = splittedValues[0];
            result.Email = splittedValues[9];
            result.ContactEmail = splittedValues[9];
            result.BusinessMobilePhone = splittedValues[10];

            personLines.RemoveAt(1);

            File.WriteAllLines(PersonFile, personLines);

            return result;
        }

        internal static Retailer GrabTestRetailer()
        {
            Retailer result = new Retailer();

            //read the test retailers csv file
            List<string> retailerLines = File.ReadLines(RetailerFile).ToList();

            string[] splittedValues = retailerLines[1].Split(',');

            result.Name = splittedValues[1];
            result.Code = new Random().Next(100000, 999999).ToString();
            result.Address = splittedValues[2];
            result.City = splittedValues[3];
            result.PostalCode = splittedValues[4];
            result.Phone = splittedValues[6];
            result.LexusOrToyota = new Random().Next(0, 1) == 0 ? "Lexus" : "Toyota";

            retailerLines.RemoveAt(1);

            File.WriteAllLines(RetailerFile, retailerLines);

            return result;
        }
    }
}
