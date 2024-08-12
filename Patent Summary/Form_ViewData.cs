using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using add_patent;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml;

namespace Patent_Summary
{
    public partial class Form_ViewData : Form
    {
        DataTable dataTable = new DataTable();

        public Form_ViewData()
        {
            InitializeComponent();

            Form_Base form_Base = Application.OpenForms.OfType<Form_Base>().FirstOrDefault();

            const string pathToServiceAccountKey = @"cdm-npd-380811-37451a07dc18.json";
            string fileId;

            //  Authenticate connection to cloud
            var service = form_Base.authenticate(pathToServiceAccountKey);

            //  Update the patent_data.xml file
            fileId = form_Base.updateFile(service);

            //  Show data in the table
            XmlDocument doc = new XmlDocument();
            doc.Load("patent_data.xml");
            XmlNode root = doc.DocumentElement;

            if (root == null)
                return;
            else
            {
                dataTable.Columns.Add("Name", typeof(string));
                dataTable.Columns.Add("ID", typeof(string));
                dataTable.Columns.Add("Owner", typeof(string));
                dataTable.Columns.Add("Segment", typeof(string));

                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    dataTable.Rows.Add(new object[] {root.ChildNodes[i].Attributes["name"]?.InnerText,
                        root.ChildNodes[i].Attributes["id"]?.InnerText,
                        root.ChildNodes[i].Attributes["owner"]?.InnerText,
                        root.ChildNodes[i].Attributes["segment"]?.InnerText});
                }

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[2].Width = 500;
                dataGridView1.Columns[3].Width = 300;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            //  Status bar
            toolStripStatusLabel1.Text = "";

            //  DataGrid prop.
            dataGridView1.MultiSelect = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataTable;

            if (comboBox1.Text != "All")
                dataTable.DefaultView.RowFilter = string.Format("Segment LIKE '%{0}%'", comboBox1.Text);
            else
                dataTable.DefaultView.RowFilter = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "All")
            {
                if (comboBox2.Text == "Name")
                    dataTable.DefaultView.RowFilter = string.Format("Name LIKE '%{0}%' AND Segment LIKE '%{1}%'", textBox2.Text.Trim(), comboBox1.Text);
                else if (comboBox2.Text == "ID")
                    dataTable.DefaultView.RowFilter = string.Format("ID LIKE '%{0}%' AND Segment LIKE '%{1}%'", textBox2.Text.Trim(), comboBox1.Text);
                else if (comboBox2.Text == "Owner")
                    dataTable.DefaultView.RowFilter = string.Format("Owner LIKE '%{0}%' AND Segment LIKE '%{1}%'", textBox2.Text.Trim(), comboBox1.Text);
                else
                    dataTable.DefaultView.RowFilter = string.Format("Segment LIKE '%{0}%'", comboBox1.Text);
            }
            else
            {
                if (comboBox2.Text == "Name")
                    dataTable.DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", textBox2.Text.Trim());
                else if (comboBox2.Text == "ID")
                    dataTable.DefaultView.RowFilter = string.Format("ID LIKE '%{0}%'", textBox2.Text.Trim());
                else if (comboBox2.Text == "Owner")
                    dataTable.DefaultView.RowFilter = string.Format("Owner LIKE '%{0}%'", textBox2.Text.Trim());
                else
                    dataTable.DefaultView.RowFilter = null;
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("patent_data.xml");
                XmlNode root = doc.DocumentElement;

                if (root == null)
                    return;
                else
                {
                    int index = -1;
                    for (int i = 0; i < root.ChildNodes.Count; i++)
                    {
                        if (root.ChildNodes[i].Attributes["id"]?.InnerText == senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString())
                        {
                            index = i;
                            break;
                        }
                    }

                    if (index > -1)
                    {
                        Form_DetailView form_DetailView = new Form_DetailView(index);
                        form_DetailView.Show();
                    }
                }
            }

            return;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //toolStripStatusLabel1.Text = dataGridView1.SelectedCells.Count.ToString() + " patent(s) selected.";
        }

        private void dataGridView1_MultiSelectChanged(object sender, EventArgs e)
        {
            //toolStripStatusLabel1.Text = dataGridView1.SelectedRows.Count.ToString() + " patent(s) selected.";
        }
    }
}