using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using TestSuiteModels.Models;

namespace TestSuite
{
    public partial class TestFileGenerator : Form
    {
        private List<Case> testCases = new List<Case>();
        private List<Check> CheckList = new List<Check>();
        public TestFileGenerator()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (TextBoxFilePath.Text == "")
            {
                MessageBox.Show("Enter a filePath first please.");
            } else
            {
                GenerateFromFile();
            }
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            bool isItemTitle = false;
            bool isItemStep = false;
            bool isItemParam = false;
            bool isItemCheck = false;

            if (listBox1.Items.Count != 0)
            {
                isItemTitle = (listBox1.GetItemText(listBox1.Items[e.Index]).Contains("Case:")) ? true : false;
                isItemStep = (listBox1.GetItemText(listBox1.Items[e.Index]).Contains("Step:")) ? true : false;
                isItemParam = (listBox1.GetItemText(listBox1.Items[e.Index]).Contains("Param:")) ? true : false;
                isItemCheck = (listBox1.GetItemText(listBox1.Items[e.Index]).Contains("Check:")) ? true : false;
            }
            
            bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            int itemIndex = e.Index;
            if (itemIndex >= 0 && itemIndex < listBox1.Items.Count)
            {
                Color c = new Color();
                Graphics g = e.Graphics;
                if (isItemSelected)
                {
                    c = Color.DarkRed;
                    int d = e.Index;
                    while (d >= 0)
                    {
                        if (listBox1.GetItemText(listBox1.Items[d]).Contains("Case:"))
                        {
                            foreach(Case h in testCases)
                            {
                                h.selected = false;
                            }
                            testCases.Find(t => t.name.Trim() == listBox1.GetItemText(listBox1.Items[d]).Split(':')[1].Trim()).selected = true;
                            d = -1;
                        }   
                        d--;
                    }

                } else if (isItemTitle)
                {
                    c = ColorTranslator.FromHtml("#199cff");
                } else if (isItemStep)
                {
                    c = ColorTranslator.FromHtml("#59b8ff");
                } else if (isItemParam)
                {
                    //#a3d6fd
                    c = Color.LightSkyBlue;
                } else if (isItemCheck)
                {
                    c = Color.Orange;
                }

                // Background Color
                SolidBrush backgroundColorBrush = new SolidBrush(c);

                g.FillRectangle(backgroundColorBrush, e.Bounds);

                // Set text color
                string itemText = listBox1.Items[itemIndex].ToString();

                SolidBrush itemTextColorBrush = (c != Color.White) ? new SolidBrush(Color.White) : new SolidBrush(Color.Black);
                g.DrawString(itemText, e.Font, itemTextColorBrush, listBox1.GetItemRectangle(itemIndex).Location);

                // Clean up
                backgroundColorBrush.Dispose();
                itemTextColorBrush.Dispose();
            }

            e.DrawFocusRectangle();
        }

        

        private void button10_Click(object sender, EventArgs e)
        {
            foreach (Case c in testCases)
            {
                c.selected = false;
            }
            Case NewCase = new Case()
            {
                name = TextBoxCaseName.Text,
                selected = true,
                steps = new List<TempStep>(),
                parameters = new List<param>()
            };
            testCases.Add(NewCase);
            showListboxItems();
            //listBox1.Items.Add("Case: " + NewCase.name);
            //listBox1.DrawItem += new DrawItemEventHandler(this.listBox1_DrawItem);
        }

        private void AddTitle(string name)
        {
            listBox1.Items.Add(name);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(Case t in testCases)
            {
                if (t.selected)
                {
                    
                }
            }
        }

        private void ButtonNewStep_Click(object sender, EventArgs e)
        {
            NewStepPanel.Visible = true;
            ParamPanel.Visible = false;
        }

        private void showListboxItems()
        {
            listBox1.Items.Clear();
            listBox1.UseTabStops = true;
            foreach (Case c in testCases)
            {
                listBox1.Items.Add("Case: " + c.name);
                foreach(param p in c.parameters)
                {
                    listBox1.Items.Add("\tParam: " + p.name);
                }

                foreach(TempStep s in c.steps)
                {
                    listBox1.Items.Add("\tStep: " + s.name);
                }
            }
            foreach (Check c in CheckList)
            {
                listBox1.Items.Add("Check: " + c.Name);
            }
            listBox1.DrawItem += new DrawItemEventHandler(this.listBox1_DrawItem);
        }

        private void SaveStep_Click(object sender, EventArgs e)
        {
            if (label2.Text.ToLower().Contains("attribute"))
            {
                label2.Text = "Value:";
                label1.Text = "Element:";
                Check ch = new Check(TextBoxElement.Text, TextBoxElement.Text + TextBoxValue.Text, TextBoxValue.Text);
                CheckList.Add(ch);
            } else
            {

            if (ListBoxExtension.CheckedItems.Count == 0)
            {
                MessageBox.Show("Extension not filled in!");
            }
            TempStep t = new TempStep()
            {
                extension = ListBoxExtension.GetItemText(ListBoxExtension.CheckedItems[0]),
                action = (ListBoxAction.CheckedItems.Count == 0)? "" : ListBoxAction.GetItemText(ListBoxAction.CheckedItems[0]),
            };
            switch (forceFields(t))
            {
                case 0:
                    t.value = TextBoxValue.Text;
                    break;
                case 1:
                    t.element = TextBoxElement.Text;
                    t.value = TextBoxValue.Text;
                    break;
                case 2:
                    t.element = TextBoxElement.Text;
                    t.value = TextBoxValue.Text;
                    break;
            }
            t.name = t.extension;
            if (t.extension != "Navigate")
            {
                t.name += (" | " + t.element + " | " + t.action);
            }
            else
            {
                t.name += (" | " + t.value);
            }

            foreach (Case c in testCases)
            {
                if (c.selected)
                {
                    if (c.steps.Exists(p => p.name == t.name))
                    {
                        int i = c.steps.IndexOf(c.steps.Find(p => p.name == t.name));
                        c.steps[i] = t;
                    } else
                    {
                        c.steps.Add(t);
                    }
                    
                }
            }

            }
            showListboxItems();
            
        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void ButtonNewParam_Click(object sender, EventArgs e)
        {
            ParamPanel.Visible = true;
            NewStepPanel.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //switch ()
            if (checkedListBox1.SelectedItems.Count == 0 || textBox1.Text == "" || textBox3.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Not all necessary fields have been filled in!");
            }
            else
            {
                foreach (Case c in testCases)
                {
                    if (c.selected)
                    {
                        param p = new param();
                        p.isActive = true;
                        p.file = textBox3.Text;
                        p.value = textBox1.Text;
                        p.name = textBox2.Text;
                        p.type = checkedListBox1.GetItemText(checkedListBox1.CheckedItems[0]);
                        c.parameters.Add(p);
                        showListboxItems();
                        //listBox1.Items.Add("\t Step: " + s.name);
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.GetItemText(listBox1.SelectedItem).Contains("Case:"))
            {
                NewStepPanel.Visible = false;
                ParamPanel.Visible = false;
                TextBoxCaseName.Text = testCases.Find(t => t.name.Trim() == (listBox1.GetItemText(listBox1.SelectedItem).Split(':').LastOrDefault().Trim())).name;
            } else if (listBox1.GetItemText(listBox1.SelectedItem).Contains("Param:"))
            {
                NewStepPanel.Visible = false;
                ParamPanel.Visible = true;
                Case c = new Case();
                param p = new param();

                foreach(Case y in testCases)
                {
                    foreach(param o in y.parameters)
                    {
                        if(o.name.Trim() == listBox1.GetItemText(listBox1.SelectedItem).Split(':').LastOrDefault().Trim())
                        {
                            o.isActive = true;
                            p = o;
                            c = y;
                        }
                    }
                }
                TextBoxCaseName.Text = c.name;
                textBox2.Text = p.name;
                textBox3.Text = p.file;
                textBox1.Text = p.value;
                checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(p.type), true);
            } else if (listBox1.GetItemText(listBox1.SelectedItem).Contains("Step:"))
            {
                NewStepPanel.Visible = true;
                ParamPanel.Visible = false;
                Case c = new Case();
                TempStep s = new TempStep();
                foreach (Case y in testCases)
                {
                    if (y.selected == true)
                    {
                        //y.selected = false;
                        foreach (TempStep o in y.steps)
                        {
                            int commaIn = listBox1.GetItemText(listBox1.SelectedItem).IndexOf(':');
                            o.isActive = false;
                            if (o.name.Trim() == listBox1.GetItemText(listBox1.SelectedItem).Substring(commaIn + 1).Trim())
                            {
                                //y.selected = true;
                                o.isActive = true;
                                s = o;
                                c = y;
                            }
                        }
                    }
                }

                ListBoxExtension.SetItemChecked(ListBoxExtension.Items.IndexOf(s.extension), true);
                TextBoxCaseName.Text = c.name;
                TextBoxValue.Text = "";
                TextBoxElement.Text = "";
                switch (forceFields(s))
                {
                    case 0: TextBoxValue.Text = s.value;
                        fieldManager(2, 10);
                        break;
                    case 1:
                    case 2: TextBoxElement.Text = s.element;
                        TextBoxElement.Text = s.element;
                        ListBoxAction.SetItemChecked(ListBoxAction.Items.IndexOf(s.action), true);
                        if (ListBoxAction.Items.IndexOf(s.action) != 0)
                        {
                            fieldManager(1,1);
                            TextBoxValue.Text = s.value;
                        }
                        else
                        {
                            fieldManager(1);
                            
                        }
                        break;
                    case 10:
                        TextBoxElement.Text = s.element;
                        fieldManager(0, 2);
                        if (s.action != "") {
                            ListBoxAction.SetItemChecked(ListBoxAction.Items.IndexOf(s.action), true);
                        }
                        ;
                        break;
                    default:
                        TextBoxElement.Text = s.element;
                        fieldManager(1, 1);
                        ListBoxAction.SetItemChecked(ListBoxAction.Items.IndexOf(s.action), true);
                        //TextBoxValue.Text = s.value;
                        break;
                }  
            }
        }

        private void GenerateFromFile()
        {
            string filePath = TextBoxFilePath.Text;
            BL.FunctionClass fc = new BL.FunctionClass();
            XPathNavigator nav = fc.XpathNavigator(filePath);
            XPathExpression expr = nav.Compile("//cases/case");
            XPathNodeIterator iterator = nav.Select(expr);

            testCases.Clear();
            while (iterator.MoveNext())
            {
                Case c = new Case
                {
                    name = iterator.Current.SelectSingleNode("@name").Value,
                    selected = false,
                    parameters = new List<param>(),
                    steps = new List<TempStep>()
                };
                XPathExpression paramExpr = iterator.Current.Compile("//case[@name='"+ c.name + "']/param");
                XPathNodeIterator paramIt = iterator.Current.Select(paramExpr);

                int k = 0;
                while (paramIt.MoveNext())
                {
                    param p = new param
                    {
                        name = paramIt.Current.SelectSingleNode("@name").Value,
                        isActive = false,
                        type = paramIt.Current.SelectSingleNode("@type").Value,
                        value = paramIt.Current.SelectSingleNode("@value").Value
                    };
                    if (p.type == "xPath")
                    {
                        p.file = paramIt.Current.SelectSingleNode("@file").Value;
                    }
                    c.parameters.Add(p);
                    k++;
                }

                XPathExpression stepExpr = iterator.Current.Compile("//case[@name='"+ c.name + "']/step");
                XPathNodeIterator stepIt = iterator.Current.Select(stepExpr);

                k = 0;
                while (stepIt.MoveNext())
                {
                    TempStep s = new TempStep()
                    {
                        isActive = false,
                        extension = stepIt.Current.SelectSingleNode("@extension").Value,
                        value = "",
                        element = ""

                    };
                    s.name = s.extension;

                    if (s.extension != "Navigate")
                    {
                        s.element = stepIt.Current.SelectSingleNode("@element").Value;
                        s.action = stepIt.Current.SelectSingleNode("@action").Value;

                        s.name += (" | " + s.element +" | " + s.action);
                        if (s.action == "SendKeys")
                        {
                            s.value = stepIt.Current.SelectSingleNode("@value").Value;
                        }
                    } else
                    {
                        s.value = stepIt.Current.SelectSingleNode("@value").Value;
                        s.name += (" | " + s.value);
                    }

                    k++;
                    c.steps.Add(s);
                }
                testCases.Add(c);
            }
            showListboxItems();
        }

        private void CreateFile()
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "    ",
                OmitXmlDeclaration = true
            };
            using (XmlWriter writer = XmlWriter.Create(TextBoxFilePath.Text, settings))
            {
                writer.WriteStartDocument(true);
                writer.WriteStartElement("caseContext");
                writer.WriteStartElement("cases");
                foreach (Case c in testCases)
                {
                    writer.WriteStartElement("case");
                    writer.WriteAttributeString("name", c.name);
                    foreach(param p in c.parameters)
                    {
                        writer.WriteStartElement("param");
                        writer.WriteAttributeString("name", p.name);
                        switch (forceFields(p))
                        {
                            case 0:
                                writer.WriteAttributeString("value", p.value);
                                writer.WriteAttributeString("file", p.file);
                                writer.WriteAttributeString("type", p.type);
                            break;
                            case 1:
                                writer.WriteAttributeString("value", p.value);
                                writer.WriteAttributeString("file", p.file);
                                writer.WriteAttributeString("type", p.type);
                            break;
                            case 2:
                                writer.WriteAttributeString("value", p.value);
                                writer.WriteAttributeString("file", p.file);
                                writer.WriteAttributeString("type", p.type);
                            break;
                        }
                        writer.WriteEndElement();


                    }
                    foreach(TempStep s in c.steps)
                    {
                        writer.WriteStartElement("step");
                        writer.WriteAttributeString("extension",s.extension);
                        switch (forceFields(s))
                        {
                            case 0:
                                writer.WriteAttributeString("value", s.value);
                                break;
                            case 1:
                                writer.WriteAttributeString("action", s.action);
                                writer.WriteAttributeString("element", s.element);
                                writer.WriteAttributeString("value", s.value);
                                break;
                            case 2:
                                writer.WriteAttributeString("action", s.action);
                                writer.WriteAttributeString("element", s.element);
                                break;
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }

        private void ButtonSaveAsFile_Click(object sender, EventArgs e)
        {
            CreateFile();
        }

        private int forceFields(TempStep step)
        {
            int returnValue = 10;
            switch (step.extension)
            {
                case "Navigate": returnValue = 0;break;
                case "Find":
                case "Wait": if (step.action == "SendKeys") {returnValue = 1;} else if (step.action == "Click"){ returnValue = 2; }
                     break;
            }
            return returnValue;
        }

        private int forceFields(param par)
        {
            int returnValue = 0;
            switch (par.type)
            {
                case "xPath": returnValue = 0; break;
                case "C#": returnValue = 1;  break;
                case "SQL": returnValue = 2;  break;
            }
            return returnValue;
        }

        private void fieldManager(int extension, int action = -1)
        {
            label4.Visible = true;
            ListBoxExtension.Visible = true;
            label5.Visible = false;
            ListBoxAction.Visible = false;

            //Element
            label1.Visible = false;
            TextBoxElement.Visible = false;
            ElementPlainText.Visible = false;
            ElementXPath.Visible = false;

            //Value
            label2.Visible = false;
            TextBoxValue.Visible = false;
            ValuePlainText.Visible = false;
            ValueXPath.Visible = false;

            switch (extension)
            {
                case 0:
                case 1:
                    //label5.Visible = true;
                    //ListBoxAction.Visible = true;
                    label4.Visible = true;
                    ListBoxExtension.Visible = true;
                    label5.Visible = true;
                    ListBoxAction.Visible = true;
                    break;
                case 2:
                    label4.Visible = true;
                    ListBoxExtension.Visible = true;
                    break;
            }
                switch (action)
                {
                    case 0:
                        //Element
                        label1.Visible = true;
                        TextBoxElement.Visible = true;
                        ElementPlainText.Visible = true;
                        ElementXPath.Visible = true;
                        break;
                    case 1:
                        //Element
                        label1.Visible = true;
                        TextBoxElement.Visible = true;
                        ElementPlainText.Visible = true;
                        ElementXPath.Visible = true;

                        //Value
                        label2.Visible = true;
                        TextBoxValue.Visible = true;
                        ValuePlainText.Visible = true;
                        ValueXPath.Visible = true;
                        break;
                    case -1:
                        //Action
                        label5.Visible = true;
                        ListBoxAction.Visible = true;
                        break;
                    default:
                        //Value
                        label2.Visible = true;
                        TextBoxValue.Visible = true;
                        ValuePlainText.Visible = true;
                        ValueXPath.Visible = true;
                        break;
                }

        }

        private void ListBoxExtension_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < ListBoxExtension.Items.Count; ++ix)
                    if (e.Index != ix) ListBoxExtension.SetItemChecked(ix, false);

            
            switch (e.Index)
            {
                case 0:
                case 1: fieldManager(1); break;
                case 2: fieldManager(2,10); break;
            }
        }

        private void ListBoxAction_SelectedIndexChanged(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < ListBoxAction.Items.Count; ++ix)
                    if (e.Index != ix) ListBoxAction.SetItemChecked(ix, false);
            fieldManager(1, e.Index);
            
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Are you sure you want to remove this element?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int x = -1;
                TempStep ts = new TempStep();
                Case cs = new Case();
                foreach (Case c in testCases)
                {
                    if (c.selected)
                    {
                        cs = c;
                        foreach (TempStep s in c.steps)
                        {
                            if (s.isActive)
                            {
                                ts = s;
                                int start = listBox1.Items.IndexOf("Case: " + c.name);
                                int end = listBox1.Items.IndexOf("Case: " + testCases.ElementAt(testCases.IndexOf(c) + 1).name);
                                for (int o = start; o < end; o++)
                                {
                                    int u = listBox1.Items[o].ToString().IndexOf(':');

                                    if (listBox1.Items[o].ToString().Substring(u + 1).Trim() == s.name.Trim())
                                    {
                                        x = o;
                                    }
                                }
                            }
                        }
                    }
                }
                cs.steps.Remove(ts);
                listBox1.Items.RemoveAt(x);
                listBox1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            NewStepPanel.Visible = true;
            ParamPanel.Visible = false;

            label5.Visible = false;
            ListBoxAction.Visible = false;
            ListBoxExtension.Visible = false;
            label4.Visible = false;

            //Element
            label1.Text = "Name:";
            label1.Visible = true;
            TextBoxElement.Visible = true;
            ElementPlainText.Visible = true;
            ElementXPath.Visible = true;

            //Value
            label2.Visible = true;
            label2.Text = "Attribute:";
            TextBoxValue.Visible = true;
            ValuePlainText.Visible = true;
            ValueXPath.Visible = true;

        }
    }

    class Case
    {
        public string name { get; set; }
        public List<param> parameters {get;set;}
        public List<TempStep> steps { get; set; }  
        public bool selected { get; set; }
    }

    class TempStep
    {
        public string name { get; set; }
        public string extension { get; set; }
        public string value { get; set; }
        public string action { get; set; }
        public string element { get; set; }
        public Boolean isActive { get; set; }
    }

    class param
    {
        public string type { get; set; }
        public string value { get; set; }
        public string name { get; set; }
        public string file { get; set; }
        public Boolean isActive { get; set; }
    }
}
