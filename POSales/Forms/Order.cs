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
    public partial class Order : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        string stitle = "Day to Day Supermarket Stock & Inventory Management System";

        public Order()
        {
            cn = new SqlConnection(dbcon.myConnection());
            InitializeComponent();
            LoadOrder();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            OrderModule orderModule = new OrderModule(this);
            orderModule.ShowDialog();
        }
        public void LoadOrder()
        {
            int i = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT MYORDER.ORD_ID,PRODUCT.pdesc,CUSTOMER.CNAME,MYORDER.[DATE],ORDER_DETAILS.QUANTITY,MYORDER.AMOUNT FROM MYORDER INNER JOIN PRODUCT ON PRODUCT.pcode = MYORDER.pcode INNER JOIN CUSTOMER ON MYORDER.CID = CUSTOMER.C_ID INNER JOIN ORDER_DETAILS ON ORDER_DETAILS.ORD_ID = MYORDER.ORD_ID WHERE CONCAT(PRODUCT.pdesc, CUSTOMER.CNAME, MYORDER.[DATE], MYORDER.AMOUNT) LIKE '%" + txtSearch.Text + "%'", cn);
            cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvOrder.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),dr[5].ToString(), dr[4].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void DgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOrder.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                OrderModule orderModule = new OrderModule(this);
                orderModule.lblord_id.Text = dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString();
                orderModule.cbopcode.Text = dgvOrder.Rows[e.RowIndex].Cells[2].Value.ToString();
                orderModule.cbCustomer.Text = dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString();
                orderModule.orderdate.Text = dgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString();
                orderModule.txtoderquantity.Text = dgvOrder.Rows[e.RowIndex].Cells[6].Value.ToString();
                orderModule.txttotalamount.Text = dgvOrder.Rows[e.RowIndex].Cells[5].Value.ToString();

                orderModule.btnSave.Enabled = false;
                orderModule.btnUpdate.Enabled = true;
                orderModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM MYORDER WHERE ORD_ID = @ORD_ID", cn);
                    cm.Parameters.AddWithValue("ORD_ID", dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString());
                    cm.ExecuteNonQuery();

                    cm = new SqlCommand("DELETE FROM ORDER_DETAILS WHERE ORD_ID = @ORD_ID", cn);
                    cm.Parameters.AddWithValue("ORD_ID", dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString());
                    cm.ExecuteNonQuery();

                    cn.Close();
                    MessageBox.Show("Order has been successfully deleted.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrder();
                }
            }
        }

        private void TxtSearch_Click(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }
    }
}
