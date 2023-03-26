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
    public partial class AddPassword : Form
    {
        public User User { get; set; }
        public Password Password { get; set; }
        public bool isStatus { get; set; }
        IPasswordRepository passwordRepository = new PasswordRepository();

        public AddPassword(User user, Password password, bool isAddOrUpdate)
        {
            InitializeComponent();
            this.User = user;
            this.Password = password;
            txtUserId.Text = User.Username.ToString();
            this.isStatus = isAddOrUpdate;
            cboCategory.SelectedIndex = 0;
            if (!isAddOrUpdate)
            {
                Load();
            }            
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //Load current password data if False
        private new void Load()
        {
            label7.Text = "Update password";
            int userId = User.Id;
            txtWeb.Text = Password.Website;
            txtUsername.Text = Password.Username;
            txtPass.Text = Password.SavedPassword;
            cboCategory.Text = Password.Category;
            txtNote.Text = Password.Note;
        }

        //isStatus is True then add new password
        private void AddNewPass()
        {
            int userId = User.Id;
            string website = txtWeb.Text.ToString();
            string username = txtUsername.Text.ToString();
            string password = txtPass.Text.ToString();
            string category = cboCategory.Text;
            string note = txtNote.Text.ToString();
            Password p = new Password
            {
                UserId = userId,
                Website = website,
                Username = username,
                SavedPassword = password,
                Category = category,
                Note = note
            };
            try
            {
                passwordRepository.AddPassword(p, User.Id);
                MessageBox.Show("Add new password successful!", "Infor");
            }
            catch (Exception)
            {
                MessageBox.Show("Password is already exist!", "Warning");
            }
        }

        //isStatus is False then update current password
        private void UpdateCurrentPassword()
        {
            string webname = txtWeb.Text.ToString();
            if (txtNote.Text.Length == 0)
            {
                txtNote.Text = "";
            }
            if (webname.Equals(Password.Website))
            {
                Password.UserId = User.Id;
                Password.Username = txtUsername.Text;
                Password.SavedPassword = txtPass.Text;
                Password.Category = cboCategory.Text;
                Password.Note = txtNote.Text;
                try
                {
                    passwordRepository.UpdatePassword(Password, User.Id);
                    MessageBox.Show("Update password successful!", "Infor");
                    return;
                }
                catch
                {
                    MessageBox.Show("This password is already exist!", "Warning");
                }
            }
            Password pass = passwordRepository.GetPasswords(User.Id).FirstOrDefault(p => p.Website == webname);
            if (pass == null)
            {
                Password.Website = webname;
                Password.UserId = User.Id;
                Password.Username = txtUsername.Text;
                Password.SavedPassword = txtPass.Text;
                Password.Category = cboCategory.Text;
                Password.Note = txtNote.Text;
                try
                {
                    passwordRepository.UpdatePassword(Password, User.Id);
                    MessageBox.Show("Update password successful!", "Infor");
                }
                catch
                {
                    MessageBox.Show("This password is already exist!", "Warning");
                }
            }
            else
            {
                MessageBox.Show("This password is already exist!", "Warning");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isStatus)
            {
                AddNewPass();
            }
            else
            {
                UpdateCurrentPassword();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
