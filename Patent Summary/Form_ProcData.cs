using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace add_patent
{
    public partial class Form_ProcData : Form
    {
        int index = -1;
        bool modify = false;

        public Form_ProcData()
        {
            InitializeComponent();
        }

        public Form_ProcData(int index_num)
        {
            InitializeComponent();

            modify = true;
            index = index_num;

            XmlDocument doc = new XmlDocument();
            doc.Load("temp_AddNew.xml");
            XmlNode root = doc.DocumentElement;

            textBox1.Text = root.ChildNodes[index].Attributes["step"]?.InnerText;
            textBox2.Text = root.ChildNodes[index].SelectNodes("claim")[0].InnerText;
            textBox3.Text = root.ChildNodes[index].SelectNodes("detail")[0].InnerText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (modify)
            {
                Form_AddNew form_AddNew = Application.OpenForms.OfType<Form_AddNew>().FirstOrDefault();
                string str = textBox1.Text.Trim();
                form_AddNew.treeView1.SelectedNode.Text = str;
            }
            else
            {
                Form_AddNew form_AddNew = Application.OpenForms.OfType<Form_AddNew>().FirstOrDefault();
                string str = textBox1.Text.Trim();
                if (form_AddNew.treeView1.Nodes.Count == 0)
                    form_AddNew.treeView1.Nodes.Add("Processes");
                form_AddNew.treeView1.Nodes[0].Nodes.Add(str);
            }

            XmlWriterSettings xmls = new XmlWriterSettings();
            xmls.Indent = true;
            xmls.Encoding = Encoding.UTF8;

            XmlWriter xmlw = XmlWriter.Create("temp_ProcData.xml", xmls);
            xmlw.WriteStartDocument();
            xmlw.WriteStartElement("proc_data");
            xmlw.WriteAttributeString("flag", "1");

            xmlw.WriteStartElement("process");
            xmlw.WriteAttributeString("step", textBox1.Text.Trim().Replace("\n", " "));

            xmlw.WriteStartElement("claim");
            xmlw.WriteString(textBox2.Text.Trim().Replace("\n\n", "%~").Replace("\n", " ").Replace("%~", "\n\n"));
            xmlw.WriteEndElement();

            xmlw.WriteStartElement("detail");
            xmlw.WriteString(textBox3.Text.Trim().Replace("\n\n", "%~").Replace("\n", " ").Replace("%~", "\n\n"));
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

            XmlWriter xmlw = XmlWriter.Create("temp_ProcData.xml", xmls);
            xmlw.WriteStartDocument();
            xmlw.WriteStartElement("proc_data");
            xmlw.WriteAttributeString("flag", "0");

            xmlw.WriteEndDocument();
            xmlw.Close();

            this.Close();
        }
    }
}
