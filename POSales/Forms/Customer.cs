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

namespace POSales
{
    public partial class Customer : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        string stitle = "Day to Day Supermarket Stock & Inventory Management System";

        public Customer()
        {
            cn = new SqlConnection(dbcon.myConnection());
            InitializeComponent();
            LoadCustomer();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            CustomerModule customerModule = new CustomerModule(this);
            customerModule.ShowDialog();
        }
        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT cs.CNAME,cs.[ADDRESS],cs.PHONE_NUMBER,cs.EMAIL FROM CUSTOMER AS cs WHERE CONCAT(cs.CNAME, cs.[ADDRESS], cs.PHONE_NUMBER,cs.EMAIL) LIKE '%" + txtSearch.Text + "%'", cn);
            cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                CustomerModule customerModule = new CustomerModule(this);
                customerModule.txtcname.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                customerModule.txtcaddress.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                customerModule.txtPhoneNumber.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                customerModule.txtEmail.Text = dgvCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();

                customerModule.txtcname.Enabled = false;
                customerModule.btnSave.Enabled = false;
                customerModule.btnUpdate.Enabled = true;
                customerModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM Customer WHERE cname LIKE '" + dgvCustomer[1, e.RowIndex].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("customer has been successfully deleted.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LoadCustomer();
        }

        private void TxtSearch_Click(object sender, EventArgs e)
        {

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }
    }
}
