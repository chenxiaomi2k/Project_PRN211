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
using BCrypt.Net;

namespace Password_Management_App
{
    public partial class SignUp : Form
    {
        IUserRepository userRepository = new UserRepository();

        public SignUp()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string repass = txtRepass.Text;
            if (password != repass)
            {
                MessageBox.Show("Re enter password is not match!", "Warning");
            }
            else
            {
                bool checker = userRepository.CheckUser(username);
                if (checker)
                {
                    User user = new User { Username = username, Password = BCrypt.Net.BCrypt.HashPassword(password) };
                    try
                    {
                        userRepository.AddUser(user);
                        MessageBox.Show("Sign up succesfull!", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("User is already exist!", "Warning");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
