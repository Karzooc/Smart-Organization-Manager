using ORG.Models;
using ORG.Services;     // Make sure to include the namespace where EmployeeService is defined
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ORG.Forms
{
    public partial class EmployeeForm : Form
    {
        public static EmployeeService service = new EmployeeService();
        // I made the EmployeeService static so that it can be shared across
        // all instances of EmployeeForm,
        public EmployeeForm()
        {
            InitializeComponent();
            LoadData();
        }
        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            IdBox.ReadOnly = true;
            LoadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Back Button 
            DashboardForm dash = new DashboardForm();
            dash.Show();
            this.Hide();

        }
        void LoadData()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = null;

            dataGridView1.DataSource = service.GetAllEmployees();
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            try
            {
                employee.Id = int.Parse(IdBox.Text);
                employee.Name = NameBox.Text;
                employee.Salary = double.Parse(SalaryBox.Text);
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input: " + ex.Message);
                return;
            }
            service.AddEmployee(employee);
            MessageBox.Show("Employee added successfully!");
            // i made an object of EmployeeService and called the AddEmployee
            LoadData();
            // Refresh the DataGridView to show the new employee

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                try
                {
                    IdBox.Text = dataGridView1.CurrentRow.Cells["colId"].Value.ToString();
                    SalaryBox.Text = dataGridView1.CurrentRow.Cells["colSalary"].Value.ToString();
                    NameBox.Text = dataGridView1.CurrentRow.Cells["colName"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading employee data: " + ex.Message);
                }

            }
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            int id; string name; double salary;
            try
            {
                id = int.Parse(IdBox.Text);
                name = NameBox.Text;
                salary = double.Parse(SalaryBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input: " + ex.Message);
                return;
            }

            service.UpdateEmployee(id, name, salary);
            MessageBox.Show("Employee updated successfully!");
            LoadData();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(IdBox.Text))
            {
                MessageBox.Show("Please select an employee to delete.");
                return;
            }

            int id;
            try
            {
                id = int.Parse(IdBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input: " + ex.Message);
                return;
            }
            // MessageBox to confirm delete action
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete the employee ?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                service.DeleteEmployee(id);

                LoadData();
                MessageBox.Show("Employee deleted successfully!");

                IdBox.Text = "";
                NameBox.Text = "";
                SalaryBox.Text = "";
            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
