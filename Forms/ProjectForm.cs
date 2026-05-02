using ORG.Models;
using ORG.Services;
using System;
using System.Windows.Forms;

namespace ORG.Forms
{
    public partial class ProjectForm : Form
    {
        public static ProjectService service = new ProjectService();

        public ProjectForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DashboardForm dash = new DashboardForm();
            dash.Show();
            this.Hide();
        }

        void LoadProjects()
        {
            dataGridView1.AutoGenerateColumns = false;
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = service.GetAllProjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading projects: " + ex.Message);
            }
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            try
            {
                ListTasks.DataSource = TaskForm.service.GetAllTasks();
                ListTasks.DisplayMember = "Title";

                LoadProjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Add
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Please fill all fields!");
                    return;
                }

                int id = int.Parse(txtId.Text);
                string title = txtTitle.Text;

                Project project = new Project();
                project.Id = id;
                project.Title = title;

                int count = ListTasks.SelectedItems.Count;
                TaskItem[] selectedTasks = new TaskItem[count];

                for (int i = 0; i < count; i++)
                {
                    selectedTasks[i] = (TaskItem)ListTasks.SelectedItems[i];
                }

                project.Tasks = selectedTasks;

                service.AddProject(project);

                MessageBox.Show("Project Added!");

                LoadProjects();
            }
            catch (FormatException)
            {
                MessageBox.Show("ID must be a number!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e) // Update
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Select a project first!");
                    return;
                }

                int id = int.Parse(txtId.Text);

                Project project = new Project();
                project.Id = id;
                project.Title = txtTitle.Text;

                int count = ListTasks.SelectedItems.Count;
                TaskItem[] selectedTasks = new TaskItem[count];

                for (int i = 0; i < count; i++)
                {
                    selectedTasks[i] = (TaskItem)ListTasks.SelectedItems[i];
                }

                project.Tasks = selectedTasks;

                service.UpdateProject(id, project);

                MessageBox.Show("Updated successfully!");

                LoadProjects();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid ID!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e) // Delete
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Select a project first!");
                    return;
                }

                int id = (int)dataGridView1.CurrentRow.Cells["colId"].Value;

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this project?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    service.DeleteProject(id);

                    MessageBox.Show("Deleted!");

                    LoadProjects();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    txtId.Text = dataGridView1.CurrentRow.Cells["colId"].Value.ToString();
                    txtTitle.Text = dataGridView1.CurrentRow.Cells["colTitle"].Value.ToString();

                    Project selectedProject = (Project)dataGridView1.CurrentRow.DataBoundItem;

                    for (int i = 0; i < ListTasks.Items.Count; i++)
                    {
                        ListTasks.SetSelected(i, false);
                    }

                    if (selectedProject.Tasks != null)
                    {
                        foreach (TaskItem task in selectedProject.Tasks)
                        {
                            for (int i = 0; i < ListTasks.Items.Count; i++)
                            {
                                TaskItem item = (TaskItem)ListTasks.Items[i];

                                if (item.Id == task.Id)
                                {
                                    ListTasks.SetSelected(i, true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting row: " + ex.Message);
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}