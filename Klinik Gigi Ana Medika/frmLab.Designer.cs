namespace Klinik_Gigi_Ana_Medika
{
    partial class frmLab
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
            this.Transactions = new System.Windows.Forms.GroupBox();
            this.dgHdrTrx = new System.Windows.Forms.DataGridView();
            this.Treatments = new System.Windows.Forms.GroupBox();
            this.dgDetTrx = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgDetLab = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelcTrx = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatient = new System.Windows.Forms.TextBox();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.txtTrxId = new System.Windows.Forms.TextBox();
            this.btnTrxReload = new System.Windows.Forms.Button();
            this.btnTrxSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTrxStatus = new System.Windows.Forms.TextBox();
            this.txtTreatmentName = new System.Windows.Forms.TextBox();
            this.txtDetTrxId = new System.Windows.Forms.TextBox();
            this.btnDetTrxReload = new System.Windows.Forms.Button();
            this.btnDetTrxSelect = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.Price = new System.Windows.Forms.Label();
            this.Item = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLabPrice = new System.Windows.Forms.TextBox();
            this.txtLabItem = new System.Windows.Forms.TextBox();
            this.txtDetLabId = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.Transactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHdrTrx)).BeginInit();
            this.Treatments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetTrx)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetLab)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Transactions
            // 
            this.Transactions.Controls.Add(this.dgHdrTrx);
            this.Transactions.Location = new System.Drawing.Point(12, 12);
            this.Transactions.Name = "Transactions";
            this.Transactions.Size = new System.Drawing.Size(318, 363);
            this.Transactions.TabIndex = 0;
            this.Transactions.TabStop = false;
            this.Transactions.Text = "Transactions";
            // 
            // dgHdrTrx
            // 
            this.dgHdrTrx.AllowUserToAddRows = false;
            this.dgHdrTrx.AllowUserToDeleteRows = false;
            this.dgHdrTrx.AllowUserToOrderColumns = true;
            this.dgHdrTrx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHdrTrx.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgHdrTrx.Location = new System.Drawing.Point(7, 19);
            this.dgHdrTrx.MultiSelect = false;
            this.dgHdrTrx.Name = "dgHdrTrx";
            this.dgHdrTrx.ReadOnly = true;
            this.dgHdrTrx.Size = new System.Drawing.Size(305, 338);
            this.dgHdrTrx.TabIndex = 0;
            this.dgHdrTrx.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgHdrTrx_CellContentClick);
            this.dgHdrTrx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgHdrTrx_KeyDown);
            // 
            // Treatments
            // 
            this.Treatments.Controls.Add(this.dgDetTrx);
            this.Treatments.Location = new System.Drawing.Point(336, 12);
            this.Treatments.Name = "Treatments";
            this.Treatments.Size = new System.Drawing.Size(340, 363);
            this.Treatments.TabIndex = 1;
            this.Treatments.TabStop = false;
            this.Treatments.Text = "Treatments";
            // 
            // dgDetTrx
            // 
            this.dgDetTrx.AllowUserToAddRows = false;
            this.dgDetTrx.AllowUserToDeleteRows = false;
            this.dgDetTrx.AllowUserToOrderColumns = true;
            this.dgDetTrx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetTrx.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgDetTrx.Location = new System.Drawing.Point(6, 19);
            this.dgDetTrx.MultiSelect = false;
            this.dgDetTrx.Name = "dgDetTrx";
            this.dgDetTrx.ReadOnly = true;
            this.dgDetTrx.Size = new System.Drawing.Size(328, 338);
            this.dgDetTrx.TabIndex = 0;
            this.dgDetTrx.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDetTrx_CellContentClick);
            this.dgDetTrx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgDetTrx_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgDetLab);
            this.groupBox3.Location = new System.Drawing.Point(682, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(318, 363);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lab Costs";
            // 
            // dgDetLab
            // 
            this.dgDetLab.AllowUserToAddRows = false;
            this.dgDetLab.AllowUserToDeleteRows = false;
            this.dgDetLab.AllowUserToOrderColumns = true;
            this.dgDetLab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetLab.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgDetLab.Location = new System.Drawing.Point(8, 19);
            this.dgDetLab.MultiSelect = false;
            this.dgDetLab.Name = "dgDetLab";
            this.dgDetLab.ReadOnly = true;
            this.dgDetLab.Size = new System.Drawing.Size(306, 338);
            this.dgDetLab.TabIndex = 0;
            this.dgDetLab.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDetLab_CellContentClick);
            this.dgDetLab.SelectionChanged += new System.EventHandler(this.dgDetLab_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelcTrx);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPatient);
            this.groupBox1.Controls.Add(this.txtDoctor);
            this.groupBox1.Controls.Add(this.txtTrxId);
            this.groupBox1.Controls.Add(this.btnTrxReload);
            this.groupBox1.Controls.Add(this.btnTrxSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 381);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 105);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Transaction";
            // 
            // btnSelcTrx
            // 
            this.btnSelcTrx.Location = new System.Drawing.Point(237, 46);
            this.btnSelcTrx.Name = "btnSelcTrx";
            this.btnSelcTrx.Size = new System.Drawing.Size(75, 23);
            this.btnSelcTrx.TabIndex = 8;
            this.btnSelcTrx.Text = "Select";
            this.btnSelcTrx.UseVisualStyleBackColor = true;
            this.btnSelcTrx.Click += new System.EventHandler(this.btnSelcTrx_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Patient Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Doctor Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "TransactionId";
            // 
            // txtPatient
            // 
            this.txtPatient.Location = new System.Drawing.Point(82, 74);
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.Size = new System.Drawing.Size(149, 20);
            this.txtPatient.TabIndex = 4;
            this.txtPatient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPatient_KeyDown);
            // 
            // txtDoctor
            // 
            this.txtDoctor.Location = new System.Drawing.Point(82, 48);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(149, 20);
            this.txtDoctor.TabIndex = 3;
            this.txtDoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDoctor_KeyDown);
            // 
            // txtTrxId
            // 
            this.txtTrxId.Location = new System.Drawing.Point(82, 22);
            this.txtTrxId.Name = "txtTrxId";
            this.txtTrxId.Size = new System.Drawing.Size(149, 20);
            this.txtTrxId.TabIndex = 2;
            this.txtTrxId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTrxId_KeyDown);
            // 
            // btnTrxReload
            // 
            this.btnTrxReload.Location = new System.Drawing.Point(237, 72);
            this.btnTrxReload.Name = "btnTrxReload";
            this.btnTrxReload.Size = new System.Drawing.Size(75, 23);
            this.btnTrxReload.TabIndex = 1;
            this.btnTrxReload.Text = "Reload";
            this.btnTrxReload.UseVisualStyleBackColor = true;
            this.btnTrxReload.Click += new System.EventHandler(this.btnTrxReload_Click);
            // 
            // btnTrxSearch
            // 
            this.btnTrxSearch.Location = new System.Drawing.Point(237, 20);
            this.btnTrxSearch.Name = "btnTrxSearch";
            this.btnTrxSearch.Size = new System.Drawing.Size(75, 23);
            this.btnTrxSearch.TabIndex = 0;
            this.btnTrxSearch.Text = "Search";
            this.btnTrxSearch.UseVisualStyleBackColor = true;
            this.btnTrxSearch.Click += new System.EventHandler(this.btnTrxSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtTrxStatus);
            this.groupBox2.Controls.Add(this.txtTreatmentName);
            this.groupBox2.Controls.Add(this.txtDetTrxId);
            this.groupBox2.Controls.Add(this.btnDetTrxReload);
            this.groupBox2.Controls.Add(this.btnDetTrxSelect);
            this.groupBox2.Location = new System.Drawing.Point(347, 381);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 105);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selected Transaction Treatment";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Treatment Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "detail Id";
            // 
            // txtTrxStatus
            // 
            this.txtTrxStatus.Location = new System.Drawing.Point(93, 72);
            this.txtTrxStatus.Name = "txtTrxStatus";
            this.txtTrxStatus.ReadOnly = true;
            this.txtTrxStatus.Size = new System.Drawing.Size(138, 20);
            this.txtTrxStatus.TabIndex = 12;
            // 
            // txtTreatmentName
            // 
            this.txtTreatmentName.Location = new System.Drawing.Point(93, 48);
            this.txtTreatmentName.Name = "txtTreatmentName";
            this.txtTreatmentName.ReadOnly = true;
            this.txtTreatmentName.Size = new System.Drawing.Size(138, 20);
            this.txtTreatmentName.TabIndex = 11;
            // 
            // txtDetTrxId
            // 
            this.txtDetTrxId.Location = new System.Drawing.Point(93, 22);
            this.txtDetTrxId.Name = "txtDetTrxId";
            this.txtDetTrxId.ReadOnly = true;
            this.txtDetTrxId.Size = new System.Drawing.Size(138, 20);
            this.txtDetTrxId.TabIndex = 10;
            // 
            // btnDetTrxReload
            // 
            this.btnDetTrxReload.Location = new System.Drawing.Point(237, 71);
            this.btnDetTrxReload.Name = "btnDetTrxReload";
            this.btnDetTrxReload.Size = new System.Drawing.Size(75, 23);
            this.btnDetTrxReload.TabIndex = 9;
            this.btnDetTrxReload.Text = "Reload";
            this.btnDetTrxReload.UseVisualStyleBackColor = true;
            this.btnDetTrxReload.Click += new System.EventHandler(this.btnDetTrxReload_Click);
            // 
            // btnDetTrxSelect
            // 
            this.btnDetTrxSelect.Location = new System.Drawing.Point(237, 45);
            this.btnDetTrxSelect.Name = "btnDetTrxSelect";
            this.btnDetTrxSelect.Size = new System.Drawing.Size(75, 23);
            this.btnDetTrxSelect.TabIndex = 8;
            this.btnDetTrxSelect.Text = "Select";
            this.btnDetTrxSelect.UseVisualStyleBackColor = true;
            this.btnDetTrxSelect.Click += new System.EventHandler(this.btnDetTrxSelect_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnInsert);
            this.groupBox4.Controls.Add(this.Price);
            this.groupBox4.Controls.Add(this.Item);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtLabPrice);
            this.groupBox4.Controls.Add(this.txtLabItem);
            this.groupBox4.Controls.Add(this.txtDetLabId);
            this.groupBox4.Controls.Add(this.btnUpdate);
            this.groupBox4.Controls.Add(this.btnDelete);
            this.groupBox4.Location = new System.Drawing.Point(682, 381);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(318, 105);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Add Lab Cost";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(237, 20);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 16;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Location = new System.Drawing.Point(6, 77);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(31, 13);
            this.Price.TabIndex = 15;
            this.Price.Text = "Price";
            // 
            // Item
            // 
            this.Item.AutoSize = true;
            this.Item.Location = new System.Drawing.Point(6, 51);
            this.Item.Name = "Item";
            this.Item.Size = new System.Drawing.Size(27, 13);
            this.Item.TabIndex = 14;
            this.Item.Text = "Item";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "detail Lab Id";
            // 
            // txtLabPrice
            // 
            this.txtLabPrice.Location = new System.Drawing.Point(77, 74);
            this.txtLabPrice.Name = "txtLabPrice";
            this.txtLabPrice.Size = new System.Drawing.Size(154, 20);
            this.txtLabPrice.TabIndex = 12;
            // 
            // txtLabItem
            // 
            this.txtLabItem.Location = new System.Drawing.Point(77, 48);
            this.txtLabItem.Name = "txtLabItem";
            this.txtLabItem.Size = new System.Drawing.Size(154, 20);
            this.txtLabItem.TabIndex = 11;
            // 
            // txtDetLabId
            // 
            this.txtDetLabId.Location = new System.Drawing.Point(77, 22);
            this.txtDetLabId.Name = "txtDetLabId";
            this.txtDetLabId.ReadOnly = true;
            this.txtDetLabId.Size = new System.Drawing.Size(154, 20);
            this.txtDetLabId.TabIndex = 10;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(237, 46);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(237, 72);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 498);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Treatments);
            this.Controls.Add(this.Transactions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLab";
            this.Text = "frmLab";
            this.Load += new System.EventHandler(this.frmLab_Load);
            this.Transactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgHdrTrx)).EndInit();
            this.Treatments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetTrx)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetLab)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Transactions;
        private System.Windows.Forms.GroupBox Treatments;
        private System.Windows.Forms.DataGridView dgHdrTrx;
        private System.Windows.Forms.DataGridView dgDetTrx;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgDetLab;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPatient;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.TextBox txtTrxId;
        private System.Windows.Forms.Button btnTrxReload;
        private System.Windows.Forms.Button btnTrxSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTrxStatus;
        private System.Windows.Forms.TextBox txtTreatmentName;
        private System.Windows.Forms.TextBox txtDetTrxId;
        private System.Windows.Forms.Button btnDetTrxReload;
        private System.Windows.Forms.Button btnDetTrxSelect;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label Item;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLabPrice;
        private System.Windows.Forms.TextBox txtLabItem;
        private System.Windows.Forms.TextBox txtDetLabId;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSelcTrx;
    }
}