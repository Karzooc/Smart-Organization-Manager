using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ORG.Models;
using ORG.Services;
using ORG.Forms;
using System.Linq;

namespace ORG.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        // ================= NAVIGATION BUTTONS =================
        private void Employeesbtn_Click_1(object sender, EventArgs e)
        {
            EmployeeForm employeeform = new EmployeeForm();
            employeeform.Show();
            this.Hide();
        }

        private void Tasksbtn_Click(object sender, EventArgs e)
        {
            TaskForm taskform = new TaskForm();
            taskform.Show();
            this.Hide();
        }

        private void Projectsbtn_Click(object sender, EventArgs e)
        {
            ProjectForm projectform = new ProjectForm();
            projectform.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e) // Logout button
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        // ================= UPDATE COUNTS LOGIC =================
        private void UpdateCounts()
        {
            try
            {
                // Fetch current counts from the static service instances[cite: 7, 8, 11]

                // 1. Employees Count
                int empCount = EmployeeForm.service.ReturnCount();
                label3.Text = empCount.ToString();

                // 2. Projects Count
                int project = ProjectForm.service.ReturnCount();
                label4.Text = project.ToString();

                // 3. Tasks Total Count
                int taskCount = TaskForm.service.ReturnCount();
                label5.Text = taskCount.ToString();

                // 4. Tasks Done Count
                int taskDone = TaskForm.service.ReturnCountDone();
                label6.Text = taskDone.ToString();
            }
            catch
            {
                // Fallback to zero if services are not initialized
                label3.Text = "0";
                label4.Text = "0";
                label5.Text = "0";
                label6.Text = "0";
            }
        }

        // ================= EVENTS =================
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // Initial count update when form first opens[cite: 7]
            UpdateCounts();
        }

        private void DashboardForm_Activated(object sender, EventArgs e)
        {
            // Refresh counts every time the user returns to the Dashboard[cite: 7]
            UpdateCounts();
        }

        // ================= PLACEHOLDERS (Keeping your existing events) =================
        private void label8_Click(object sender, EventArgs e) { }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void panel17_Paint(object sender, PaintEventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void panel16_Paint(object sender, PaintEventArgs e) { }
        private void panel7_Paint(object sender, PaintEventArgs e) { }
    }
}