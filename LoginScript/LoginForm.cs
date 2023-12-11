namespace LoginScript
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserManager userManager = new UserManager();
            bool success = userManager.Login(txtUsername.Text, txtPassword.Text);
            if (success)
            {
                MessageBox.Show("Login successful!");
                // Navigate to main application window
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btngotoRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
            this.Hide();
        }
    
    }
}