namespace Klinik_Gigi_Ana_Medika
{
    partial class frmRefund
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtTrxId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgHdrTrx = new System.Windows.Forms.DataGridView();
            this.dgDetTrx = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgDetPayment = new System.Windows.Forms.DataGridView();
            this.grInput = new System.Windows.Forms.GroupBox();
            this.nmAdmCount = new System.Windows.Forms.NumericUpDown();
            this.txtLabPrice = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDiag = new System.Windows.Forms.TextBox();
            this.txtSubPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnScrTreatments = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTreatmentID = new System.Windows.Forms.TextBox();
            this.btnAddTrx = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDelTrx = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHdrTrx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetTrx)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetPayment)).BeginInit();
            this.grInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmAdmCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReload);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.txtTrxId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 391);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Transaction";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(282, 43);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 7;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Doctor Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Patient Name";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(82, 71);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(193, 20);
            this.textBox3.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(83, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(193, 20);
            this.textBox2.TabIndex = 3;
            // 
            // txtTrxId
            // 
            this.txtTrxId.Location = new System.Drawing.Point(83, 19);
            this.txtTrxId.Name = "txtTrxId";
            this.txtTrxId.Size = new System.Drawing.Size(193, 20);
            this.txtTrxId.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TransactionId";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(282, 69);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgHdrTrx
            // 
            this.dgHdrTrx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHdrTrx.Location = new System.Drawing.Point(6, 19);
            this.dgHdrTrx.Name = "dgHdrTrx";
            this.dgHdrTrx.Size = new System.Drawing.Size(351, 348);
            this.dgHdrTrx.TabIndex = 2;
            // 
            // dgDetTrx
            // 
            this.dgDetTrx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetTrx.Location = new System.Drawing.Point(6, 19);
            this.dgDetTrx.Name = "dgDetTrx";
            this.dgDetTrx.Size = new System.Drawing.Size(466, 348);
            this.dgDetTrx.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgHdrTrx);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 373);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transactions";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgDetTrx);
            this.groupBox4.Location = new System.Drawing.Point(384, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(478, 373);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Treatment Details";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgDetPayment);
            this.groupBox5.Location = new System.Drawing.Point(868, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(349, 373);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Payment History";
            // 
            // dgDetPayment
            // 
            this.dgDetPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetPayment.Location = new System.Drawing.Point(6, 19);
            this.dgDetPayment.Name = "dgDetPayment";
            this.dgDetPayment.Size = new System.Drawing.Size(337, 348);
            this.dgDetPayment.TabIndex = 3;
            // 
            // grInput
            // 
            this.grInput.Controls.Add(this.nmAdmCount);
            this.grInput.Controls.Add(this.txtLabPrice);
            this.grInput.Controls.Add(this.label12);
            this.grInput.Controls.Add(this.chkAdmin);
            this.grInput.Controls.Add(this.txtSubTotal);
            this.grInput.Controls.Add(this.label13);
            this.grInput.Controls.Add(this.txtDiag);
            this.grInput.Controls.Add(this.txtSubPrice);
            this.grInput.Controls.Add(this.label9);
            this.grInput.Controls.Add(this.btnScrTreatments);
            this.grInput.Controls.Add(this.label11);
            this.grInput.Controls.Add(this.txtTreatmentID);
            this.grInput.Controls.Add(this.btnAddTrx);
            this.grInput.Controls.Add(this.label5);
            this.grInput.Controls.Add(this.btnDelTrx);
            this.grInput.Controls.Add(this.label10);
            this.grInput.Controls.Add(this.label6);
            this.grInput.Controls.Add(this.label7);
            this.grInput.Controls.Add(this.numQty);
            this.grInput.Controls.Add(this.txtDiscount);
            this.grInput.Location = new System.Drawing.Point(384, 391);
            this.grInput.Name = "grInput";
            this.grInput.Size = new System.Drawing.Size(478, 243);
            this.grInput.TabIndex = 21;
            this.grInput.TabStop = false;
            this.grInput.Text = "Treatment Info";
            // 
            // nmAdmCount
            // 
            this.nmAdmCount.Location = new System.Drawing.Point(342, 124);
            this.nmAdmCount.Name = "nmAdmCount";
            this.nmAdmCount.Size = new System.Drawing.Size(30, 20);
            this.nmAdmCount.TabIndex = 32;
            // 
            // txtLabPrice
            // 
            this.txtLabPrice.Location = new System.Drawing.Point(81, 123);
            this.txtLabPrice.Name = "txtLabPrice";
            this.txtLabPrice.Size = new System.Drawing.Size(105, 20);
            this.txtLabPrice.TabIndex = 31;
            this.txtLabPrice.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Lab Price";
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.Location = new System.Drawing.Point(192, 125);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(155, 17);
            this.chkAdmin.TabIndex = 29;
            this.chkAdmin.Text = "Return Administration Fee x";
            this.chkAdmin.UseVisualStyleBackColor = true;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(81, 212);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(105, 20);
            this.txtSubTotal.TabIndex = 28;
            this.txtSubTotal.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 215);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "SubTotal";
            // 
            // txtDiag
            // 
            this.txtDiag.Location = new System.Drawing.Point(81, 149);
            this.txtDiag.Multiline = true;
            this.txtDiag.Name = "txtDiag";
            this.txtDiag.Size = new System.Drawing.Size(186, 57);
            this.txtDiag.TabIndex = 26;
            this.txtDiag.Text = "Refund: ";
            // 
            // txtSubPrice
            // 
            this.txtSubPrice.Location = new System.Drawing.Point(81, 97);
            this.txtSubPrice.Name = "txtSubPrice";
            this.txtSubPrice.ReadOnly = true;
            this.txtSubPrice.Size = new System.Drawing.Size(100, 20);
            this.txtSubPrice.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Total";
            // 
            // btnScrTreatments
            // 
            this.btnScrTreatments.Location = new System.Drawing.Point(192, 17);
            this.btnScrTreatments.Name = "btnScrTreatments";
            this.btnScrTreatments.Size = new System.Drawing.Size(75, 23);
            this.btnScrTreatments.TabIndex = 23;
            this.btnScrTreatments.Text = "Search";
            this.btnScrTreatments.UseVisualStyleBackColor = true;
            this.btnScrTreatments.Click += new System.EventHandler(this.btnScrTreatments_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(133, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "%";
            // 
            // txtTreatmentID
            // 
            this.txtTreatmentID.Location = new System.Drawing.Point(81, 19);
            this.txtTreatmentID.Name = "txtTreatmentID";
            this.txtTreatmentID.Size = new System.Drawing.Size(105, 20);
            this.txtTreatmentID.TabIndex = 10;
            // 
            // btnAddTrx
            // 
            this.btnAddTrx.Location = new System.Drawing.Point(273, 181);
            this.btnAddTrx.Name = "btnAddTrx";
            this.btnAddTrx.Size = new System.Drawing.Size(75, 23);
            this.btnAddTrx.TabIndex = 7;
            this.btnAddTrx.Text = "Add";
            this.btnAddTrx.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Treatment ID";
            // 
            // btnDelTrx
            // 
            this.btnDelTrx.Location = new System.Drawing.Point(273, 210);
            this.btnDelTrx.Name = "btnDelTrx";
            this.btnDelTrx.Size = new System.Drawing.Size(75, 23);
            this.btnDelTrx.TabIndex = 8;
            this.btnDelTrx.Text = "Delete";
            this.btnDelTrx.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Diagnosis";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Quantity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Discount";
            // 
            // numQty
            // 
            this.numQty.Enabled = false;
            this.numQty.Location = new System.Drawing.Point(81, 45);
            this.numQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQty.Name = "numQty";
            this.numQty.Size = new System.Drawing.Size(46, 20);
            this.numQty.TabIndex = 15;
            this.numQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(81, 71);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(46, 20);
            this.txtDiscount.TabIndex = 14;
            this.txtDiscount.Text = "0";
            // 
            // frmRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 645);
            this.Controls.Add(this.grInput);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRefund";
            this.Text = "frmRefund";
            this.Load += new System.EventHandler(this.frmRefund_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHdrTrx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetTrx)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetPayment)).EndInit();
            this.grInput.ResumeLayout(false);
            this.grInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmAdmCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtTrxId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgHdrTrx;
        private System.Windows.Forms.DataGridView dgDetTrx;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgDetPayment;
        public System.Windows.Forms.GroupBox grInput;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDiag;
        private System.Windows.Forms.TextBox txtSubPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnScrTreatments;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTreatmentID;
        private System.Windows.Forms.Button btnAddTrx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDelTrx;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.NumericUpDown nmAdmCount;
        private System.Windows.Forms.TextBox txtLabPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkAdmin;
    }
}