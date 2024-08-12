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

namespace Patent_Summary
{
    public partial class Form_AutoRead : Form
    {
        public Form_AutoRead()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_AddNew form_AddNew = Application.OpenForms.OfType<Form_AddNew>().FirstOrDefault();

            string str = richTextBox1.Text.Trim().Replace(Environment.NewLine, " ");

            //  Read Name of patent
            string[] str_arr = str.Split("Publication No");
            str = str_arr[0].Trim();
            string rem = str_arr[1].Trim();

            form_AddNew.textBox3.Text = str;

            //  Read Publication No of patent
            str_arr = rem.Split("Application No");
            str = str_arr[0].Trim();
            rem = str_arr[1].Trim() + " " + str_arr[2].Trim();

            form_AddNew.textBox1.Text = str;

            richTextBox2.Text = rem;

            //  Read Owner of patent
            str_arr = rem.Split("Current Owner");
            rem = str_arr[1].Trim();
            str_arr = rem.Split("IPC");
            str = str_arr[0].Trim();
            rem = str_arr[1].Trim();

            form_AddNew.textBox2.Text = str;

            this.Close();
        }
    }
}
