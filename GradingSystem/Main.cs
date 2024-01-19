using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradingSystem
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student frmStudent = new Student();

            frmStudent.TopLevel = false;
            pData.Controls.Add(frmStudent);
            frmStudent.BringToFront();
            frmStudent.Show();
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to logout?");

            if (result == DialogResult.OK) 
            {
                Login frmLogin = new Login();
                this.Close();
              
                frmLogin.ShowDialog();
            }

        }
    }
}
