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

namespace POSales
{
    public partial class PRODUCTStock : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        string stitle = "Day to Day Supermarket Stock & Inventory Management System";
        Stock Stock;
        public PRODUCTStock(Stock stk)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            Stock = stk;
            LoadPRODUCT();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadPRODUCT()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT pcode, pdesc, qty FROM PRODUCT WHERE pdesc LIKE '%" + txtSearch.Text + "%'", cn);
            cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void dgvPRODUCT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Select")
            {
                if(Stock.txtStockBy.Text == string.Empty)
                {
                    MessageBox.Show("Please enter stock in by name", stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Stock.txtStockBy.Focus();
                    this.Dispose();                                        
                }

                if (MessageBox.Show("Add this item?", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    addStock(dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString());
                    MessageBox.Show("Successfully added", stitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        public void addStock(string pcode)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("INSERT INTO Stock (refno, pcode, sdate, Stockinby, supplierid)VALUES (@refno, @pcode, @sdate, @Stockinby, @supplierid)", cn);
                cm.Parameters.AddWithValue("@refno", Stock.txtRefNo.Text);
                cm.Parameters.AddWithValue("@pcode", pcode);
                cm.Parameters.AddWithValue("@sdate", Stock.dtStock.Value);
                cm.Parameters.AddWithValue("@Stockinby", Stock.txtStockBy.Text);
                cm.Parameters.AddWithValue("@supplierid", Stock.lblId.Text);
                cm.ExecuteNonQuery();
                cn.Close();
                Stock.LoadStock();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, stitle);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadPRODUCT();
        }

        private void PRODUCTStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
