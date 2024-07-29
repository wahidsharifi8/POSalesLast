namespace POSales
{
    partial class OrderModule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderModule));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtperUnitAmount = new System.Windows.Forms.TextBox();
            this.cbopcode = new System.Windows.Forms.ComboBox();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.orderdate = new MetroFramework.Controls.MetroDateTime();
            this.lblord_id = new System.Windows.Forms.Label();
            this.txtoderquantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtstockquantity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txttotalamount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(732, 523);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 47);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(576, 523);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(146, 47);
            this.btnUpdate.TabIndex = 29;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 27);
            this.label2.TabIndex = 28;
            this.label2.Text = "Product Name :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.picClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(927, 68);
            this.panel1.TabIndex = 17;
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
            this.picClose.Location = new System.Drawing.Point(871, 16);
            this.picClose.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(31, 35);
            this.picClose.TabIndex = 1;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.PicClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order Module";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(408, 523);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(146, 47);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 380);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 27);
            this.label6.TabIndex = 24;
            this.label6.Text = "Per unit amount :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 218);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 27);
            this.label5.TabIndex = 23;
            this.label5.Text = "Order Date :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 161);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 27);
            this.label4.TabIndex = 22;
            this.label4.Text = "Customer Name :";
            // 
            // txtperUnitAmount
            // 
            this.txtperUnitAmount.Enabled = false;
            this.txtperUnitAmount.Location = new System.Drawing.Point(281, 375);
            this.txtperUnitAmount.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtperUnitAmount.Name = "txtperUnitAmount";
            this.txtperUnitAmount.Size = new System.Drawing.Size(621, 35);
            this.txtperUnitAmount.TabIndex = 36;
            this.txtperUnitAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAmount_KeyPress);
            // 
            // cbopcode
            // 
            this.cbopcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbopcode.FormattingEnabled = true;
            this.cbopcode.Location = new System.Drawing.Point(281, 103);
            this.cbopcode.Name = "cbopcode";
            this.cbopcode.Size = new System.Drawing.Size(621, 35);
            this.cbopcode.TabIndex = 38;
            this.cbopcode.SelectedIndexChanged += new System.EventHandler(this.Cbopcode_SelectedIndexChanged);
            // 
            // cbCustomer
            // 
            this.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(281, 161);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(621, 35);
            this.cbCustomer.TabIndex = 39;
            // 
            // orderdate
            // 
            this.orderdate.Location = new System.Drawing.Point(281, 221);
            this.orderdate.MinimumSize = new System.Drawing.Size(0, 29);
            this.orderdate.Name = "orderdate";
            this.orderdate.Size = new System.Drawing.Size(621, 35);
            this.orderdate.TabIndex = 40;
            // 
            // lblord_id
            // 
            this.lblord_id.AutoSize = true;
            this.lblord_id.ForeColor = System.Drawing.SystemColors.Control;
            this.lblord_id.Location = new System.Drawing.Point(13, 76);
            this.lblord_id.Name = "lblord_id";
            this.lblord_id.Size = new System.Drawing.Size(84, 27);
            this.lblord_id.TabIndex = 41;
            this.lblord_id.Text = "label3";
            // 
            // txtoderquantity
            // 
            this.txtoderquantity.Location = new System.Drawing.Point(281, 320);
            this.txtoderquantity.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtoderquantity.Name = "txtoderquantity";
            this.txtoderquantity.Size = new System.Drawing.Size(621, 35);
            this.txtoderquantity.TabIndex = 43;
            this.txtoderquantity.TextChanged += new System.EventHandler(this.Txtoderquantity_TextChanged);
            this.txtoderquantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 320);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 27);
            this.label3.TabIndex = 42;
            this.label3.Text = "Order Quantity";
            // 
            // txtstockquantity
            // 
            this.txtstockquantity.Enabled = false;
            this.txtstockquantity.Location = new System.Drawing.Point(281, 272);
            this.txtstockquantity.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtstockquantity.Name = "txtstockquantity";
            this.txtstockquantity.Size = new System.Drawing.Size(621, 35);
            this.txtstockquantity.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 272);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 27);
            this.label7.TabIndex = 44;
            this.label7.Text = "Quantity in stock";
            // 
            // txttotalamount
            // 
            this.txttotalamount.Enabled = false;
            this.txttotalamount.Location = new System.Drawing.Point(281, 431);
            this.txttotalamount.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txttotalamount.Name = "txttotalamount";
            this.txttotalamount.Size = new System.Drawing.Size(621, 35);
            this.txttotalamount.TabIndex = 47;
            this.txttotalamount.TextChanged += new System.EventHandler(this.Txttotalamount_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 436);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 27);
            this.label8.TabIndex = 46;
            this.label8.Text = "Total amount :";
            // 
            // OrderModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 610);
            this.ControlBox = false;
            this.Controls.Add(this.txttotalamount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtstockquantity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtoderquantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblord_id);
            this.Controls.Add(this.orderdate);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.cbopcode);
            this.Controls.Add(this.txtperUnitAmount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderModule";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerModule";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtperUnitAmount;
        public System.Windows.Forms.ComboBox cbopcode;
        public System.Windows.Forms.ComboBox cbCustomer;
        public System.Windows.Forms.Label lblord_id;
        public MetroFramework.Controls.MetroDateTime orderdate;
        public System.Windows.Forms.TextBox txtoderquantity;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtstockquantity;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txttotalamount;
        private System.Windows.Forms.Label label8;
    }
}