using System.ComponentModel;

namespace DVLD.Tests.TestTypes
{
    partial class frmTestTypeList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.dgvTestTypeLIst = new System.Windows.Forms.DataGridView();
            this.lblTitel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTestTypesCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateTestTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTypeLIst)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTestTypeLIst
            // 
            this.dgvTestTypeLIst.AllowUserToAddRows = false;
            this.dgvTestTypeLIst.AllowUserToDeleteRows = false;
            this.dgvTestTypeLIst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestTypeLIst.Location = new System.Drawing.Point(12, 167);
            this.dgvTestTypeLIst.Name = "dgvTestTypeLIst";
            this.dgvTestTypeLIst.ReadOnly = true;
            this.dgvTestTypeLIst.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTestTypeLIst.Size = new System.Drawing.Size(693, 231);
            this.dgvTestTypeLIst.TabIndex = 0;
            // 
            // lblTitel
            // 
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.Location = new System.Drawing.Point(263, 41);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(196, 44);
            this.lblTitel.TabIndex = 1;
            this.lblTitel.Text = "Test Types List";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Test Types : ";
            // 
            // lblTestTypesCount
            // 
            this.lblTestTypesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestTypesCount.Location = new System.Drawing.Point(71, 141);
            this.lblTestTypesCount.Name = "lblTestTypesCount";
            this.lblTestTypesCount.Size = new System.Drawing.Size(38, 23);
            this.lblTestTypesCount.TabIndex = 3;
            this.lblTestTypesCount.Text = "??";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(600, 404);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 34);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateTestTypeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 26);
            // 
            // updateTestTypeToolStripMenuItem
            // 
            this.updateTestTypeToolStripMenuItem.Name = "updateTestTypeToolStripMenuItem";
            this.updateTestTypeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.updateTestTypeToolStripMenuItem.Text = "Update Test Type";
            this.updateTestTypeToolStripMenuItem.Click += new System.EventHandler(this.updateTestTypeToolStripMenuItem_Click);
            // 
            // frmTestTypeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 450);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTestTypesCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.dgvTestTypeLIst);
            this.Name = "frmTestTypeList";
            this.Text = "frmAddUpdateTestTypes";
            this.Load += new System.EventHandler(this.frmTestTypeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTypeLIst)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateTestTypeToolStripMenuItem;

        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTestTypesCount;
        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.DataGridView dgvTestTypeLIst;

        #endregion
    }
}