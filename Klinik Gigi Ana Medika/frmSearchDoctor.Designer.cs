namespace Klinik_Gigi_Ana_Medika
{
    partial class frmSearchDoctor
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.sName = new System.Windows.Forms.TextBox();
            this.btnScr = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgDoctor = new System.Windows.Forms.DataGridView();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDoctor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReload);
            this.groupBox3.Controls.Add(this.sName);
            this.groupBox3.Controls.Add(this.btnScr);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(18, 276);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(268, 97);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search Doctor";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(10, 63);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 19;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // sName
            // 
            this.sName.Location = new System.Drawing.Point(10, 37);
            this.sName.Name = "sName";
            this.sName.Size = new System.Drawing.Size(252, 20);
            this.sName.TabIndex = 2;
            this.sName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sName_KeyDown);
            // 
            // btnScr
            // 
            this.btnScr.Location = new System.Drawing.Point(187, 63);
            this.btnScr.Name = "btnScr";
            this.btnScr.Size = new System.Drawing.Size(75, 23);
            this.btnScr.TabIndex = 17;
            this.btnScr.Text = "Search";
            this.btnScr.UseVisualStyleBackColor = true;
            this.btnScr.Click += new System.EventHandler(this.btnScr_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Doctor Name";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(292, 339);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(99, 34);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgDoctor);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 264);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Doctor List";
            // 
            // dgDoctor
            // 
            this.dgDoctor.AllowUserToAddRows = false;
            this.dgDoctor.AllowUserToDeleteRows = false;
            this.dgDoctor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDoctor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgDoctor.Location = new System.Drawing.Point(6, 19);
            this.dgDoctor.Name = "dgDoctor";
            this.dgDoctor.ReadOnly = true;
            this.dgDoctor.Size = new System.Drawing.Size(367, 239);
            this.dgDoctor.TabIndex = 0;
            this.dgDoctor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDoctor_CellClick);
            this.dgDoctor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDoctor_CellClick);
            this.dgDoctor.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDoctor_CellContentDoubleClick);
            this.dgDoctor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDoctor_CellContentDoubleClick);
            this.dgDoctor.SelectionChanged += new System.EventHandler(this.dgDoctor_SelectionChanged);
            this.dgDoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgDoctor_KeyDown);
            // 
            // frmSearchDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 381);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchDoctor";
            this.Text = "frmSearchDoctor";
            this.Load += new System.EventHandler(this.frmSearchDoctor_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDoctor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox sName;
        private System.Windows.Forms.Button btnScr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgDoctor;
        private System.Windows.Forms.Button btnReload;
    }
}