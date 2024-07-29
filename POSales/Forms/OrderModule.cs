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
    public partial class OrderModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        string stitle = "Day to Day Supermarket Stock & Inventory Management System";
        Order order;
        public OrderModule(Order dr)
        {
            cn = new SqlConnection(dbcon.myConnection());
            order = dr;
            InitializeComponent();
            LoadProduct();
            LoadCustomer();
            show();
        }

        private void PicClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadProduct()
        {
            try
            {
                cn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT pcode,pdesc FROM PRODUCT",cn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cbopcode.DataSource = dt;
                cbopcode.ValueMember = "pcode";
                cbopcode.DisplayMember = "pdesc";
                cn.Close();
                
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void LoadCustomer()
        {
            try
            {
                cn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT C_ID,CNAME FROM CUSTOMER",cn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cbCustomer.DataSource = dt;
                cbCustomer.ValueMember = "C_ID";
                cbCustomer.DisplayMember = "CNAME";
                cn.Close();
                
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string user_id = MainForm.userid;
            if (cbopcode.Text == "" || cbCustomer.Text == "" || orderdate.Text == "" || txttotalamount.Text == "")
            {
                MessageBox.Show("Please fill all textboxes");
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Are you sure want to update this PRODUCT?", "Update Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("UPDATE MYORDER SET pcode = @pcode,CID = @CID,[DATE] = @Date,AMOUNT = @amount  WHERE ORD_ID = @ORD_ID", cn);
                        cm.Parameters.AddWithValue("@pcode", cbopcode.SelectedValue);
                        cm.Parameters.AddWithValue("@CID", cbCustomer.SelectedValue);
                        cm.Parameters.AddWithValue("@Date", orderdate.Text);
                        cm.Parameters.AddWithValue("@AMOUNT", txtperUnitAmount.Text);
                        cm.Parameters.AddWithValue("@ORD_ID", lblord_id.Text);

                        if (cn.State != ConnectionState.Open)
                        {
                            cn.Open();
                        }
                            cm.ExecuteNonQuery();
                        cm = new SqlCommand("select max(ORD_ID) from MYORDER", cn);
                        int ord_id = int.Parse(cm.ExecuteScalar().ToString());

                        cm = new SqlCommand("delete from ORDER_DETAILS where ORD_ID=@ORD_ID and PID=@PID", cn);
                        cm.Parameters.AddWithValue("@ORD_ID", ord_id);
                        cm.Parameters.AddWithValue("@PID", cbopcode.SelectedValue.ToString());
                        cm.ExecuteNonQuery();

                        cm = new SqlCommand("INSERT INTO ORDER_DETAILS (ORD_ID,PID,QUANTITY) VALUES (@ORD_ID,@PID,@QUANTITY)", cn);
                        cm.Parameters.AddWithValue("@ORD_ID", ord_id);
                        cm.Parameters.AddWithValue("@PID", cbopcode.SelectedValue.ToString());
                        cm.Parameters.AddWithValue("@QUANTITY", txtoderquantity.Text);
                        cm.ExecuteNonQuery();

                        cn.Close();
                        MessageBox.Show("Order has been successfully updated.", stitle);
                        Clear();
                        this.Dispose();
                        order.LoadOrder();

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
            cbopcode.SelectedIndex = -1;
            cbCustomer.SelectedIndex = -1;
            txtperUnitAmount.Clear();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string user_id = MainForm.userid;
            if (cbopcode.Text == "" || cbCustomer.Text == "" || orderdate.Text == "" || txtperUnitAmount.Text == "" || txtoderquantity.Text == "")
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
                        cm = new SqlCommand("INSERT INTO MYORDER (pcode,CID,[DATE],AMOUNT) VALUES (@pcode,@CID,@DATE,@AMOUNT)", cn);
                        cm.Parameters.AddWithValue("@pcode", cbopcode.SelectedValue);
                        cm.Parameters.AddWithValue("@CID", cbCustomer.SelectedValue);
                        cm.Parameters.AddWithValue("@DATE", orderdate.Text);
                        cm.Parameters.AddWithValue("@AMOUNT", txttotalamount.Text);

                        if (cn.State != ConnectionState.Open)
                        {
                            cn.Open();
                        }
                        cm.ExecuteNonQuery();
                        cm = new SqlCommand("select max(ORD_ID) from MYORDER",cn);
                        int ord_id = int.Parse(cm.ExecuteScalar().ToString());

                        cm = new SqlCommand("INSERT INTO ORDER_DETAILS (ORD_ID,PID,QUANTITY) VALUES (@ORD_ID,@PID,@QUANTITY)", cn);
                        cm.Parameters.AddWithValue("@ORD_ID", ord_id);
                        cm.Parameters.AddWithValue("@PID", cbopcode.SelectedValue.ToString());
                        cm.Parameters.AddWithValue("@QUANTITY", txtoderquantity.Text);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Order has been successfully saved.", stitle);
                        Clear();
                        order.LoadOrder();
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

        private void Cbopcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            show();
        }

        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void Txtoderquantity_TextChanged(object sender, EventArgs e)
        {
            if(txtoderquantity.Text != "")
            {
                double stock_quantity = double.Parse(txtstockquantity.Text);
                double oder_quantity = double.Parse(txtoderquantity.Text);
                double per_unit_price = double.Parse(txtperUnitAmount.Text);
                if (oder_quantity > stock_quantity)
                {
                    MessageBox.Show("Order quantity should be equal or than stock quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txttotalamount.Text = (per_unit_price * oder_quantity).ToString();
                }
            }
            else
            {
                txttotalamount.Text = "";
            }

        }

        private void Txttotalamount_TextChanged(object sender, EventArgs e)
        {

        }

        public void show()
        {
            double unitPrice;
            double quantity;

            if (cbopcode.SelectedIndex > 0)
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                SqlDataAdapter sda = new SqlDataAdapter("select * from product where pcode = '" + cbopcode.SelectedValue + "'", cn);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                foreach (DataRow myRow in ds.Tables[0].Rows)
                {
                    string data = myRow["price"].ToString();
                    unitPrice = double.Parse(myRow["price"].ToString());
                    quantity = double.Parse(myRow["qty"].ToString());

                    txtstockquantity.Text = quantity.ToString();
                    txtperUnitAmount.Text = unitPrice.ToString();
                }

                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }
    }
}
