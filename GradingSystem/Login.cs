using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Security.Principal;

namespace GradingSystem
{
    public partial class Login : Form
    {
        private const string ConnectionString = "Server=localhost;Database=ueplhs;Uid=root";
        public Login()
        {
            InitializeComponent();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;

            string query = "SELECT role FROM accounts WHERE username = @Username AND password = @Password";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string role = result.ToString();
                        OpenMainFormBasedOnRole(role);
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                }
            }
        }
      
        private void OpenMainFormBasedOnRole(string role)
        {
           
            switch (role)
            {
                case "Adviser":
                    MessageBox.Show("Adiser");
                    break;
                case "Subject Teacher":
                    TeacherMain frmTeacher = new TeacherMain();
                    frmTeacher.ShowDialog();
                    this.Hide();
                    break;
                case "Principal":
                    PrincipalMain frmPrincipal = new PrincipalMain();
                    frmPrincipal.ShowDialog();
                    this.Hide();
                    break;
                case "Secretary":
                   SecretaryMain frmSecretary = new SecretaryMain();
                    frmSecretary.ShowDialog();
                    this.Hide();
                    break;
                case "Academic Chair":
                    MessageBox.Show("Academic Chair");
                    break;
                case "Admin":
                   Main frmMain = new Main();
                    frmMain.Show();
                    this.Hide();
                    
                    break;
                default:
                    MessageBox.Show("Unknown role");
                    break;
            }

            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
