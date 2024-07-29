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
    public partial class MainForm : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public string _pass;
        public static string userid = "";
        public MainForm()
        {
            InitializeComponent();
            customizeDesing();
            cn = new SqlConnection(dbcon.myConnection());            
        }

        #region panelSlide
        private void customizeDesing()
        {
            panelSubProduct.Visible = false;
            panelSubRecord.Visible = false;
            panelSubStock.Visible = false;
            panelSubSetting.Visible = false;
        }

        private void hideSubmenu()
        {
            if (panelSubProduct.Visible == true)
                panelSubProduct.Visible = false;
            if (panelSubRecord.Visible == true)
                panelSubRecord.Visible = false;
            if (panelSubSetting.Visible == true)
                panelSubSetting.Visible = false;
            if (panelSubStock.Visible == true)
                panelSubStock.Visible = false;
        }

        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }
        #endregion panelSlide

        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            lblTitle.Text = childForm.Text;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            openChildForm(new Dashboard());
            hideSubmenu();
        }

        private void btnPRODUCT_Click(object sender, EventArgs e)
        {
            userid = lbl_user_id.Text;
            showSubmenu(panelSubProduct);
        }

        private void btnPRODUCTList_Click(object sender, EventArgs e)
        {
            userid = lbl_user_id.Text;
            openChildForm(new PRODUCT());
            hideSubmenu();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            userid = lbl_user_id.Text;
            openChildForm(new Category());
            hideSubmenu();
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            userid = lbl_user_id.Text;
            openChildForm(new Brand());
            hideSubmenu();
        }

        private void btnInStock_Click(object sender, EventArgs e)
        {
            userid = lbl_user_id.Text;
            showSubmenu(panelSubStock);
        }

        private void btnStockEntry_Click(object sender, EventArgs e)
        {
            userid = lbl_user_id.Text;
            openChildForm(new Stock(this));
            hideSubmenu();
        }

        private void btnStockAdjustment_Click(object sender, EventArgs e)
        {
            userid = lbl_user_id.Text;
            openChildForm(new Adjustments(this));
            hideSubmenu();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            userid = lbl_user_id.Text;
            openChildForm(new Supplier());
            hideSubmenu();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            userid = lbl_user_id.Text;
            showSubmenu(panelSubRecord);
        }

        private void btnSaleHist_Click(object sender, EventArgs e)
        {
            userid = lbl_user_id.Text;
            openChildForm(new DailySale(this));            
            hideSubmenu();
        }

        private void btnPosRecord_Click(object sender, EventArgs e)
        {
            userid = lbl_user_id.Text;
            openChildForm(new Record());
            hideSubmenu();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            userid = lbl_user_id.Text;
            showSubmenu(panelSubSetting);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            userid = lbl_user_id.Text;
            openChildForm(new UserAccount(this));
            hideSubmenu();
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            userid = lbl_user_id.Text;
            hideSubmenu();
            Store store = new Store();
            store.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            hideSubmenu();

            if (MessageBox.Show("Logout Application?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login LOGIN = new Login();
                LOGIN.ShowDialog();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnDashboard.PerformClick();
            Noti();
        }

        // Noti Alart for critical items
        public void Noti()
        {
            int i = 0;
            cn.Open();
            cm = new SqlCommand("SELECT * FROM vwCriticalItems", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                Alert alert = new Alert(this);
                alert.lblPcode.Text = dr["pcode"].ToString();
                alert.btnReorder.Enabled = true;
                alert.showAlert(i + ". " + dr["pdesc"].ToString() + " - " + dr["qty"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            userid = lbl_user_id.Text;
            openChildForm(new Customer());
            hideSubmenu();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            userid = lbl_user_id.Text;
            openChildForm(new Order());
            hideSubmenu();
        }
    }
}
