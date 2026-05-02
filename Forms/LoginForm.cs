using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ORG.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string UserName = Usernametxt.Text.ToLower().Trim();
            string Password = Passwordtxt.Text.ToLower().Trim();

            if (UserName == "admin" && Password == "1234")
            {
                DashboardForm dash = new DashboardForm();
                MessageBox.Show("Login successful! Welcome, Admin.");
                dash.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }
    }
}
