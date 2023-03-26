using Azure;
using Microsoft.IdentityModel.Tokens;
using PasswordLibrary.DataAccess;
using PasswordLibrary.Repository;
using System.Windows.Forms;

namespace Password_Management_App
{
    public partial class frmPassword : Form
    {
        public User User { get; set; }
        private Thread dateTime;
        private bool isRunning;
        IPasswordRepository passwordRepository = new PasswordRepository();


        public frmPassword(User user)
        {
            InitializeComponent();
            this.User = user;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void LoadData()
        {
            cboCategory.SelectedIndex = 0;

            gridViewPassword.AutoGenerateColumns = false;

            //Column ID
            gridViewPassword.Columns.Add("id", "ID");
            gridViewPassword.Columns["id"].DataPropertyName = "Id";
            gridViewPassword.Columns["id"].Visible = false;
            gridViewPassword.Columns["id"].ReadOnly = true;

            //Column website
            gridViewPassword.Columns.Add("website", "Website");
            gridViewPassword.Columns["website"].DataPropertyName = "Website";
            gridViewPassword.Columns["website"].ReadOnly = true;

            //Column Username
            gridViewPassword.Columns.Add("Username", "User Name");
            gridViewPassword.Columns["Username"].DataPropertyName = "Username";
            gridViewPassword.Columns["Username"].ReadOnly = true;

            //Column password
            gridViewPassword.Columns.Add("pass", "Saved Password");
            gridViewPassword.Columns["pass"].DataPropertyName = "SavedPassword";
            gridViewPassword.Columns["pass"].ReadOnly = true;

            //Column category
            gridViewPassword.Columns.Add("cate", "Category");
            gridViewPassword.Columns["cate"].DataPropertyName = "Category";
            gridViewPassword.Columns["cate"].ReadOnly = true;

            //Column Note
            gridViewPassword.Columns.Add("note", "Notes");
            gridViewPassword.Columns["note"].DataPropertyName = "Note";
            gridViewPassword.Columns["note"].ReadOnly = true;

            //Bind data
            gridViewPassword.DataSource = passwordRepository.GetPasswords(User.Id);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string website = txtSearch.Text.ToString();
            if (website.Length == 0)
            {
                gridViewPassword.DataSource = passwordRepository.GetPasswords(User.Id);
            }
            else
            {
                gridViewPassword.DataSource = passwordRepository.GetPasswordByWebsite(website, User.Id);
            }
        }

        private void cboCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string category = cboCategory.Text;
            if (category.Equals("All Passwords"))
            {
                gridViewPassword.DataSource = passwordRepository.GetPasswords(User.Id);
            }
            else
            {
                gridViewPassword.DataSource = passwordRepository.Filter(category, User.Id);
            }
        }

        private void btnAddPass_Click(object sender, EventArgs e)
        {
            AddPassword addPassword = new AddPassword(User, null, true);
            if (addPassword.ShowDialog() == DialogResult.OK)
            {
                gridViewPassword.DataSource = passwordRepository.GetPasswords(User.Id);
            }
        }

        private void UpdateTime()
        {
            while (isRunning)
            {
                Invoke(new Action(() =>
                {
                    lbTime.Text = DateTime.Now.ToString("dddd dd/MMMM/yyyy HH:mm:ss");
                }));

                Thread.Sleep(1000);
            }
        }

        private void frmPassword_Load(object sender, EventArgs e)
        {
            dateTime = new Thread(new ThreadStart(UpdateTime));
            isRunning = true;
            dateTime.Start();
            lbHello.Text = "Hello " + User.Username;

            //Create a column to select passwords
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Select";
            checkBoxColumn.ValueType = typeof(bool);
            checkBoxColumn.Name = "select";
            checkBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            gridViewPassword.Columns.Add(checkBoxColumn);
            LoadData();
            //Column update
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Action";
            buttonColumn.Text = "Update";
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridViewPassword.Columns.Add(buttonColumn);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int checker = 0;
            foreach (DataGridViewRow row in gridViewPassword.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    checker++;
                }
            }
            if (checker == 0)
            {
                MessageBox.Show("Select atleast 1 record to delete!", "Infor");
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Deleting " + checker + " password(s)! Are you sure?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in gridViewPassword.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            passwordRepository.DeletePassword(Convert.ToInt32(row.Cells["id"].Value));
                        }
                    }
                }
            }
            gridViewPassword.DataSource = passwordRepository.GetPasswords(User.Id);
        }

        private void frmPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRunning = false;
        }

        private void gridViewPassword_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (gridViewPassword.CurrentCell is DataGridViewButtonCell)
            {
                int pid = Convert.ToInt32(gridViewPassword.Rows[e.RowIndex].Cells["id"].Value);
                Password password = passwordRepository.GetPasswordById(pid);
                AddPassword addPassword = new AddPassword(User, password, false);
                if (addPassword.ShowDialog() == DialogResult.OK)
                {
                    gridViewPassword.DataSource = passwordRepository.GetPasswords(User.Id);
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
            login.FormClosed += (s, e) => this.Close();
        }
    }
}