using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginScript
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                UserManager userManager = new UserManager();
                bool success = userManager.Register(txtUsername.Text, txtPassword.Text);
                if (success)
                {
                    MessageBox.Show("Registration successful!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username already exists. Try a different one.");
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match.");
            }

        }
    }
}
