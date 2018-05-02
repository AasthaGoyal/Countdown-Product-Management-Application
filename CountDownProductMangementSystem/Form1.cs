using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountDownProductMangementSystem
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbMidTermDataSet.tblUsers' table. You can move, or remove it, as needed.
            this.tblUsersTableAdapter.Fill(this.dbMidTermDataSet.tblUsers);
            this.Text = ApplicationSettings.companyName;
            lblTitle.Text = ApplicationSettings.Title;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            string name = tblUsersTableAdapter.CheckUser(txtUserId.Text, txtPassword.Text);

            if (txtUserId.Text == "")
                MessageBox.Show("Please enter the User ID");
            else if (txtPassword.Text == "")
                MessageBox.Show("Please enter the Password");
            else if (name == null)
                MessageBox.Show("Invalid combination of UserId and Password");
            else
            {
                MessageBox.Show("Welcome '" + name + "'");
                new frmAddSupplier().Show();
            }

        }

        private void tblUsersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tblUsersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dbMidTermDataSet);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
