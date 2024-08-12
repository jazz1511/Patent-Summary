using add_patent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml;

namespace Patent_Summary
{
    public partial class Form_PropData : Form
    {
        int index = -1;
        bool modify = false;

        public Form_PropData()
        {
            InitializeComponent();
        }

        public Form_PropData(int index_num)
        {
            InitializeComponent();

            modify = true;
            index = index_num;

            XmlDocument doc = new XmlDocument();
            doc.Load("temp_AddNew.xml");
            XmlNode root = doc.DocumentElement;

            textBox1.Text = root.ChildNodes[index].Attributes["name"]?.InnerText;
            textBox2.Text = root.ChildNodes[index].SelectNodes("value")[0].InnerText;
            textBox4.Text = root.ChildNodes[index].Attributes["unit"]?.InnerText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (modify)
            {
                Form_AddNew form_AddNew = Application.OpenForms.OfType<Form_AddNew>().FirstOrDefault();
                string str = textBox1.Text.Trim() + ": " + textBox2.Text.Trim() + " " + textBox4.Text.Trim();
                form_AddNew.treeView3.SelectedNode.Text = str;
            }
            else
            {
                Form_AddNew form_AddNew = Application.OpenForms.OfType<Form_AddNew>().FirstOrDefault();
                string str = textBox1.Text.Trim() + ": " + textBox2.Text.Trim() + " " + textBox4.Text.Trim();
                if (form_AddNew.treeView3.Nodes.Count == 0)
                    form_AddNew.treeView3.Nodes.Add("Properties");
                form_AddNew.treeView3.Nodes[0].Nodes.Add(str);
            }

            XmlWriterSettings xmls = new XmlWriterSettings();
            xmls.Indent = true;
            xmls.Encoding = Encoding.UTF8;

            XmlWriter xmlw = XmlWriter.Create("temp_PropData.xml", xmls);
            xmlw.WriteStartDocument();
            xmlw.WriteStartElement("prop_data");
            xmlw.WriteAttributeString("flag", "1");

            xmlw.WriteStartElement("property");
            xmlw.WriteAttributeString("name", textBox1.Text.Trim());
            xmlw.WriteAttributeString("unit", textBox4.Text.Trim());

            xmlw.WriteStartElement("value");
            xmlw.WriteString(textBox2.Text.Trim());
            xmlw.WriteEndElement();

            xmlw.WriteEndDocument();
            xmlw.Close();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlWriterSettings xmls = new XmlWriterSettings();
            xmls.Indent = true;
            xmls.Encoding = Encoding.UTF8;

            XmlWriter xmlw = XmlWriter.Create("temp_PropData.xml", xmls);
            xmlw.WriteStartDocument();
            xmlw.WriteStartElement("prop_data");
            xmlw.WriteAttributeString("flag", "0");

            xmlw.WriteEndDocument();
            xmlw.Close();

            this.Close();
        }
    }
}
