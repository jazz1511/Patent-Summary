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

namespace Patent_Summary
{
    public partial class Form_DetailView : Form
    {
        DataTable dataTable_chem = new DataTable();
        DataTable dataTable_proc = new DataTable();
        DataTable dataTable_prop = new DataTable();
        public Form_DetailView(int index)
        {
            InitializeComponent();

            XmlDocument doc = new XmlDocument();
            doc.Load("patent_data.xml");
            XmlNode root = doc.DocumentElement;
            int i;

            if (root != null)
            {
                label5.Text = root.ChildNodes[index].Attributes["id"]?.InnerText;
                label6.Text = root.ChildNodes[index].Attributes["owner"]?.InnerText;
                label7.AutoSize = true;
                label7.Text = root.ChildNodes[index].Attributes["name"]?.InnerText;
                label8.Text = root.ChildNodes[index].Attributes["segment"]?.InnerText;

                //  Abstract Data
                richTextBox1.Text = root.ChildNodes[index].SelectNodes("abstract")[0].InnerText;

                //  Chemistry Data
                dataTable_chem.Columns.Add("S.No.", typeof(int));
                dataTable_chem.Columns.Add("Element", typeof(string));
                dataTable_chem.Columns.Add("Range", typeof(string));

                i = 0;
                foreach (XmlNode child in root.ChildNodes[index].SelectNodes("chemistry"))
                {
                    i++;
                    dataTable_chem.Rows.Add(i, child.Attributes["element"]?.InnerText,
                        child.FirstChild.InnerText + " - " + child.LastChild.InnerText + " " + child.Attributes["unit"]?.InnerText);
                }

                dataGridView1.DataSource = dataTable_chem;
                dataGridView1.Columns[0].Width = 120;
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //  Process Data
                dataTable_proc.Columns.Add("S.No.", typeof(int));
                dataTable_proc.Columns.Add("Step", typeof(string));
                dataTable_proc.Columns.Add("Claim", typeof(string));
                dataTable_proc.Columns.Add("Detail", typeof(string));

                i = 0;
                foreach (XmlNode child in root.ChildNodes[index].SelectNodes("process"))
                {
                    i++;
                    dataTable_proc.Rows.Add(i, child.Attributes["step"]?.InnerText, child.FirstChild.InnerText, child.LastChild.InnerText);
                }

                dataGridView2.DataSource = dataTable_proc;
                dataGridView2.Columns[0].Width = 120;
                dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView2.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView2.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView2.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                //  Property Data
                dataTable_prop.Columns.Add("S.No.", typeof(int));
                dataTable_prop.Columns.Add("Property", typeof(string));
                dataTable_prop.Columns.Add("Value", typeof(string));

                i = 0;
                foreach (XmlNode child in root.ChildNodes[index].SelectNodes("property"))
                {
                    i++;
                    dataTable_prop.Rows.Add(i, child.Attributes["name"]?.InnerText, child.FirstChild.InnerText + " " + child.Attributes["unit"]?.InnerText);
                }

                dataGridView3.DataSource = dataTable_prop;
                dataGridView3.Columns[0].Width = 120;
                dataGridView3.Columns[1].Width = 500;
                dataGridView3.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView3.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView3.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                //  Miscellaneous Data
                richTextBox2.Text = root.ChildNodes[index].SelectNodes("miscellaneous")[0].InnerText;
                
            }
        }

    }
}
