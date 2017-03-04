﻿namespace Klinik_Gigi_Ana_Medika
{
    partial class frmMonthlyRecap
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDoctorName = new System.Windows.Forms.ComboBox();
            this.anaMedikaDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.anaMedikaDBDataSet = new Klinik_Gigi_Ana_Medika.AnaMedikaDBDataSet();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.cbDateRange = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgPreviewRecap = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.anaMedikaDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anaMedikaDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPreviewRecap)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbDoctorName);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnPreview);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.cbDateRange);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 448);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action Items";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Doctor Name:";
            // 
            // cbDoctorName
            // 
            this.cbDoctorName.DataSource = this.anaMedikaDBDataSetBindingSource;
            this.cbDoctorName.FormattingEnabled = true;
            this.cbDoctorName.Location = new System.Drawing.Point(189, 60);
            this.cbDoctorName.Name = "cbDoctorName";
            this.cbDoctorName.Size = new System.Drawing.Size(121, 21);
            this.cbDoctorName.TabIndex = 5;
            // 
            // anaMedikaDBDataSetBindingSource
            // 
            this.anaMedikaDBDataSetBindingSource.DataSource = this.anaMedikaDBDataSet;
            this.anaMedikaDBDataSetBindingSource.Position = 0;
            // 
            // anaMedikaDBDataSet
            // 
            this.anaMedikaDBDataSet.DataSetName = "AnaMedikaDBDataSet";
            this.anaMedikaDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(523, 33);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Generate and Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(442, 32);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(316, 33);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            // 
            // cbDateRange
            // 
            this.cbDateRange.FormattingEnabled = true;
            this.cbDateRange.Items.AddRange(new object[] {
            "21 Dec - 20 Jan",
            "21 Jan - 20 Feb",
            "21 Feb - 20 Mar",
            "21 Mar - 20 Apr",
            "21 Apr - 20 May",
            "21 May - 20 Jun",
            "21 Jun - 20 Jul",
            "21 Jul - 20 Aug",
            "21 Aug - 20 Sep",
            "21 Sep - 20 Okt",
            "21 Okt - 20 Nov",
            "21 Nov - 20 Dec"});
            this.cbDateRange.Location = new System.Drawing.Point(189, 32);
            this.cbDateRange.MaxDropDownItems = 12;
            this.cbDateRange.Name = "cbDateRange";
            this.cbDateRange.Size = new System.Drawing.Size(121, 21);
            this.cbDateRange.TabIndex = 1;
            this.cbDateRange.Text = "Period";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Generate Monthly Recap for:";
            // 
            // dgPreviewRecap
            // 
            this.dgPreviewRecap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPreviewRecap.Location = new System.Drawing.Point(13, 12);
            this.dgPreviewRecap.Name = "dgPreviewRecap";
            this.dgPreviewRecap.Size = new System.Drawing.Size(759, 426);
            this.dgPreviewRecap.TabIndex = 4;
            // 
            // frmMonthlyRecap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgPreviewRecap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMonthlyRecap";
            this.Text = "frmMonthlyRecap";
            this.Load += new System.EventHandler(this.frmMonthlyRecap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.anaMedikaDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anaMedikaDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPreviewRecap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox cbDateRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgPreviewRecap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDoctorName;
        private System.Windows.Forms.BindingSource anaMedikaDBDataSetBindingSource;
        private AnaMedikaDBDataSet anaMedikaDBDataSet;
    }
}