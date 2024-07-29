using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSales
{
    public partial class PRODUCTModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        string stitle = "Day to Day Supermarket Stock & Inventory Management System";
        PRODUCT PRODUCT;
        public PRODUCTModule(PRODUCT pd)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            PRODUCT = pd;
            LoadBrand();
            LoadCategory();
            generatePCode();
        }

        public void generatePCode()
        {
            cn.Open();
            cm = new SqlCommand("SELECT MAX(pcode) FROM PRODUCT", cn);
            string pcode = cm.ExecuteScalar().ToString();
            string pcode_digit = Regex.Match(pcode, @"\d+").Value;
            int new_pcode = int.Parse(pcode_digit);
            new_pcode += 1;
            txtPcode.Text = "P" + String.Format("{0:000}", new_pcode);
            cn.Close();
        }

        public void LoadCategory()
        {
            cboCategory.Items.Clear();
            cboCategory.DataSource = dbcon.getTable("SELECT * FROM tbCategory");
            cboCategory.DisplayMember = "category";
            cboCategory.ValueMember = "id";
        }

        public void LoadBrand()
        {
            cboBrand.Items.Clear();
            cboBrand.DataSource = dbcon.getTable("SELECT * FROM tbBrand");
            cboBrand.DisplayMember = "brand";
            cboBrand.ValueMember = "id";
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Clear()
        {
            txtPcode.Clear();
            txtBarcode.Clear();
            txtPdesc.Clear();
            txtPrice.Clear();
            cboBrand.SelectedIndex = 0;
            cboCategory.SelectedIndex = 0;
            UDReOrder.Value = 1;

            txtPcode.Enabled = true;
            txtPcode.Focus();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string user_id = MainForm.userid;
            if(txtBarcode.Text == "" || txtPcode.Text == "" || txtPdesc.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Please fill all textboxes","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Are you sure want to save this PRODUCT?", "Save PRODUCT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("INSERT INTO PRODUCT(pcode, barcode, pdesc, bid, cid, price, reorder,registeredBy)VALUES (@pcode,@barcode,@pdesc,@bid,@cid,@price, @reorder,@registeredBy)", cn);
                        cm.Parameters.AddWithValue("@pcode", txtPcode.Text);
                        cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                        cm.Parameters.AddWithValue("@pdesc", txtPdesc.Text);
                        cm.Parameters.AddWithValue("@bid", cboBrand.SelectedValue);
                        cm.Parameters.AddWithValue("@cid", cboCategory.SelectedValue);
                        cm.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text));
                        cm.Parameters.AddWithValue("@reorder", UDReOrder.Value);
                        cm.Parameters.AddWithValue("@registeredBy", int.Parse(user_id));
                        if(cn.State != ConnectionState.Open)
                        {
                            cn.Open();
                        }
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("PRODUCT has been successfully saved.", stitle);
                        Clear();
                        generatePCode();
                        PRODUCT.LoadPRODUCT();

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string user_id = MainForm.userid;
            if (txtBarcode.Text == "" || txtPcode.Text == "" || txtPdesc.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Please fill all textboxes");
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Are you sure want to update this PRODUCT?", "Update PRODUCT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("UPDATE PRODUCT SET barcode=@barcode,pdesc=@pdesc,bid=@bid,cid=@cid,price=@price, reorder=@reorder,registeredBy=@registeredBy WHERE pcode LIKE @pcode", cn);
                        cm.Parameters.AddWithValue("@pcode", txtPcode.Text);
                        cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                        cm.Parameters.AddWithValue("@pdesc", txtPdesc.Text);
                        cm.Parameters.AddWithValue("@bid", cboBrand.SelectedValue);
                        cm.Parameters.AddWithValue("@cid", cboCategory.SelectedValue);
                        cm.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text));
                        cm.Parameters.AddWithValue("@reorder", UDReOrder.Value);
                        cm.Parameters.AddWithValue("@registeredBy", int.Parse(user_id));
                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("PRODUCT has been successfully updated.", stitle);
                        Clear();
                        this.Dispose();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void PRODUCTModule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void TxtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtBarcode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
