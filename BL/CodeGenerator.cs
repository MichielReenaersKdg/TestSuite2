using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestSuite
{
    public class CodeGenerator
    {
        public string createTextFile(string code)
        {
            return preCode() + "return " + code + postCode();
        }

        private string preCode()
        {
            return "namespace tempns{" + "\n public class program { \n public static void Main() \n{";
        }

        private string postCode()
        {
            return "\n}\n}";
        }

    }
}
