namespace ORG.Forms
{
    partial class EmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            button4 = new Button();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colSalary = new DataGridViewTextBoxColumn();
            deletebtn = new Button();
            Updatebtn = new Button();
            Addbtn = new Button();
            NameBox = new TextBox();
            SalaryBox = new TextBox();
            IdBox = new TextBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.Black;
            button4.Location = new Point(32, 5);
            button4.Name = "button4";
            button4.Size = new Size(118, 32);
            button4.TabIndex = 4;
            button4.TextAlign = ContentAlignment.MiddleRight;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(button4);
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(deletebtn);
            panel2.Controls.Add(Updatebtn);
            panel2.Controls.Add(Addbtn);
            panel2.Controls.Add(NameBox);
            panel2.Controls.Add(SalaryBox);
            panel2.Controls.Add(IdBox);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1184, 661);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(242, 242, 242);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.FromArgb(4, 23, 30);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(15, 111, 111);
            dataGridViewCellStyle2.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colSalary });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(77, 168, 218);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(145, 334);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(894, 291);
            dataGridView1.TabIndex = 10;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // colId
            // 
            colId.DataPropertyName = "id";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Name";
            colName.Name = "colName";
            // 
            // colSalary
            // 
            colSalary.DataPropertyName = "Salary";
            colSalary.HeaderText = "Salary";
            colSalary.Name = "colSalary";
            // 
            // deletebtn
            // 
            deletebtn.BackColor = Color.Transparent;
            deletebtn.BackgroundImage = (Image)resources.GetObject("deletebtn.BackgroundImage");
            deletebtn.BackgroundImageLayout = ImageLayout.Stretch;
            deletebtn.Cursor = Cursors.Hand;
            deletebtn.FlatAppearance.BorderSize = 0;
            deletebtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            deletebtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            deletebtn.FlatStyle = FlatStyle.Flat;
            deletebtn.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deletebtn.ForeColor = Color.FromArgb(2, 18, 26);
            deletebtn.Location = new Point(735, 251);
            deletebtn.Margin = new Padding(0);
            deletebtn.Name = "deletebtn";
            deletebtn.Size = new Size(208, 30);
            deletebtn.TabIndex = 9;
            deletebtn.UseVisualStyleBackColor = false;
            deletebtn.Click += deletebtn_Click;
            // 
            // Updatebtn
            // 
            Updatebtn.BackColor = Color.Transparent;
            Updatebtn.BackgroundImage = (Image)resources.GetObject("Updatebtn.BackgroundImage");
            Updatebtn.BackgroundImageLayout = ImageLayout.Stretch;
            Updatebtn.Cursor = Cursors.Hand;
            Updatebtn.FlatAppearance.BorderSize = 0;
            Updatebtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Updatebtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Updatebtn.FlatStyle = FlatStyle.Flat;
            Updatebtn.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Updatebtn.ForeColor = Color.FromArgb(2, 18, 26);
            Updatebtn.Location = new Point(495, 251);
            Updatebtn.Name = "Updatebtn";
            Updatebtn.Size = new Size(208, 30);
            Updatebtn.TabIndex = 8;
            Updatebtn.UseVisualStyleBackColor = false;
            Updatebtn.Click += Updatebtn_Click;
            // 
            // Addbtn
            // 
            Addbtn.BackColor = Color.Transparent;
            Addbtn.BackgroundImage = (Image)resources.GetObject("Addbtn.BackgroundImage");
            Addbtn.BackgroundImageLayout = ImageLayout.Stretch;
            Addbtn.Cursor = Cursors.Hand;
            Addbtn.FlatAppearance.BorderSize = 0;
            Addbtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Addbtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Addbtn.FlatStyle = FlatStyle.Flat;
            Addbtn.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Addbtn.ForeColor = Color.FromArgb(2, 18, 26);
            Addbtn.Location = new Point(240, 251);
            Addbtn.Name = "Addbtn";
            Addbtn.Size = new Size(208, 30);
            Addbtn.TabIndex = 7;
            Addbtn.UseVisualStyleBackColor = false;
            Addbtn.Click += Addbtn_Click;
            // 
            // NameBox
            // 
            NameBox.Cursor = Cursors.IBeam;
            NameBox.Location = new Point(484, 182);
            NameBox.Name = "NameBox";
            NameBox.PlaceholderText = "Enter employee name";
            NameBox.Size = new Size(200, 23);
            NameBox.TabIndex = 3;
            // 
            // SalaryBox
            // 
            SalaryBox.Cursor = Cursors.IBeam;
            SalaryBox.Location = new Point(786, 182);
            SalaryBox.Name = "SalaryBox";
            SalaryBox.PlaceholderText = "Enter the employee's salary";
            SalaryBox.Size = new Size(200, 23);
            SalaryBox.TabIndex = 2;
            // 
            // IdBox
            // 
            IdBox.Cursor = Cursors.IBeam;
            IdBox.Location = new Point(202, 181);
            IdBox.Name = "IdBox";
            IdBox.PlaceholderText = "Enter the employee's ID";
            IdBox.Size = new Size(200, 23);
            IdBox.TabIndex = 1;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1184, 661);
            Controls.Add(panel2);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EmployeeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmployeeForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button button4;
        private Panel panel2;
        private TextBox NameBox;
        private TextBox SalaryBox;
        private TextBox IdBox;
        private Button Addbtn;
        private Button deletebtn;
        private Button Updatebtn;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colSalary;
    }
}