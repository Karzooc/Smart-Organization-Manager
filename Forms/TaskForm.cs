using ORG.Models;
using ORG.Services;
using System;
using System.Windows.Forms;

namespace ORG.Forms
{
    public partial class TaskForm : Form
    {
        // Using the static service to keep data consistent across the application
        public static TaskService service = new TaskService();

        public TaskForm()
        {
            InitializeComponent();
        }

        // ================= LOAD =================
        private void TaskForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Loading Status Enum into ComboBox
                comboSTA.DataSource = Enum.GetValues(typeof(ORG.Models.TaskStatus));

                // Loading Employees from EmployeeForm's static service[cite: 6, 8]
                comboEMP.DataSource = EmployeeForm.service.GetAllEmployees();
                comboEMP.DisplayMember = "Name";

                // Bind GridView[cite: 6]
                LoadData();

                // Selection event[cite: 6]
                dataGridView1.CellClick += dataGridView1_CellClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form: " + ex.Message);
            }
        }

        // ================= LOAD DATA =================
        void LoadData()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = null;
            // Getting clean array from TaskService[cite: 5, 6]
            dataGridView1.DataSource = service.GetAllTasks();
        }

        // ================= ADD =================
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TitleBox.Text))
                    throw new Exception("Title is required");

                // ✅ Improved ID Generation: Finding the maximum existing ID and adding 1[cite: 5, 6]
                int maxId = 0;
                var currentTasks = service.GetAllTasks();
                foreach (var t in currentTasks)
                {
                    if (t.Id > maxId) maxId = t.Id;
                }
                int id = maxId + 1;

                TaskItem task = new TaskItem(id, TitleBox.Text);

                task.Status = (ORG.Models.TaskStatus)comboSTA.SelectedItem;
                task.AssignedEmployee = (Employee)comboEMP.SelectedItem;

                service.AddTask(task);

                MessageBox.Show("Task added successfully!");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ================= UPDATE =================
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                    throw new Exception("Select a task first");

                TaskItem t = (TaskItem)dataGridView1.CurrentRow.DataBoundItem;

                TaskItem updated = new TaskItem(t.Id, TitleBox.Text);
                updated.Status = (ORG.Models.TaskStatus)comboSTA.SelectedItem;
                updated.AssignedEmployee = (Employee)comboEMP.SelectedItem;

                service.UpdateTask(t.Id, updated);

                MessageBox.Show("Task updated successfully!");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ================= DELETE =================
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                    throw new Exception("Select a task first");

                TaskItem t = (TaskItem)dataGridView1.CurrentRow.DataBoundItem;

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this task?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    service.DeleteTask(t.Id);

                    MessageBox.Show("Task deleted successfully!");
                    LoadData();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ================= SELECT =================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null) return;

                TaskItem t = (TaskItem)dataGridView1.CurrentRow.DataBoundItem;

                TitleBox.Text = t.Title;
                comboSTA.SelectedItem = t.Status;
                comboEMP.SelectedItem = t.AssignedEmployee;
            }
            catch
            {
                // Silently fail to avoid crashes during selection[cite: 6]
            }
        }

        // ================= CLEAR =================
        void ClearFields()
        {
            TitleBox.Clear();
            comboSTA.SelectedIndex = -1;
            comboEMP.SelectedIndex = -1;
        }

        // ================= BACK =================
        private void button4_Click(object sender, EventArgs e)
        {
            DashboardForm dash = new DashboardForm();
            dash.Show();
            this.Hide();
        }

        private void TitleBox_TextChanged(object sender, EventArgs e)
        {
        }
    }
}