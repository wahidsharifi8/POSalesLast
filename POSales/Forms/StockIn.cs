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
    public partial class Stock : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        string stitle = "Day to Day Supermarket Stock & Inventory Management System";
        MainForm main;
        public Stock(MainForm mn)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            main = mn;
            LoadSupplier();
            GetRefeNo();
            txtStockBy.Text = main.lblUsername.Text;
        }

        public void GetRefeNo()
        {
            Random rnd = new Random();
            txtRefNo.Clear();
            txtRefNo.Text += rnd.Next();
        }

        public void LoadSupplier()
        {
            cbSupplier.Items.Clear();
            cbSupplier.DataSource =dbcon.getTable("SELECT * FROM VENDOR");
            cbSupplier.DisplayMember = "supplier";
        }

        public void PRODUCTForSupplier(string pcode)
        {
            string supplier = "";
            cn.Open();
            cm = new SqlCommand("SELECT * FROM vwStock WHERE pcode LIKE '" + pcode + "'", cn);
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                supplier = dr["supplier"].ToString();
            }
            dr.Close();
            cn.Close();
            cbSupplier.Text = supplier;
        }

        public void LoadStock()
        {
            int i = 0;
            dgvStock.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * FROM vwStock WHERE refno LIKE '" + txtRefNo.Text + "' AND status LIKE 'Pending'", cn);
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                i++;
                dgvStock.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr["supplier"].ToString());

            }
            dr.Close();
            cn.Close();
        }

        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void LinGenerate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetRefeNo();
        }

        private void LinPRODUCT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PRODUCTStock PRODUCTStock = new PRODUCTStock(this);
            PRODUCTStock.ShowDialog();
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            if(txtAddress.Text == "" || txtConPerson.Text == "" || txtRefNo.Text == "" || txtStockBy.Text == "")
            {
                MessageBox.Show("Please fill textboxes!!!");
            }
            else
            {
                try
                {
                    if (dgvStock.Rows.Count > 0)
                    {
                        if (MessageBox.Show("Are you sure you want to save this records?", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            for (int i = 0; i < dgvStock.Rows.Count; i++)
                            {
                                //update PRODUCT quantity
                                cn.Open();
                                cm = new SqlCommand("UPDATE PRODUCT SET qty = qty + " + int.Parse(dgvStock.Rows[i].Cells[5].Value.ToString()) + " WHERE pcode LIKE '" + dgvStock.Rows[i].Cells[3].Value.ToString() + "'", cn);
                                cm.ExecuteNonQuery();
                                cn.Close();

                                //update Stock quantity
                                cn.Open();
                                cm = new SqlCommand("UPDATE Stock SET qty = qty + " + int.Parse(dgvStock.Rows[i].Cells[5].Value.ToString()) + ", status='Done' WHERE id LIKE '" + dgvStock.Rows[i].Cells[1].Value.ToString() + "'", cn);
                                cm.ExecuteNonQuery();
                                cn.Close();
                            }
                            Clear();
                            LoadStock();

                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        public void Clear()
        {
            txtRefNo.Clear();
            txtStockBy.Clear();
            dtStock.Value = DateTime.Now;
        }

        private void dgvStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvStock.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Remove this item?", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM Stock WHERE id='" + dgvStock.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Item has been successfully removed", stitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStock();
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                dgvInStockHistory.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("SELECT * FROM vwStock WHERE CAST(sdate as date) BETWEEN '"+dtFrom.Value.ToShortDateString()+ "' AND '" + dtTo.Value.ToShortDateString() + "' AND status LIKE 'Done'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvInStockHistory.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), DateTime.Parse(dr[5].ToString()).ToShortDateString(), dr[6].ToString(), dr["supplier"].ToString());

                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void cbSupplier_TextChanged(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("SELECT * FROM VENDOR WHERE supplier LIKE '" + cbSupplier.Text + "'", cn);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                lblId.Text = dr["id"].ToString();
                txtConPerson.Text = dr["contactperson"].ToString();
                txtAddress.Text = dr["address"].ToString();

            }
            dr.Close();
            cn.Close();
        }

        private void TxtRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
