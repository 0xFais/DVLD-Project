using System.ComponentModel;

namespace DVLD.Applications.ApplicationsType
{
    partial class frmApplicationTypeList
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
            this.dgvApplictaionType = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblApplicationsCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateApplicatoinTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplictaionType)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvApplictaionType
            // 
            this.dgvApplictaionType.AllowUserToAddRows = false;
            this.dgvApplictaionType.AllowUserToDeleteRows = false;
            this.dgvApplictaionType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplictaionType.Location = new System.Drawing.Point(13, 171);
            this.dgvApplictaionType.Name = "dgvApplictaionType";
            this.dgvApplictaionType.ReadOnly = true;
            this.dgvApplictaionType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplictaionType.Size = new System.Drawing.Size(680, 236);
            this.dgvApplictaionType.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(141, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 50);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Manage Applicatoins Type";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Applications Type : ";
            // 
            // lblApplicationsCount
            // 
            this.lblApplicationsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationsCount.Location = new System.Drawing.Point(141, 148);
            this.lblApplicationsCount.Name = "lblApplicationsCount";
            this.lblApplicationsCount.Size = new System.Drawing.Size(52, 23);
            this.lblApplicationsCount.TabIndex = 3;
            this.lblApplicationsCount.Text = "label3";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(578, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.updateApplicatoinTypeToolStripMenuItem });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(205, 26);
            // 
            // updateApplicatoinTypeToolStripMenuItem
            // 
            this.updateApplicatoinTypeToolStripMenuItem.Name = "updateApplicatoinTypeToolStripMenuItem";
            this.updateApplicatoinTypeToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.updateApplicatoinTypeToolStripMenuItem.Text = "Update Applicatoin Type";
            this.updateApplicatoinTypeToolStripMenuItem.Click += new System.EventHandler(this.updateApplicatoinTypeToolStripMenuItem_Click);
            // 
            // frmApplicationTypeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 450);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblApplicationsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvApplictaionType);
            this.Name = "frmApplicationTypeList";
            this.Text = "frmApplicationTypeList";
            this.Load += new System.EventHandler(this.frmApplicationTypeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplictaionType)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateApplicatoinTypeToolStripMenuItem;

        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblApplicationsCount;

        private System.Windows.Forms.DataGridView dgvApplictaionType;

        #endregion
    }
}