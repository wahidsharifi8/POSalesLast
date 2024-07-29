using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace POSales
{
    public partial class CustomerModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        string stitle = "Day to Day Supermarket Stock & Inventory Management System";
        Customer customer;
        public CustomerModule(Customer cd)
        {
            cn = new SqlConnection(dbcon.myConnection());
            customer = cd;
            InitializeComponent();
        }

        private void PicClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string user_id = MainForm.userid;
            if (txtcname.Text == "" || txtcaddress.Text == "" || txtEmail.Text == "" || txtPhoneNumber.Text == "")
            {
                MessageBox.Show("Please fill all textboxes");
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Are you sure want to update this PRODUCT?", "Update PRODUCT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("UPDATE CUSTOMER SET [ADDRESS] = @ADDRESS,PHONE_NUMBER = @PHONE_NUMBER,EMAIL = @EMAIL,userid = @userid WHERE CNAME = @CNAME", cn);
                        cm.Parameters.AddWithValue("@ADDRESS", txtcaddress.Text);
                        cm.Parameters.AddWithValue("@PHONE_NUMBER", txtPhoneNumber.Text);
                        cm.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                        cm.Parameters.AddWithValue("@userid", user_id);
                        cm.Parameters.AddWithValue("@CNAME", txtcname.Text);
                        Regex email_regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        Match match_email = email_regex.Match(txtEmail.Text);
                        Regex phone_regex = new Regex(@"^\(?([0-0]{1})\)?[-. ]?([7-7]{1})[-. ]?([0-9]{8})$");
                        Match match_phone = phone_regex.Match(txtPhoneNumber.Text);

                        if (!match_email.Success)
                        {
                            MessageBox.Show("Please Enter a valid Email Address", "Warning");
                        }
                        if (!match_phone.Success)
                        {
                            MessageBox.Show("Please Enter a valid Phone Number like 07xxxxxxxx", "Warning");
                        }

                        if (cn.State != ConnectionState.Open)
                        {
                            cn.Open();
                        }
                        if (match_email.Success && match_phone.Success)
                        {
                            cm.ExecuteNonQuery();
                            cn.Close();
                            MessageBox.Show("Customer has been successfully updated.", stitle);
                            Clear();
                            this.Dispose();
                        }

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void Clear()
        {
            txtcname.Clear();
            txtcaddress.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string user_id = MainForm.userid;
            if (txtcname.Text == "" || txtcaddress.Text == "" || txtEmail.Text == "" || txtPhoneNumber.Text == "")
            {
                MessageBox.Show("Please fill all textboxes", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Are you sure want to save this Customer?", "Save Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("INSERT INTO CUSTOMER (CNAME,ADDRESS,PHONE_NUMBER,EMAIL,userid) VALUES (@CNAME,@ADDRESS,@PHONE_NUMBER,@EMAIL,@userid)", cn);
                        cm.Parameters.AddWithValue("@CNAME", txtcname.Text);
                        cm.Parameters.AddWithValue("@ADDRESS", txtcaddress.Text);
                        cm.Parameters.AddWithValue("@PHONE_NUMBER", txtPhoneNumber.Text);
                        cm.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                        cm.Parameters.AddWithValue("@userid", user_id);

                        Regex email_regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        Match match_email = email_regex.Match(txtEmail.Text);
                        Regex phone_regex = new Regex(@"^\(?([0-0]{1})\)?[-. ]?([7-7]{1})[-. ]?([0-9]{8})$");
                        Match match_phone = phone_regex.Match(txtPhoneNumber.Text);
                        if (!match_email.Success)
                        {
                            MessageBox.Show("Please Enter a valid Email Address", "Warning");
                        }
                        if (!match_email.Success)
                        {
                            MessageBox.Show("Please Enter a valid Phone Number like 07xxxxxxxx", "Warning");
                        }

                        if (cn.State != ConnectionState.Open)
                        {
                            cn.Open();
                        }

                        if (match_email.Success && match_phone.Success)
                        {
                            cm.ExecuteNonQuery();
                            cn.Close();
                            MessageBox.Show("Customer has been successfully saved.", stitle);
                            Clear();
                            customer.LoadCustomer();
                        }

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TxtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
