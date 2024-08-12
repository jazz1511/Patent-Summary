using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml;

namespace Patent_Summary
{
    public partial class Form_ChemDataMult : Form
    {
        string[] elements = new string[] { "C", "Mn", "S", "P", "Si", "Al", "N", "Ni", "Cu", "Cr", "Mo", "V", "Nb", "Ti", "B", "Ca", "Ca/S", "Nb+V+Ti", "CE(IIW)", "CE(Pcm)", "Al/N", "Ar3", "tnr" };

        public Form_ChemDataMult()
        {
            InitializeComponent();

            int i = 1;
            foreach (string element in elements)
                dataGridView1.Rows.Add(i++, element, "", "", "wt%");
            dataGridView1[4, elements.Length - 2].Value = "\xB0" + "C";
            dataGridView1[4, elements.Length - 1].Value = "\xB0" + "C";
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[2].Width = 300;
            dataGridView1.Columns[3].Width = 300;
            dataGridView1.Columns[4].Width = 300;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlWriterSettings xmls = new XmlWriterSettings();
            xmls.Indent = true;
            xmls.Encoding = Encoding.UTF8;

            XmlWriter xmlw = XmlWriter.Create("temp_ChemData.xml", xmls);
            xmlw.WriteStartDocument();
            xmlw.WriteStartElement("chem_data");
            xmlw.WriteAttributeString("flag", "1");

            for (int i = 0; i < dataGridView1.Rows.Count - 1; ++i)
            {
                if (dataGridView1[2, i].Value.ToString() == "" && dataGridView1[3, i].Value.ToString() == "")
                    continue;

                xmlw.WriteStartElement("chemistry");
                xmlw.WriteAttributeString("element", dataGridView1[1, i].Value.ToString());
                xmlw.WriteAttributeString("unit", dataGridView1[4, i].Value.ToString());

                xmlw.WriteStartElement("min");
                xmlw.WriteString(dataGridView1[2, i].Value.ToString());
                xmlw.WriteEndElement();

                xmlw.WriteStartElement("max");
                xmlw.WriteString(dataGridView1[3, i].Value.ToString());
                xmlw.WriteEndElement();

                xmlw.WriteEndElement();
            }

            xmlw.WriteEndDocument();
            xmlw.Close();

            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            XmlWriterSettings xmls = new XmlWriterSettings();
            xmls.Indent = true;
            xmls.Encoding = Encoding.UTF8;

            XmlWriter xmlw = XmlWriter.Create("temp_ChemData.xml", xmls);
            xmlw.WriteStartDocument();
            xmlw.WriteStartElement("chem_data");
            xmlw.WriteAttributeString("flag", "0");

            xmlw.WriteEndDocument();
            xmlw.Close();

            this.Close();
        }
    }
}
