using PasswordLibrary.DataAccess;
using PasswordLibrary.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Management_App
{
    public partial class frmLogin : Form
    {
        IUserRepository userRepository = new UserRepository();
        public frmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPass.Text;
            User user = userRepository.GetUser(username);
            if (user == null)
            {
                MessageBox.Show("Incorrect username or password!", "Login fail");
            }
            else
            {
                bool isMatch = BCrypt.Net.BCrypt.Verify(password, user.Password);
                if (isMatch)
                {
                    frmPassword pass = new frmPassword(user);
                    pass.Show();
                    this.Hide();
                    pass.FormClosed += (s, e) => this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password!", "Login fail");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
        }
    }
}
