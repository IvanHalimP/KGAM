namespace Klinik_Gigi_Ana_Medika
{
    partial class frmSearchTreatment
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
            this.btnSelectTreatment = new System.Windows.Forms.Button();
            this.btnRld = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgTreatments = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTreatments)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectTreatment);
            this.groupBox1.Controls.Add(this.btnRld);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 310);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 81);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Treatment";
            // 
            // btnSelectTreatment
            // 
            this.btnSelectTreatment.Location = new System.Drawing.Point(404, 45);
            this.btnSelectTreatment.Name = "btnSelectTreatment";
            this.btnSelectTreatment.Size = new System.Drawing.Size(75, 23);
            this.btnSelectTreatment.TabIndex = 6;
            this.btnSelectTreatment.Text = "Select";
            this.btnSelectTreatment.UseVisualStyleBackColor = true;
            this.btnSelectTreatment.Click += new System.EventHandler(this.btnSelectTreatment_Click);
            // 
            // btnRld
            // 
            this.btnRld.Location = new System.Drawing.Point(204, 45);
            this.btnRld.Name = "btnRld";
            this.btnRld.Size = new System.Drawing.Size(75, 23);
            this.btnRld.TabIndex = 5;
            this.btnRld.Text = "Reload";
            this.btnRld.UseVisualStyleBackColor = true;
            this.btnRld.Click += new System.EventHandler(this.btnRld_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Treatment Code";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(98, 21);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 3;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Treatment Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(98, 47);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(204, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgTreatments);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 292);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Treatment List";
            // 
            // dgTreatments
            // 
            this.dgTreatments.AllowUserToAddRows = false;
            this.dgTreatments.AllowUserToDeleteRows = false;
            this.dgTreatments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTreatments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgTreatments.Location = new System.Drawing.Point(6, 19);
            this.dgTreatments.Name = "dgTreatments";
            this.dgTreatments.ReadOnly = true;
            this.dgTreatments.Size = new System.Drawing.Size(473, 267);
            this.dgTreatments.TabIndex = 1;
            this.dgTreatments.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTreatments_CellContentDoubleClick);
            this.dgTreatments.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgTreatments_KeyDown);
            // 
            // frmSearchTreatment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 403);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchTreatment";
            this.Text = "frmSearchTreatment";
            this.Load += new System.EventHandler(this.frmSearchTreatment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTreatments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgTreatments;
        private System.Windows.Forms.Button btnRld;
        private System.Windows.Forms.Button btnSelectTreatment;
    }
}