namespace add_patent
{
    partial class Form_AddNew
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TreeNode treeNode1 = new TreeNode("Processes");
            TreeNode treeNode2 = new TreeNode("Elements");
            TreeNode treeNode3 = new TreeNode("Properties");
            contextMenuStrip1 = new ContextMenuStrip(components);
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            panel1 = new Panel();
            button7 = new Button();
            button6 = new Button();
            treeView1 = new TreeView();
            button2 = new Button();
            label3 = new Label();
            panel2 = new Panel();
            button13 = new Button();
            button8 = new Button();
            button9 = new Button();
            button3 = new Button();
            treeView2 = new TreeView();
            label4 = new Label();
            panel3 = new Panel();
            button10 = new Button();
            button11 = new Button();
            treeView3 = new TreeView();
            button4 = new Button();
            label5 = new Label();
            textBox1 = new TextBox();
            button5 = new Button();
            textBox3 = new TextBox();
            label6 = new Label();
            label7 = new Label();
            panel4 = new Panel();
            comboBox1 = new ComboBox();
            label8 = new Label();
            panel6 = new Panel();
            richTextBox1 = new RichTextBox();
            panel5 = new Panel();
            richTextBox2 = new RichTextBox();
            label9 = new Label();
            button12 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(40, 40);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.BorderSize = 2;
            button1.Location = new Point(2321, 1722);
            button1.Name = "button1";
            button1.Size = new Size(373, 90);
            button1.TabIndex = 1;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(40, 48);
            label1.Name = "label1";
            label1.Size = new Size(71, 54);
            label1.TabIndex = 2;
            label1.Text = "ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(40, 158);
            label2.Name = "label2";
            label2.Size = new Size(149, 54);
            label2.TabIndex = 4;
            label2.Text = "Owner:";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(270, 150);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(790, 70);
            textBox2.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(treeView1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(40, 560);
            panel1.Name = "panel1";
            panel1.Size = new Size(720, 1130);
            panel1.TabIndex = 6;
            // 
            // button7
            // 
            button7.Image = Patent_Summary.Resource.delete_4219;
            button7.Location = new Point(580, 374);
            button7.Name = "button7";
            button7.Size = new Size(100, 100);
            button7.TabIndex = 12;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Image = Patent_Summary.Resource.edit_clear_all_icon_180807;
            button6.Location = new Point(580, 254);
            button6.Name = "button6";
            button6.Size = new Size(100, 100);
            button6.TabIndex = 11;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            treeView1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            treeView1.Location = new Point(40, 134);
            treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Processes";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode1 });
            treeView1.Size = new Size(500, 956);
            treeView1.TabIndex = 10;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderColor = Color.White;
            button2.FlatAppearance.BorderSize = 2;
            button2.Image = Patent_Summary.Resource.addnewdocument_118445;
            button2.Location = new Point(580, 134);
            button2.Name = "button2";
            button2.Size = new Size(100, 100);
            button2.TabIndex = 9;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(217, 40);
            label3.Name = "label3";
            label3.Size = new Size(286, 54);
            label3.TabIndex = 0;
            label3.Text = "Process Details";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(button13);
            panel2.Controls.Add(button8);
            panel2.Controls.Add(button9);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(treeView2);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(800, 560);
            panel2.Name = "panel2";
            panel2.Size = new Size(720, 1128);
            panel2.TabIndex = 7;
            // 
            // button13
            // 
            button13.FlatAppearance.BorderColor = Color.White;
            button13.FlatAppearance.BorderSize = 2;
            button13.Image = Patent_Summary.Resource.add_pages_multiple_icon_217866;
            button13.Location = new Point(580, 254);
            button13.Name = "button13";
            button13.Size = new Size(100, 100);
            button13.TabIndex = 15;
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // button8
            // 
            button8.Image = Patent_Summary.Resource.delete_4219;
            button8.Location = new Point(580, 494);
            button8.Name = "button8";
            button8.Size = new Size(100, 100);
            button8.TabIndex = 14;
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Image = Patent_Summary.Resource.edit_clear_all_icon_180807;
            button9.Location = new Point(580, 374);
            button9.Name = "button9";
            button9.Size = new Size(100, 100);
            button9.TabIndex = 13;
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderColor = Color.White;
            button3.FlatAppearance.BorderSize = 2;
            button3.Image = Patent_Summary.Resource.addnewdocument_118445;
            button3.Location = new Point(580, 134);
            button3.Name = "button3";
            button3.Size = new Size(100, 100);
            button3.TabIndex = 10;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // treeView2
            // 
            treeView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            treeView2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            treeView2.Location = new Point(40, 134);
            treeView2.Name = "treeView2";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Elements";
            treeView2.Nodes.AddRange(new TreeNode[] { treeNode2 });
            treeView2.Size = new Size(500, 956);
            treeView2.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(195, 40);
            label4.Name = "label4";
            label4.Size = new Size(331, 54);
            label4.TabIndex = 1;
            label4.Text = "Chemistry Details";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(button10);
            panel3.Controls.Add(button11);
            panel3.Controls.Add(treeView3);
            panel3.Controls.Add(button4);
            panel3.Controls.Add(label5);
            panel3.Location = new Point(1560, 560);
            panel3.Name = "panel3";
            panel3.Size = new Size(720, 1128);
            panel3.TabIndex = 7;
            // 
            // button10
            // 
            button10.Image = Patent_Summary.Resource.delete_4219;
            button10.Location = new Point(580, 374);
            button10.Name = "button10";
            button10.Size = new Size(100, 100);
            button10.TabIndex = 14;
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Image = Patent_Summary.Resource.edit_clear_all_icon_180807;
            button11.Location = new Point(580, 254);
            button11.Name = "button11";
            button11.Size = new Size(100, 100);
            button11.TabIndex = 13;
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // treeView3
            // 
            treeView3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            treeView3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            treeView3.Location = new Point(40, 134);
            treeView3.Name = "treeView3";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Properties";
            treeView3.Nodes.AddRange(new TreeNode[] { treeNode3 });
            treeView3.Size = new Size(500, 956);
            treeView3.TabIndex = 12;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderColor = Color.White;
            button4.FlatAppearance.BorderSize = 2;
            button4.Image = Patent_Summary.Resource.addnewdocument_118445;
            button4.Location = new Point(580, 134);
            button4.Name = "button4";
            button4.Size = new Size(100, 100);
            button4.TabIndex = 11;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(207, 40);
            label5.Name = "label5";
            label5.Size = new Size(305, 54);
            label5.TabIndex = 2;
            label5.Text = "Property Details";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(270, 40);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(790, 70);
            textBox1.TabIndex = 8;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button5.FlatAppearance.BorderColor = Color.White;
            button5.FlatAppearance.BorderSize = 2;
            button5.Location = new Point(2818, 1722);
            button5.Name = "button5";
            button5.Size = new Size(373, 90);
            button5.TabIndex = 10;
            button5.Text = "Cancel";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(270, 260);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(790, 70);
            textBox3.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(40, 268);
            label6.Name = "label6";
            label6.Size = new Size(137, 54);
            label6.TabIndex = 11;
            label6.Text = "Name:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(40, 40);
            label7.Name = "label7";
            label7.Size = new Size(179, 54);
            label7.TabIndex = 13;
            label7.Text = "Abstract:";
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.Controls.Add(comboBox1);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(textBox3);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(textBox1);
            panel4.Controls.Add(textBox2);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(label1);
            panel4.Location = new Point(40, 40);
            panel4.Name = "panel4";
            panel4.Size = new Size(1100, 480);
            panel4.TabIndex = 14;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Automotive", "Industry & Engg.", "Pipes & Tubes", "Construction & Infra.", "Consumer Durables", "Defence & Railway" });
            comboBox1.Location = new Point(270, 370);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(790, 62);
            comboBox1.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(40, 374);
            label8.Name = "label8";
            label8.Size = new Size(190, 54);
            label8.TabIndex = 13;
            label8.Text = "Segment:";
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.Fixed3D;
            panel6.Controls.Add(richTextBox1);
            panel6.Controls.Add(label7);
            panel6.Location = new Point(1180, 40);
            panel6.Name = "panel6";
            panel6.Size = new Size(1100, 480);
            panel6.TabIndex = 15;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(40, 134);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1020, 306);
            richTextBox1.TabIndex = 14;
            richTextBox1.Text = "";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.BorderStyle = BorderStyle.Fixed3D;
            panel5.Controls.Add(richTextBox2);
            panel5.Controls.Add(label9);
            panel5.Location = new Point(2321, 40);
            panel5.Name = "panel5";
            panel5.Size = new Size(870, 1648);
            panel5.TabIndex = 16;
            // 
            // richTextBox2
            // 
            richTextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox2.Location = new Point(40, 134);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(790, 1474);
            richTextBox2.TabIndex = 16;
            richTextBox2.Text = "";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(40, 40);
            label9.Name = "label9";
            label9.Size = new Size(281, 54);
            label9.TabIndex = 15;
            label9.Text = "Miscellaneous:";
            // 
            // button12
            // 
            button12.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button12.FlatAppearance.BorderColor = Color.White;
            button12.FlatAppearance.BorderSize = 2;
            button12.Location = new Point(1814, 1722);
            button12.Name = "button12";
            button12.Size = new Size(373, 90);
            button12.TabIndex = 17;
            button12.Text = "Auto Read";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // Form_AddNew
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(3231, 1835);
            Controls.Add(button12);
            Controls.Add(panel5);
            Controls.Add(panel6);
            Controls.Add(panel4);
            Controls.Add(button5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button1);
            Name = "Form_AddNew";
            Text = "Add Patent";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private Button button1;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private Label label3;
        private Panel panel2;
        private Panel panel3;
        private Label label4;
        private Label label5;
        private Button button2;
        private Button button3;
        private Button button4;
        public TextBox textBox1;
        public TreeView treeView1;
        private Button button5;
        public TreeView treeView2;
        public TreeView treeView3;
        private Label label6;
        private Label label7;
        private Panel panel4;
        private Panel panel6;
        private Label label8;
        private Panel panel5;
        private Label label9;
        private RichTextBox richTextBox2;
        private Button button7;
        private Button button6;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        public TextBox textBox3;
        public TextBox textBox2;
        public ComboBox comboBox1;
        public RichTextBox richTextBox1;
        private Button button13;
    }
}