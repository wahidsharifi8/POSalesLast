using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace POSales
{
    public partial class SupplierModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        string stitle = "Day to Day Supermarket Stock & Inventory Management System";
        Supplier supplier;
        public SupplierModule(Supplier sp)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            supplier = sp;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Clear()
        {
            txtAddress.Clear();
            txtConPerson.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtSupplier.Clear();

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txtSupplier.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string user_id = MainForm.userid;
            if(txtAddress.Text == "" || txtConPerson.Text == "" || txtEmail.Text == "" || txtPhone.Text == "" || txtSupplier.Text == "")
            {
                MessageBox.Show("Please fill all textboxes");
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Save this record? click yes to confirm.", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("Insert into VENDOR (supplier, address, contactperson, phone, email,registerdBy) values (@supplier, @address, @contactperson, @phone, @email,@registerdBy) ", cn);
                        cm.Parameters.AddWithValue("@supplier", txtSupplier.Text);
                        cm.Parameters.AddWithValue("@address", txtAddress.Text);
                        cm.Parameters.AddWithValue("@contactperson", txtConPerson.Text);
                        cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cm.Parameters.AddWithValue("@email", txtEmail.Text);
                        cm.Parameters.AddWithValue("@registerdBy", int.Parse(user_id));
                        Regex email_regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        Match match_email = email_regex.Match(txtEmail.Text);
                        Regex phone_regex = new Regex(@"^\(?([0-0]{1})\)?[-. ]?([7-7]{1})[-. ]?([0-9]{8})$");
                        Match match_phone = phone_regex.Match(txtPhone.Text);
                        if (!match_email.Success)
                        {
                            MessageBox.Show("Please Enter a valid Email Address", "Warning");
                        }
                        if (!match_email.Success)
                        {
                            MessageBox.Show("Please Enter a valid Phone Number like 07xxxxxxxx", "Warning");
                        }
                        if (match_email.Success && match_phone.Success)
                        {
                                cn.Open();
                                cm.ExecuteNonQuery();
                                cn.Close();
                                MessageBox.Show("Record has been successfully saved!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                                supplier.LoadSupplier();
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, stitle);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text == "" || txtConPerson.Text == "" || txtEmail.Text == "" || txtPhone.Text == "" || txtSupplier.Text == "")
            {
                MessageBox.Show("Please fill all textboxes");
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Update this record? click yes to confirm.", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("Update VENDOR set supplier=@supplier, address=@address, contactperson=@contactperson, phone=@phone, email=@email where id=@id ", cn);
                        cm.Parameters.AddWithValue("@id", lblId.Text);
                        cm.Parameters.AddWithValue("@supplier", txtSupplier.Text);
                        cm.Parameters.AddWithValue("@address", txtAddress.Text);
                        cm.Parameters.AddWithValue("@contactperson", txtConPerson.Text);
                        cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cm.Parameters.AddWithValue("@email", txtEmail.Text);

                        Regex email_regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        Match match_email = email_regex.Match(txtEmail.Text);
                        Regex phone_regex = new Regex(@"^\(?([0-0]{1})\)?[-. ]?([7-7]{1})[-. ]?([0-9]{8})$");
                        Match match_phone = phone_regex.Match(txtPhone.Text);
                        if (!match_email.Success)
                        {
                            MessageBox.Show("Please Enter a valid Email Address", "Warning");
                        }
                        if (!match_email.Success)
                        {
                            MessageBox.Show("Please Enter a valid Phone Number like 07xxxxxxxx", "Warning");
                        }
                        if (match_email.Success && match_phone.Success)
                        {
                            cm.ExecuteNonQuery();
                            cn.Close();
                            MessageBox.Show("Record has been successfully updated!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();
                        }

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Warning");
                }
            }
        }

        private void SupplierModule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void TxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
