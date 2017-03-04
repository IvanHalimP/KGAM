namespace Klinik_Gigi_Ana_Medika
{
    partial class frmTrx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrx));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTrxNo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dgDetTrx = new System.Windows.Forms.DataGridView();
            this.TreatmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TreatmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddTrx = new System.Windows.Forms.Button();
            this.btnDelTrx = new System.Windows.Forms.Button();
            this.btnSearchPat = new System.Windows.Forms.Button();
            this.grPatient = new System.Windows.Forms.GroupBox();
            this.grDoctor = new System.Windows.Forms.GroupBox();
            this.txtDoctorId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearchDoc = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDoctorName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReloadPayment = new System.Windows.Forms.Button();
            this.dgPayDet = new System.Windows.Forms.DataGridView();
            this.btnLoadTrx = new System.Windows.Forms.Button();
            this.grPay = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkAdm = new System.Windows.Forms.CheckBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.txtChange = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbPayType = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtPay = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtRest = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtGTotal = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnFinTrx = new System.Windows.Forms.Button();
            this.grInput = new System.Windows.Forms.GroupBox();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnScrTreatments = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTreatmentID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblTrx = new System.Windows.Forms.Label();
            this.printReceiptDialog = new System.Windows.Forms.PrintDialog();
            this.printReceiptDoc = new System.Drawing.Printing.PrintDocument();
            this.printReceiptPrev = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetTrx)).BeginInit();
            this.grPatient.SuspendLayout();
            this.grDoctor.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPayDet)).BeginInit();
            this.grPay.SuspendLayout();
            this.grInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient ID";
            // 
            // txtPatientID
            // 
            this.txtPatientID.Location = new System.Drawing.Point(90, 13);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.ReadOnly = true;
            this.txtPatientID.Size = new System.Drawing.Size(228, 20);
            this.txtPatientID.TabIndex = 1;
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(90, 36);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.ReadOnly = true;
            this.txtPatientName.Size = new System.Drawing.Size(228, 20);
            this.txtPatientName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Patient Name";
            // 
            // lblTrxNo
            // 
            this.lblTrxNo.AutoSize = true;
            this.lblTrxNo.Location = new System.Drawing.Point(9, 9);
            this.lblTrxNo.Name = "lblTrxNo";
            this.lblTrxNo.Size = new System.Drawing.Size(86, 13);
            this.lblTrxNo.TabIndex = 4;
            this.lblTrxNo.Text = "Transaction No. ";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(625, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(83, 13);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Sabtu, 2-4-2016";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dgDetTrx
            // 
            this.dgDetTrx.AllowUserToAddRows = false;
            this.dgDetTrx.AllowUserToDeleteRows = false;
            this.dgDetTrx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetTrx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TreatmentID,
            this.TreatmentName,
            this.Price,
            this.Qty,
            this.Discount,
            this.SubTotal});
            this.dgDetTrx.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgDetTrx.Location = new System.Drawing.Point(6, 19);
            this.dgDetTrx.Name = "dgDetTrx";
            this.dgDetTrx.ReadOnly = true;
            this.dgDetTrx.Size = new System.Drawing.Size(773, 150);
            this.dgDetTrx.TabIndex = 6;
            // 
            // TreatmentID
            // 
            this.TreatmentID.HeaderText = "TreatmentID";
            this.TreatmentID.Name = "TreatmentID";
            this.TreatmentID.ReadOnly = true;
            this.TreatmentID.Width = 70;
            // 
            // TreatmentName
            // 
            this.TreatmentName.HeaderText = "TreatmentName";
            this.TreatmentName.Name = "TreatmentName";
            this.TreatmentName.ReadOnly = true;
            this.TreatmentName.Width = 300;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 80;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.Width = 30;
            // 
            // Discount
            // 
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            this.Discount.Width = 60;
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            // 
            // btnAddTrx
            // 
            this.btnAddTrx.Location = new System.Drawing.Point(270, 71);
            this.btnAddTrx.Name = "btnAddTrx";
            this.btnAddTrx.Size = new System.Drawing.Size(75, 23);
            this.btnAddTrx.TabIndex = 7;
            this.btnAddTrx.Text = "Add";
            this.btnAddTrx.UseVisualStyleBackColor = true;
            this.btnAddTrx.Click += new System.EventHandler(this.btnAddTrx_Click);
            // 
            // btnDelTrx
            // 
            this.btnDelTrx.Location = new System.Drawing.Point(270, 97);
            this.btnDelTrx.Name = "btnDelTrx";
            this.btnDelTrx.Size = new System.Drawing.Size(75, 23);
            this.btnDelTrx.TabIndex = 8;
            this.btnDelTrx.Text = "Delete";
            this.btnDelTrx.UseVisualStyleBackColor = true;
            this.btnDelTrx.Click += new System.EventHandler(this.btnDelTrx_Click);
            // 
            // btnSearchPat
            // 
            this.btnSearchPat.Location = new System.Drawing.Point(334, 34);
            this.btnSearchPat.Name = "btnSearchPat";
            this.btnSearchPat.Size = new System.Drawing.Size(75, 23);
            this.btnSearchPat.TabIndex = 9;
            this.btnSearchPat.Text = "Search";
            this.btnSearchPat.UseVisualStyleBackColor = true;
            this.btnSearchPat.Click += new System.EventHandler(this.btnSearchPat_Click);
            // 
            // grPatient
            // 
            this.grPatient.Controls.Add(this.txtPatientID);
            this.grPatient.Controls.Add(this.label1);
            this.grPatient.Controls.Add(this.btnSearchPat);
            this.grPatient.Controls.Add(this.label2);
            this.grPatient.Controls.Add(this.txtPatientName);
            this.grPatient.Location = new System.Drawing.Point(7, 247);
            this.grPatient.Name = "grPatient";
            this.grPatient.Size = new System.Drawing.Size(415, 66);
            this.grPatient.TabIndex = 11;
            this.grPatient.TabStop = false;
            this.grPatient.Text = "Patient";
            // 
            // grDoctor
            // 
            this.grDoctor.Controls.Add(this.txtDoctorId);
            this.grDoctor.Controls.Add(this.label3);
            this.grDoctor.Controls.Add(this.btnSearchDoc);
            this.grDoctor.Controls.Add(this.label4);
            this.grDoctor.Controls.Add(this.txtDoctorName);
            this.grDoctor.Location = new System.Drawing.Point(7, 175);
            this.grDoctor.Name = "grDoctor";
            this.grDoctor.Size = new System.Drawing.Size(415, 66);
            this.grDoctor.TabIndex = 12;
            this.grDoctor.TabStop = false;
            this.grDoctor.Text = "Doctor";
            // 
            // txtDoctorId
            // 
            this.txtDoctorId.Location = new System.Drawing.Point(90, 13);
            this.txtDoctorId.Name = "txtDoctorId";
            this.txtDoctorId.ReadOnly = true;
            this.txtDoctorId.Size = new System.Drawing.Size(228, 20);
            this.txtDoctorId.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Doctor ID";
            // 
            // btnSearchDoc
            // 
            this.btnSearchDoc.Location = new System.Drawing.Point(334, 33);
            this.btnSearchDoc.Name = "btnSearchDoc";
            this.btnSearchDoc.Size = new System.Drawing.Size(75, 23);
            this.btnSearchDoc.TabIndex = 9;
            this.btnSearchDoc.Text = "Search";
            this.btnSearchDoc.UseVisualStyleBackColor = true;
            this.btnSearchDoc.Click += new System.EventHandler(this.btnSearchDoc_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Doctor Name";
            // 
            // txtDoctorName
            // 
            this.txtDoctorName.Location = new System.Drawing.Point(90, 36);
            this.txtDoctorName.Name = "txtDoctorName";
            this.txtDoctorName.ReadOnly = true;
            this.txtDoctorName.Size = new System.Drawing.Size(228, 20);
            this.txtDoctorName.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReloadPayment);
            this.groupBox3.Controls.Add(this.dgPayDet);
            this.groupBox3.Controls.Add(this.grDoctor);
            this.groupBox3.Controls.Add(this.btnLoadTrx);
            this.groupBox3.Controls.Add(this.grPatient);
            this.groupBox3.Controls.Add(this.grPay);
            this.groupBox3.Controls.Add(this.txtGTotal);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.btnFinTrx);
            this.groupBox3.Controls.Add(this.grInput);
            this.groupBox3.Controls.Add(this.dgDetTrx);
            this.groupBox3.Location = new System.Drawing.Point(12, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(787, 535);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Treatments";
            // 
            // btnReloadPayment
            // 
            this.btnReloadPayment.Location = new System.Drawing.Point(180, 500);
            this.btnReloadPayment.Name = "btnReloadPayment";
            this.btnReloadPayment.Size = new System.Drawing.Size(118, 23);
            this.btnReloadPayment.TabIndex = 37;
            this.btnReloadPayment.Text = "Reload Payment";
            this.btnReloadPayment.UseVisualStyleBackColor = true;
            this.btnReloadPayment.Click += new System.EventHandler(this.btnReloadPayment_Click);
            // 
            // dgPayDet
            // 
            this.dgPayDet.AllowUserToAddRows = false;
            this.dgPayDet.AllowUserToDeleteRows = false;
            this.dgPayDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPayDet.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgPayDet.Location = new System.Drawing.Point(7, 321);
            this.dgPayDet.Name = "dgPayDet";
            this.dgPayDet.ReadOnly = true;
            this.dgPayDet.Size = new System.Drawing.Size(415, 173);
            this.dgPayDet.TabIndex = 36;
            // 
            // btnLoadTrx
            // 
            this.btnLoadTrx.Location = new System.Drawing.Point(304, 500);
            this.btnLoadTrx.Name = "btnLoadTrx";
            this.btnLoadTrx.Size = new System.Drawing.Size(118, 23);
            this.btnLoadTrx.TabIndex = 35;
            this.btnLoadTrx.Text = "Load Transactions";
            this.btnLoadTrx.UseVisualStyleBackColor = true;
            this.btnLoadTrx.Click += new System.EventHandler(this.btnLoadTrx_Click);
            // 
            // grPay
            // 
            this.grPay.Controls.Add(this.btnPrint);
            this.grPay.Controls.Add(this.chkAdm);
            this.grPay.Controls.Add(this.btnPay);
            this.grPay.Controls.Add(this.txtChange);
            this.grPay.Controls.Add(this.label20);
            this.grPay.Controls.Add(this.cbPayType);
            this.grPay.Controls.Add(this.label19);
            this.grPay.Controls.Add(this.txtPay);
            this.grPay.Controls.Add(this.label18);
            this.grPay.Controls.Add(this.txtRest);
            this.grPay.Controls.Add(this.label17);
            this.grPay.Controls.Add(this.txtPaid);
            this.grPay.Controls.Add(this.label16);
            this.grPay.Controls.Add(this.label15);
            this.grPay.Controls.Add(this.txtTotalAmount);
            this.grPay.Location = new System.Drawing.Point(428, 370);
            this.grPay.Name = "grPay";
            this.grPay.Size = new System.Drawing.Size(353, 159);
            this.grPay.TabIndex = 31;
            this.grPay.TabStop = false;
            this.grPay.Text = "Payment Info";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(257, 130);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 23);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "Print Receipt";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chkAdm
            // 
            this.chkAdm.AutoSize = true;
            this.chkAdm.Checked = true;
            this.chkAdm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAdm.Location = new System.Drawing.Point(178, 73);
            this.chkAdm.Name = "chkAdm";
            this.chkAdm.Size = new System.Drawing.Size(112, 17);
            this.chkAdm.TabIndex = 13;
            this.chkAdm.Text = "Administration Fee";
            this.chkAdm.UseVisualStyleBackColor = true;
            this.chkAdm.CheckedChanged += new System.EventHandler(this.chkAdm_CheckedChanged);
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(178, 130);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 23);
            this.btnPay.TabIndex = 12;
            this.btnPay.Text = "Commit";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // txtChange
            // 
            this.txtChange.Location = new System.Drawing.Point(82, 123);
            this.txtChange.Name = "txtChange";
            this.txtChange.ReadOnly = true;
            this.txtChange.Size = new System.Drawing.Size(90, 20);
            this.txtChange.TabIndex = 11;
            this.txtChange.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 126);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(44, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "Change";
            // 
            // cbPayType
            // 
            this.cbPayType.FormattingEnabled = true;
            this.cbPayType.Items.AddRange(new object[] {
            "Cash",
            "Debit",
            "MasterCard",
            "Visa"});
            this.cbPayType.Location = new System.Drawing.Point(255, 97);
            this.cbPayType.Name = "cbPayType";
            this.cbPayType.Size = new System.Drawing.Size(92, 21);
            this.cbPayType.TabIndex = 9;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(178, 100);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 13);
            this.label19.TabIndex = 8;
            this.label19.Text = "Payment Type";
            // 
            // txtPay
            // 
            this.txtPay.Location = new System.Drawing.Point(82, 97);
            this.txtPay.Name = "txtPay";
            this.txtPay.Size = new System.Drawing.Size(90, 20);
            this.txtPay.TabIndex = 7;
            this.txtPay.Text = "0";
            this.txtPay.TextChanged += new System.EventHandler(this.txtPay_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 100);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 13);
            this.label18.TabIndex = 6;
            this.label18.Text = "Pay Amount";
            // 
            // txtRest
            // 
            this.txtRest.Location = new System.Drawing.Point(82, 71);
            this.txtRest.Name = "txtRest";
            this.txtRest.ReadOnly = true;
            this.txtRest.Size = new System.Drawing.Size(90, 20);
            this.txtRest.TabIndex = 5;
            this.txtRest.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 74);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "Rest";
            // 
            // txtPaid
            // 
            this.txtPaid.Location = new System.Drawing.Point(82, 44);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.ReadOnly = true;
            this.txtPaid.Size = new System.Drawing.Size(90, 20);
            this.txtPaid.TabIndex = 3;
            this.txtPaid.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Total Amount";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Paid Amount";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(82, 19);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(90, 20);
            this.txtTotalAmount.TabIndex = 0;
            this.txtTotalAmount.Text = "0";
            // 
            // txtGTotal
            // 
            this.txtGTotal.Location = new System.Drawing.Point(509, 318);
            this.txtGTotal.Name = "txtGTotal";
            this.txtGTotal.ReadOnly = true;
            this.txtGTotal.Size = new System.Drawing.Size(105, 20);
            this.txtGTotal.TabIndex = 29;
            this.txtGTotal.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(434, 321);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "GrandTotal";
            // 
            // btnFinTrx
            // 
            this.btnFinTrx.Location = new System.Drawing.Point(698, 316);
            this.btnFinTrx.Name = "btnFinTrx";
            this.btnFinTrx.Size = new System.Drawing.Size(75, 23);
            this.btnFinTrx.TabIndex = 14;
            this.btnFinTrx.Text = "Finish";
            this.btnFinTrx.UseVisualStyleBackColor = true;
            this.btnFinTrx.Click += new System.EventHandler(this.btnFinTrx_Click);
            // 
            // grInput
            // 
            this.grInput.Controls.Add(this.txtSubTotal);
            this.grInput.Controls.Add(this.label13);
            this.grInput.Controls.Add(this.btnScrTreatments);
            this.grInput.Controls.Add(this.label11);
            this.grInput.Controls.Add(this.txtTreatmentID);
            this.grInput.Controls.Add(this.btnAddTrx);
            this.grInput.Controls.Add(this.label5);
            this.grInput.Controls.Add(this.btnDelTrx);
            this.grInput.Controls.Add(this.label6);
            this.grInput.Controls.Add(this.label7);
            this.grInput.Controls.Add(this.numQty);
            this.grInput.Controls.Add(this.txtDiscount);
            this.grInput.Location = new System.Drawing.Point(428, 175);
            this.grInput.Name = "grInput";
            this.grInput.Size = new System.Drawing.Size(351, 134);
            this.grInput.TabIndex = 20;
            this.grInput.TabStop = false;
            this.grInput.Text = "Treatment Info";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(81, 99);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(105, 20);
            this.txtSubTotal.TabIndex = 28;
            this.txtSubTotal.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "SubTotal";
            // 
            // btnScrTreatments
            // 
            this.btnScrTreatments.Location = new System.Drawing.Point(270, 17);
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
            this.label11.Location = new System.Drawing.Point(133, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "%";
            // 
            // txtTreatmentID
            // 
            this.txtTreatmentID.Location = new System.Drawing.Point(81, 21);
            this.txtTreatmentID.Name = "txtTreatmentID";
            this.txtTreatmentID.Size = new System.Drawing.Size(105, 20);
            this.txtTreatmentID.TabIndex = 10;
            this.txtTreatmentID.TextChanged += new System.EventHandler(this.txtTreatmentID_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Treatment ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Quantity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Discount";
            // 
            // numQty
            // 
            this.numQty.Enabled = false;
            this.numQty.Location = new System.Drawing.Point(81, 47);
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
            this.numQty.ValueChanged += new System.EventHandler(this.numQty_ValueChanged);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(81, 73);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(46, 20);
            this.txtDiscount.TabIndex = 14;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // lblTrx
            // 
            this.lblTrx.AutoSize = true;
            this.lblTrx.Location = new System.Drawing.Point(96, 9);
            this.lblTrx.Name = "lblTrx";
            this.lblTrx.Size = new System.Drawing.Size(0, 13);
            this.lblTrx.TabIndex = 14;
            // 
            // printReceiptDialog
            // 
            this.printReceiptDialog.UseEXDialog = true;
            // 
            // printReceiptDoc
            // 
            this.printReceiptDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printReceiptDoc_PrintPage);
            // 
            // printReceiptPrev
            // 
            this.printReceiptPrev.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printReceiptPrev.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printReceiptPrev.ClientSize = new System.Drawing.Size(400, 300);
            this.printReceiptPrev.Enabled = true;
            this.printReceiptPrev.Icon = ((System.Drawing.Icon)(resources.GetObject("printReceiptPrev.Icon")));
            this.printReceiptPrev.Name = "printReceiptPrev";
            this.printReceiptPrev.Visible = false;
            // 
            // frmTrx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 573);
            this.Controls.Add(this.lblTrx);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTrxNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTrx";
            this.Text = "frmTrx";
            this.Load += new System.EventHandler(this.frmTrx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetTrx)).EndInit();
            this.grPatient.ResumeLayout(false);
            this.grPatient.PerformLayout();
            this.grDoctor.ResumeLayout(false);
            this.grDoctor.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPayDet)).EndInit();
            this.grPay.ResumeLayout(false);
            this.grPay.PerformLayout();
            this.grInput.ResumeLayout(false);
            this.grInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPatientID;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTrxNo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DataGridView dgDetTrx;
        private System.Windows.Forms.Button btnAddTrx;
        private System.Windows.Forms.Button btnDelTrx;
        private System.Windows.Forms.Button btnSearchPat;
        private System.Windows.Forms.GroupBox grPatient;
        private System.Windows.Forms.GroupBox grDoctor;
        private System.Windows.Forms.TextBox txtDoctorId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearchDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDoctorName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTreatmentID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnScrTreatments;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtGTotal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.GroupBox grPay;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.TextBox txtChange;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbPayType;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtPay;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtRest;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblTrx;
        public System.Windows.Forms.GroupBox grInput;
        private System.Windows.Forms.CheckBox chkAdm;
        public System.Windows.Forms.Button btnFinTrx;
        private System.Windows.Forms.PrintDialog printReceiptDialog;
        private System.Drawing.Printing.PrintDocument printReceiptDoc;
        private System.Windows.Forms.PrintPreviewDialog printReceiptPrev;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn TreatmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TreatmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.Button btnReloadPayment;
        private System.Windows.Forms.DataGridView dgPayDet;
        private System.Windows.Forms.Button btnLoadTrx;
    }
}