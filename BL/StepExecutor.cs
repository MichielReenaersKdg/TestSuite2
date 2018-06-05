using System;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Text;
using TestSuiteModels.Models;
using SailpointToyotaDLL.Identities;
using System.Threading;
using System.ComponentModel;
using SailpointToyotaDLL.Functionality;
using System.Text.RegularExpressions;
using TestSuiteModels.Extensions;
using System.Xml.XPath;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System.Reflection;

namespace TestSuite.BL
{
    public class StepExecutor
    {
        /*event*/
        public delegate void StepCompletedDelegate(object sender, bool success, string message);

        public event StepCompletedDelegate StepCompleted;

        public delegate void AllStepsCompletedDelegate(object sender);

        public event AllStepsCompletedDelegate AllStepsCompleted;

        public delegate void AllChecksSuccessfullDelegate(object sender, EventArgs e);

        public event AllChecksSuccessfullDelegate AllChecksSuccessfull;

        public delegate void ChecksExecutedDelegate(object sender, bool checksSuccessfull);

        public event ChecksExecutedDelegate ChecksExecuted;
        //!event

        //variables
        FunctionClass fc;
        string filePath;
        XPathNavigator nav;
        dynamic driver = null;
        Identity person;
        //!variables
        public StepExecutor(string filePath)
        {
            this.filePath = filePath;
            fc = new FunctionClass();
            nav = fc.XpathNavigator(filePath);
        }
        private Identity GetNextUser()
        {
            return TestObjectsHelper.GrabTestPerson();
        }

        private string[,] CreateParamList()
        {
            person = GetNextUser();
            string[,] tempList = new string[person.GetType().GetProperties().Length, 3];
            int x = 0;
            foreach (PropertyInfo pi in person.GetType().GetProperties())
            {
                tempList[x, 0] = "$(" + pi.Name + ")";
                tempList[x, 1] = (pi.GetValue(person) == null)? null : pi.GetValue(person).ToString();
                tempList[x, 2] = "string";
                x++;
            }
            return tempList;
        }

        private string[,] CreateXmlParamList(string filePath, string paramAttribute = "//param")
        {
            XPathNodeIterator p = nav.Select(paramAttribute);
            int x = 0;
            string[,] paramList = new string[p.Count, 3];
            while (p.MoveNext())
            {
                if (p.Current.SelectSingleNode("@type").Value == "xPath")
                {
                    p.Current.SelectSingleNode("@value").SetValue(fc.XpathValue(p.Current.SelectSingleNode("@value").Value, p.Current.SelectSingleNode("@file").Value));
                }
                paramList[x, 0] = p.Current.SelectSingleNode("@name").Value;
                paramList[x, 1] = p.Current.SelectSingleNode("@value").Value;
                paramList[x, 2] = p.Current.SelectSingleNode("@type").Value;
                x++;
            }

            return paramList;
        }

        private void ReplacePlaceHolders(string filePath, string[,] paramList)
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
        }

        private void ReplacePlaceHolders(string filePath, string[,] paramList, Check check)
        {

            //foreach (XPathNavigator n in nav.Select("//case[@name='" + check. .Action + "']//@*"))
            //{
            //    for (int i = 0; i < paramList.GetLength(0); i++)
            //    {
            //        if (n.Value.Contains(paramList[i, 0]))
            //        {
            //            n.SetValue(n.Value.Replace(paramList[i, 0], paramList[i, 1]));
            //        }
            //    }
            //}

        }

        private void ReplacePlaceHolders(string filePath, string[,] paramList, Step step)
        {
            
                foreach (XPathNavigator n in nav.Select("//case[@name='" + step.Action + "']//@*"))
                {
                    for (int i = 0; i < paramList.GetLength(0); i++)
                    {
                        if (n.Value.Contains(paramList[i, 0]))
                        {
                            n.SetValue(n.Value.Replace(paramList[i, 0], paramList[i, 1]));
                        }
                    }
                }
            
        }

        public void ExecuteChecks(List<Check> checks)
        {
            bool allSuccessfull = true;
            string[,] paramList = CreateParamList();
            string[,] xmlParamList = CreateXmlParamList(filePath);

            foreach (Check check in checks)
            {
                nav = fc.XpathNavigator(filePath);
                ReplacePlaceHolders(filePath, paramList);
                ReplacePlaceHolders(filePath, xmlParamList);
                string[,] stepList = null;
                if (check.Value != null && check.Value.Contains("[ActiveObject"))
                {
                    //PropertyInfo pi = typeof(Identity).GetProperty(step.Name);
                    //stepList = new string[,]{ { "$(Step.Name)", step.Name.ToLower() , "string" }, { "$(Step.Value)", pi.GetValue(person).ToString(), "string"} };
                    stepList = new string[,] { { "$(Step.Name)", check.Name, "string" }, { "$(Step.Value)", check.Value, "string" } };
                }
                else
                {
                    stepList = new string[,] { { "$(Step.Name)", check.Name, "string" }, { "$(Step.Value)", check.Value, "string" } };

                }
                ReplacePlaceHolders(filePath, stepList, check);

                check.Status = ExecuteCheck(driver, filePath, check.Name);

                if (check.Status != CheckStatus.Completed)
                {
                    allSuccessfull = false;
                }
            }

            ChecksExecuted(this, allSuccessfull);

            if (allSuccessfull)
            {
                AllChecksSuccessfull(this, new EventArgs());
            }
        }

        private CheckStatus ExecuteCheck(RemoteWebDriver driver, string filePath, string stepName)
        {
            XPathExpression expr = nav.Compile("/caseContext/checks");
            XPathNodeIterator iterator = nav.Select(expr);
            try
            {

                //Iterate on the node set
                while (iterator.MoveNext())
                {
                    if (iterator.Current.SelectSingleNode("@name").Value == stepName)
                    {
                        XPathNodeIterator i = iterator.Current.Select("check");
                        while (i.MoveNext())
                        {
                            Console.WriteLine(iterator.Current.InnerXml);
                            XPathNavigator check = i.Current;
                            switch (check.SelectSingleNode("@extension").Value)
                            {
                                case "xpathMustMatch":
                                    IIQHelper.CheckXpathMustMatch(check.SelectSingleNode("@id").Value, check.SelectSingleNode("@value").Value);
                                    break;
                                case "mustHaveLinkWith":
                                    IIQHelper.CheckMustHaveLinkWith(check.SelectSingleNode("@id").Value, check.SelectSingleNode("@value").Value);
                                    break;

                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                return CheckStatus.Error;
            }
            return CheckStatus.Completed;
        }

        public void ExecuteSteps(List<Step> steps)
        {
            //string filePath = @"C:\Users\reenaersm\Desktop\codetest\CreateDuplicate.xml";
            switch (Properties.Settings.Default.IIQBrowser)
            {
                case "IE": driver = new InternetExplorerDriver(); break;
                case "FF": driver = new FirefoxDriver(); break;
                case "GC": driver = new ChromeDriver(); break;
            }
            string[,] paramList = CreateParamList();
            string[,] xmlParamList = CreateXmlParamList(filePath);

            
            
            foreach (Step step in steps)
            {
                nav = fc.XpathNavigator(filePath);
                ReplacePlaceHolders(filePath, paramList);
                ReplacePlaceHolders(filePath, xmlParamList);
                string[,] stepList = null;
                if (step.Value != null && step.Value.Contains("[ActiveObject"))
                {
                    //PropertyInfo pi = typeof(Identity).GetProperty(step.Name);
                    //stepList = new string[,]{ { "$(Step.Name)", step.Name.ToLower() , "string" }, { "$(Step.Value)", pi.GetValue(person).ToString(), "string"} };
                    stepList = new string[,] { { "$(Step.Name)", step.Name, "string" }, { "$(Step.Value)", step.Value, "string" } };
                } else
                {
                    stepList = new string[,]{ { "$(Step.Name)", step.Name, "string" }, { "$(Step.Value)", step.Value, "string" } };
                    
                }
                ReplacePlaceHolders(filePath, stepList, step);
                ExecuteStep(step, filePath);
            }
            //log.Debug("Triggering next step");
            
        }

        public void ExecuteStep(Step step, string filePath, int numberOfRetryAttemptsAfterError = 5)
        {
                XmlTranslator(driver, filePath, step.Action);

        }

        public void XmlTranslator(RemoteWebDriver driver, string filePath, string stepName)
        {
            XPathExpression expr = nav.Compile("/caseContext/cases/case");
            XPathNodeIterator iterator = nav.Select(expr);

            //Iterate on the node set
            while (iterator.MoveNext())
            {
                if (iterator.Current.SelectSingleNode("@name").Value == stepName)
                {
                XPathNodeIterator i = iterator.Current.Select("step");
                    while (i.MoveNext())
                    {
                        Console.WriteLine(iterator.Current.InnerXml);
                        XPathNavigator step = i.Current;
                        switch (step.SelectSingleNode("@extension").Value)
                        {
                            case "Wait":
                                if (step.SelectSingleNode("@action").Value == "Click")
                                {
                                    if (step.SelectSingleNode("@element").Value.StartsWith("#"))
                                    {
                                        Console.WriteLine(step.SelectSingleNode("@element").Value.Substring(1));
                                        driver.WaitGetElement(By.XPath(step.SelectSingleNode("@element").Value.Substring(1))).Click();
                                    }
                                    else
                                    {
                                        driver.WaitGetElement(By.XPath($"//*[@id='{step.SelectSingleNode("@element").Value}']")).Click();
                                    }


                                }
                                else if (step.SelectSingleNode("@action").Value == "SendKeys")
                                {
                                    if (step.SelectSingleNode("@element").Value.StartsWith("#"))
                                    {
                                        driver.WaitGetElement(By.XPath(step.SelectSingleNode("@element").Value.Substring(1))).SendKeys(step.SelectSingleNode("@value").Value);
                                    }
                                    else
                                    {
                                        driver.WaitGetElement(By.XPath($"//*[@id='{step.SelectSingleNode("@element").Value}']")).SendKeys(step.SelectSingleNode("@value").Value);
                                    }
                                }
                                else
                                {
                                    if (step.SelectSingleNode("@element").Value.StartsWith("#"))
                                    {
                                        driver.WaitGetElement(By.XPath(step.SelectSingleNode("@element").Value.Substring(1)));
                                    }
                                    else
                                    {
                                        driver.WaitGetElement(By.XPath($"//*[@id='{step.SelectSingleNode("@element").Value}']"));
                                    }
                                };
                                break;
                            case "Find":
                                if (step.SelectSingleNode("@action").Value == "Click")
                                {
                                    if (step.SelectSingleNode("@element").Value.StartsWith("#"))
                                    {
                                        driver.FindElement(By.XPath(step.SelectSingleNode("@element").Value.Substring(1))).Click();
                                    }
                                    else
                                    {
                                        driver.FindElement(By.XPath($"//*[@id='{step.SelectSingleNode("@element").Value}']")).Click();
                                    }
                                }
                                else if (step.SelectSingleNode("@action").Value == "SendKeys")
                                {
                                    if (step.SelectSingleNode("@element").Value.StartsWith("#"))
                                    {
                                        driver.FindElement(By.XPath(step.SelectSingleNode("@element").Value.Substring(1))).SendKeys(step.SelectSingleNode("@value").Value);
                                    }
                                    else
                                    {
                                        driver.FindElement(By.XPath($"//*[@id='{step.SelectSingleNode("@element").Value}']")).SendKeys(step.SelectSingleNode("@value").Value);
                                    }
                                }
                                else
                                {
                                    if (step.SelectSingleNode("@element").Value.StartsWith("#"))
                                    {
                                        driver.WaitGetElement(By.XPath(step.SelectSingleNode("@element").Value.Substring(1)));
                                    }
                                    else
                                    {
                                        driver.WaitGetElement(By.XPath($"//*[@id='{step.SelectSingleNode("@element").Value}']"));
                                    }
                                };
                                break;
                            case "Navigate":
                                driver.Navigate().GoToUrl(step.SelectSingleNode("@value").Value);
                                ; break;
                            case "Read":

                                if (step.SelectSingleNode("@element").Value.StartsWith("#"))
                                {
                                    driver.FindElement(By.XPath(step.SelectSingleNode("@element").Value)).GetAttribute(step.SelectSingleNode("@value").Value);
                                }
                                else
                                {
                                    driver.FindElement(By.Id(step.SelectSingleNode("@element").Value)).GetAttribute(step.SelectSingleNode("@value").Value);
                                }; break;
                        }
                    }
                }
            }

        }
    }
}
