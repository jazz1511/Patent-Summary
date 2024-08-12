using Patent_Summary;
using System.Text;
using System.Xml;

namespace add_patent
{
    public partial class Form_AddNew : Form
    {
        public Form_AddNew()
        {
            InitializeComponent();

            if (!File.Exists("default_segment.txt"))
                File.WriteAllText("default_segment.txt", "Automotive");
            else
                comboBox1.Text = File.ReadAllText("default_segment.txt");

            XmlWriterSettings xmls = new XmlWriterSettings();
            xmls.Indent = true;
            xmls.Encoding = Encoding.UTF8;

            XmlWriter xmlw = XmlWriter.Create("temp_AddNew.xml", xmls);
            xmlw.WriteStartDocument();
            xmlw.WriteStartElement("patent_data");
            xmlw.WriteEndDocument();
            xmlw.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_ProcData form_ProcData = new Form_ProcData();
            //form_ProcData.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_ProcData_FormClosed);
            form_ProcData.FormClosed += (sender, e) => form_ProcData_FormClosed(sender, e);
            DialogResult dialogResult = form_ProcData.ShowDialog();

            treeView1.ExpandAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_ChemData form_ChemData = new Form_ChemData();
            //form_ChemData.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_ChemData_FormClosed);
            form_ChemData.FormClosed += (sender, e) => form_ChemData_FormClosed(sender, e);
            DialogResult dialogResult = form_ChemData.ShowDialog();

            treeView2.ExpandAll();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form_ChemDataMult form_ChemDataMult = new Form_ChemDataMult();
            //form_ChemData.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_ChemData_FormClosed);
            form_ChemDataMult.FormClosed += (sender, e) => form_ChemDataMult_FormClosed(sender, e);
            DialogResult dialogResult = form_ChemDataMult.ShowDialog();

            treeView2.ExpandAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_PropData form_PropData = new Form_PropData();
            //form_PropData.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_PropData_FormClosed);
            form_PropData.FormClosed += (sender, e) => form_PropData_FormClosed(sender, e);
            DialogResult dialogResult = form_PropData.ShowDialog();

            treeView3.ExpandAll();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;

            int index = -1;
            bool modify = false;

            XmlDocument doc = new XmlDocument();
            doc.Load("temp_AddNew.xml");
            XmlNode root = doc.DocumentElement;

            for (int i = 0; i < root.ChildNodes.Count; ++i)
            {
                if (root.ChildNodes[i].Name != "process")
                    continue;

                if (root.ChildNodes[i].Attributes["step"]?.InnerText == treeView1.SelectedNode.Text)
                {
                    index = i;
                    modify = true;
                    break;
                }
            }

            Form_ProcData form_ProcData = new Form_ProcData(index);
            form_ProcData.FormClosed += (sender, e) => form_ProcData_FormClosed(sender, e, modify, index);
            DialogResult dialogResult = form_ProcData.ShowDialog();

            treeView1.ExpandAll();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (treeView2.SelectedNode == null)
                return;

            int index = -1;
            bool modify = false;

            XmlDocument doc = new XmlDocument();
            doc.Load("temp_AddNew.xml");
            XmlNode root = doc.DocumentElement;

            for (int i = 0; i < root.ChildNodes.Count; ++i)
            {
                if (root.ChildNodes[i].Name != "chemistry")
                    continue;

                if (root.ChildNodes[i].Attributes["element"]?.InnerText == treeView2.SelectedNode.Text.Split(":")[0])
                {
                    index = i;
                    modify = true;
                    break;
                }
            }

            Form_ChemData form_ChemData = new Form_ChemData(index);
            form_ChemData.FormClosed += (sender, e) => form_ChemData_FormClosed(sender, e, modify, index);
            DialogResult dialogResult = form_ChemData.ShowDialog();

            treeView2.ExpandAll();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (treeView3.SelectedNode == null)
                return;

            int index = -1;
            bool modify = false;

            XmlDocument doc = new XmlDocument();
            doc.Load("temp_AddNew.xml");
            XmlNode root = doc.DocumentElement;

            for (int i = 0; i < root.ChildNodes.Count; ++i)
            {
                if (root.ChildNodes[i].Name != "property")
                    continue;

                if (root.ChildNodes[i].Attributes["name"]?.InnerText == treeView3.SelectedNode.Text.Split(":")[0])
                {
                    index = i;
                    modify = true;
                    break;
                }
            }

            Form_PropData form_PropData = new Form_PropData(index);
            form_PropData.FormClosed += (sender, e) => form_PropData_FormClosed(sender, e, modify, index);
            DialogResult dialogResult = form_PropData.ShowDialog();

            treeView1.ExpandAll();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form_AutoRead form_AutoRead = new Form_AutoRead();
            DialogResult dialogResult = form_AutoRead.ShowDialog();
        }

        private void form_ProcData_FormClosed(object sender, EventArgs e, bool modify = false, int index = -1)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("temp_ProcData.xml");

            XmlNode root;
            if (doc.DocumentElement != null)
                root = doc.DocumentElement;
            else
                return;

            string flag;
            if ((root.Attributes != null) && (root.Attributes["flag"] != null))
                flag = root.Attributes["flag"].InnerText;
            else
                flag = "0";

            if (flag == "0")
                return;
            else
            {
                XmlDocument doc2 = new XmlDocument();
                doc2.Load("temp_AddNew.xml");
                XmlNode root2 = doc2.DocumentElement;

                XmlElement temp = doc2.CreateElement("Temp");
                temp.InnerXml = root.InnerXml;
                XmlNode node = temp.FirstChild;

                if (modify)
                {
                    root2.ChildNodes[index].Attributes["step"].InnerText = node.Attributes["step"]?.InnerText;
                    root2.ChildNodes[index].InnerXml = node.InnerXml;
                }
                else
                    root2.AppendChild(node);

                doc2.Save("temp_AddNew.xml");
            }

            root.RemoveAll();
            doc.Save("temp_ProcData.xml");

            return;
        }

        private void form_ChemData_FormClosed(object sender, EventArgs e, bool modify = false, int index = -1)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("temp_ChemData.xml");

            XmlNode root;
            if (doc.DocumentElement != null)
                root = doc.DocumentElement;
            else
                return;

            string flag;
            if ((root.Attributes != null) && (root.Attributes["flag"] != null))
                flag = root.Attributes["flag"].InnerText;
            else
                flag = "0";

            if (flag == "0")
                return;
            else
            {
                XmlDocument doc2 = new XmlDocument();
                doc2.Load("temp_AddNew.xml");
                XmlNode root2 = doc2.DocumentElement;

                XmlElement temp = doc2.CreateElement("Temp");
                temp.InnerXml = root.InnerXml;
                XmlNode node = temp.FirstChild;

                if (modify)
                {
                    root2.ChildNodes[index].Attributes["element"].InnerText = node.Attributes["element"]?.InnerText;
                    root2.ChildNodes[index].Attributes["unit"].InnerText = node.Attributes["unit"]?.InnerText;
                    root2.ChildNodes[index].InnerXml = node.InnerXml;
                }
                else
                    root2.AppendChild(node);

                doc2.Save("temp_AddNew.xml");
            }

            root.RemoveAll();
            doc.Save("temp_ChemData.xml");

            return;
        }

        private void form_ChemDataMult_FormClosed(object sender, EventArgs e)
        {
            
            return;
        }

        private void form_PropData_FormClosed(object sender, EventArgs e, bool modify = false, int index = -1)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("temp_PropData.xml");

            XmlNode root;
            if (doc.DocumentElement != null)
                root = doc.DocumentElement;
            else
                return;

            string flag;
            if ((root.Attributes != null) && (root.Attributes["flag"] != null))
                flag = root.Attributes["flag"].InnerText;
            else
                flag = "0";

            if (flag == "0")
                return;
            else
            {
                XmlDocument doc2 = new XmlDocument();
                doc2.Load("temp_AddNew.xml");
                XmlNode root2 = doc2.DocumentElement;

                XmlElement temp = doc2.CreateElement("Temp");
                temp.InnerXml = root.InnerXml;
                XmlNode node = temp.FirstChild;

                if (modify)
                {
                    root2.ChildNodes[index].Attributes["name"].InnerText = node.Attributes["name"]?.InnerText;
                    root2.ChildNodes[index].Attributes["unit"].InnerText = node.Attributes["unit"]?.InnerText;
                    root2.ChildNodes[index].InnerXml = node.InnerXml;
                }
                else
                    root2.AppendChild(node);

                doc2.Save("temp_AddNew.xml");
            }

            root.RemoveAll();
            doc.Save("temp_PropData.xml");

            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("temp_AddNew.xml");

            XmlNode root = doc.DocumentElement;

            XmlAttribute rootAttrib = doc.CreateAttribute("id");
            rootAttrib.Value = textBox1.Text.Trim();
            root.Attributes.Append(rootAttrib);

            rootAttrib = doc.CreateAttribute("owner");
            rootAttrib.Value = textBox2.Text.Trim().Replace("\n", " ");
            root.Attributes.Append(rootAttrib);

            rootAttrib = doc.CreateAttribute("name");
            rootAttrib.Value = textBox3.Text.Trim().Replace("\n", " ");
            root.Attributes.Append(rootAttrib);

            rootAttrib = doc.CreateAttribute("segment");
            rootAttrib.Value = comboBox1.Text.Trim().Replace("\n", " ");
            root.Attributes.Append(rootAttrib);

            rootAttrib = doc.CreateAttribute("flag");
            rootAttrib.Value = "1";
            root.Attributes.Append(rootAttrib);

            XmlElement node = doc.CreateElement("abstract");
            node.InnerText = richTextBox1.Text.Trim().Replace("\n\n", "%~").Replace("\n", " ").Replace("%~", "\n\n");
            root.AppendChild(node);

            node = doc.CreateElement("miscellaneous");
            node.InnerText = richTextBox2.Text.Trim().Replace("\n\n", "%~").Replace("\n", " ").Replace("%~", "\n\n");
            root.AppendChild(node);

            doc.Save("temp_AddNew.xml");

            File.WriteAllText("default_segment.txt", comboBox1.Text.Trim());

            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("temp_AddNew.xml");

            XmlNode root = doc.DocumentElement;

            XmlAttribute rootAttrib = doc.CreateAttribute("flag");
            rootAttrib.Value = "0";
            root.Attributes.Append(rootAttrib);

            doc.Save("temp_AddNew.xml");
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;

            string selectedNodeText_proc = treeView1.SelectedNode.Text;
            treeView1.SelectedNode.Remove();

            XmlDocument doc = new XmlDocument();
            doc.Load("temp_AddNew.xml");
            XmlNode root = doc.DocumentElement;

            if (root == null)
                return;
            else
            {
                if (selectedNodeText_proc == "Processes")
                {
                    foreach (XmlNode node in root.SelectNodes("process"))
                        node.ParentNode.RemoveChild(node);

                    doc.Save("temp_AddNew.xml");
                    return;
                }

                foreach (XmlNode node in root.SelectNodes("process"))
                {
                    if (node.Attributes["step"]?.InnerText == selectedNodeText_proc)
                    {
                        node.ParentNode.RemoveChild(node);
                        break;
                    }
                }

                doc.Save("temp_AddNew.xml");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (treeView2.SelectedNode == null)
                return;

            string selectedNodeText_chem = treeView2.SelectedNode.Text.Split(":")[0];
            treeView2.SelectedNode.Remove();

            XmlDocument doc = new XmlDocument();
            doc.Load("temp_AddNew.xml");
            XmlNode root = doc.DocumentElement;

            if (root == null)
                return;
            else
            {
                if (selectedNodeText_chem == "Elements")
                {
                    foreach (XmlNode node in root.SelectNodes("chemistry"))
                        node.ParentNode.RemoveChild(node);

                    doc.Save("temp_AddNew.xml");
                    return;
                }

                foreach (XmlNode node in root.SelectNodes("chemistry"))
                {
                    if (node.Attributes["element"]?.InnerText == selectedNodeText_chem)
                    {
                        node.ParentNode.RemoveChild(node);
                        break;
                    }
                }

                doc.Save("temp_AddNew.xml");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (treeView3.SelectedNode == null)
                return;

            string selectedNodeText_prop = treeView3.SelectedNode.Text.Split(":")[0];
            treeView3.SelectedNode.Remove();

            XmlDocument doc = new XmlDocument();
            doc.Load("temp_AddNew.xml");
            XmlNode root = doc.DocumentElement;

            if (root == null)
                return;
            else
            {
                if (selectedNodeText_prop == "Properties")
                {
                    foreach (XmlNode node in root.SelectNodes("property"))
                        node.ParentNode.RemoveChild(node);

                    doc.Save("temp_AddNew.xml");
                    return;
                }

                foreach (XmlNode node in root.SelectNodes("property"))
                {
                    if (node.Attributes["name"]?.InnerText == selectedNodeText_prop)
                    {
                        node.ParentNode.RemoveChild(node);
                        break;
                    }
                }

                doc.Save("temp_AddNew.xml");
            }
        }

    }
}