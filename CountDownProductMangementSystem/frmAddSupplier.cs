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
    public partial class frmAddSupplier : Form
    {
        public int postalCode;
        public string searchBy;
       
        public static  DateTime Now { get; } 
        public frmAddSupplier()
        {
            InitializeComponent();
            this.Text = "Add or Search supplier using Table Adapter";
            cmbSearchBy.Items.Add("Supplier ID");
            cmbSearchBy.Items.Add("City");
        }

        private void CheckDataValidation()
        {
            //int dates = Convert.ToInt32(JoinDate.Text);
            // int currentDate = Convert.ToInt32(Now);
        } 
          

     

        private void frmAddSupplier_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbMidTermDataSet.Suppliers' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.dbMidTermDataSet.Suppliers);

        }

        private void suppliersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.suppliersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dbMidTermDataSet);

        }
      

        private void btnAddTitle_Click(object sender, EventArgs e)
        {
       
            // int currentId = Convert.ToInt32(suppliersTableAdapter.GetSupplierId());
            if (txtCompanyName.Text == " ")
                MessageBox.Show("Please enter Company Name");
           else if (txtContactName.Text == " ")
                MessageBox.Show("Please enter Contact Name");
            else if (txtAddress.Text == " ")
                MessageBox.Show("Please enter Address");
            else if (txtRegion.Text == " ")
                MessageBox.Show("Please enter Region");
            else if (txtCountry.Text == " ")
                MessageBox.Show("Please enter Country");
            else if (txtPhone.Text == " ")
                MessageBox.Show("Please enter Phone Number");
            else if (txtTitle.Text == " ")
                MessageBox.Show("Please enter Contact Title");
            else if (txtPostalCode.Text == " ")
                MessageBox.Show("Please enter Postal Code");
            else if (JoinDate.Text == " ")
                MessageBox.Show("Please enter Join date");
            else
            {
                suppliersTableAdapter.InsertSupplier(txtCompanyName.Text, txtContactName.Text, txtTitle.Text, txtAddress.Text, txtCity.Text, txtRegion.Text, postalCode, txtCountry.Text, txtPhone.Text, JoinDate.Text);
                MessageBox.Show("Supplier Data has been successfully added");


            }



        }

        private void txtPostalCode_TextChanged(object sender, EventArgs e)
        {
            postalCode = Convert.ToInt32(txtPostalCode.Text);
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchBy.Text == "Supplier ID")
                searchBy = "SupplierId";
            else if (cmbSearchBy.Text == "City")
                searchBy = "City";
        }

        private void btmSearchSupplier_Click(object sender, EventArgs e)
        {
            int supplierId = 3;
            string cityName = "";
            if (searchBy == "SupplierId")
            {
                try
                {
                    supplierId = Convert.ToInt32(txtSearchInput.Text);
                }
                catch(Exception ex)
                { 
                  MessageBox.Show("Supplier ID should be an integer" + ex.Message);
                }
              
                suppliersTableAdapter.SearchSupplierBySupplierId(this.dbMidTermDataSet.Suppliers, supplierId);
            }
            else if (searchBy == "City")
            {
                try
                {
                    cityName = txtSearchInput.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("City Name should be a string" + ex.Message);
                }
                suppliersTableAdapter.SearchSupplierByCity(this.dbMidTermDataSet.Suppliers, cityName);
            }

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            suppliersTableAdapter.GetAllData(this.dbMidTermDataSet.Suppliers);
        }
    }
}
