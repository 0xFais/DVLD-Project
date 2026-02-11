using System.ComponentModel;

namespace DVLD.Applications.InternationalDrivingLicenseApplications
{
    partial class frmListInternationalDrivingLicenseApplications
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
            this.dgvILApps = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddInternationalLicense = new System.Windows.Forms.Button();
            this.cBoxFilters = new System.Windows.Forms.ComboBox();
            this.txtFilterSearch = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cBoxIsActiveFilters = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvILApps)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvILApps
            // 
            this.dgvILApps.AllowUserToAddRows = false;
            this.dgvILApps.AllowUserToDeleteRows = false;
            this.dgvILApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvILApps.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvILApps.Location = new System.Drawing.Point(12, 268);
            this.dgvILApps.Name = "dgvILApps";
            this.dgvILApps.ReadOnly = true;
            this.dgvILApps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvILApps.Size = new System.Drawing.Size(990, 267);
            this.dgvILApps.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(180, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(621, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "International License Applications";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 545);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "# Records : ";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(134, 545);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(100, 23);
            this.lblRecordsCount.TabIndex = 3;
            this.lblRecordsCount.Text = "??";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(927, 545);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddInternationalLicense
            // 
            this.btnAddInternationalLicense.Location = new System.Drawing.Point(823, 213);
            this.btnAddInternationalLicense.Name = "btnAddInternationalLicense";
            this.btnAddInternationalLicense.Size = new System.Drawing.Size(179, 49);
            this.btnAddInternationalLicense.TabIndex = 5;
            this.btnAddInternationalLicense.Text = "Add New International License";
            this.btnAddInternationalLicense.UseVisualStyleBackColor = true;
            this.btnAddInternationalLicense.Click += new System.EventHandler(this.btnAddInternationalLicense_Click);
            // 
            // cBoxFilters
            // 
            this.cBoxFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxFilters.FormattingEnabled = true;
            this.cBoxFilters.Location = new System.Drawing.Point(12, 241);
            this.cBoxFilters.Name = "cBoxFilters";
            this.cBoxFilters.Size = new System.Drawing.Size(151, 21);
            this.cBoxFilters.TabIndex = 6;
            this.cBoxFilters.SelectedIndexChanged += new System.EventHandler(this.cBoxFilters_SelectedIndexChanged);
            // 
            // txtFilterSearch
            // 
            this.txtFilterSearch.Location = new System.Drawing.Point(169, 242);
            this.txtFilterSearch.Name = "txtFilterSearch";
            this.txtFilterSearch.Size = new System.Drawing.Size(151, 20);
            this.txtFilterSearch.TabIndex = 7;
            this.txtFilterSearch.Visible = false;
            this.txtFilterSearch.TextChanged += new System.EventHandler(this.txtFilterSearch_TextChanged);
            this.txtFilterSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterSearch_KeyPress);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.showPersonInfoToolStripMenuItem, this.showLicenseDetailsToolStripMenuItem, this.showLicenseHistoryToolStripMenuItem });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 70);
            // 
            // showPersonInfoToolStripMenuItem
            // 
            this.showPersonInfoToolStripMenuItem.Name = "showPersonInfoToolStripMenuItem";
            this.showPersonInfoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.showPersonInfoToolStripMenuItem.Text = "Show Person Details";
            this.showPersonInfoToolStripMenuItem.Click += new System.EventHandler(this.showPersonInfoToolStripMenuItem_Click);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // showLicenseHistoryToolStripMenuItem
            // 
            this.showLicenseHistoryToolStripMenuItem.Name = "showLicenseHistoryToolStripMenuItem";
            this.showLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.showLicenseHistoryToolStripMenuItem.Text = "Show License History";
            this.showLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showLicenseHistoryToolStripMenuItem_Click);
            // 
            // cBoxIsActiveFilters
            // 
            this.cBoxIsActiveFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxIsActiveFilters.FormattingEnabled = true;
            this.cBoxIsActiveFilters.Location = new System.Drawing.Point(169, 241);
            this.cBoxIsActiveFilters.Name = "cBoxIsActiveFilters";
            this.cBoxIsActiveFilters.Size = new System.Drawing.Size(151, 21);
            this.cBoxIsActiveFilters.TabIndex = 8;
            this.cBoxIsActiveFilters.SelectedIndexChanged += new System.EventHandler(this.cBoxIsActiveFilters_SelectedIndexChanged);
            // 
            // frmListInternationalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 577);
            this.Controls.Add(this.cBoxIsActiveFilters);
            this.Controls.Add(this.txtFilterSearch);
            this.Controls.Add(this.cBoxFilters);
            this.Controls.Add(this.btnAddInternationalLicense);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvILApps);
            this.Name = "frmListInternationalDrivingLicenseApplications";
            this.Text = "frmListInternationalDrivingLicenseApplications";
            this.Load += new System.EventHandler(this.frmListInternationalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvILApps)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox cBoxIsActiveFilters;

        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseHistoryToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem showPersonInfoToolStripMenuItem;

        private System.Windows.Forms.ComboBox cBoxFilters;
        private System.Windows.Forms.TextBox txtFilterSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddInternationalLicense;

        private System.Windows.Forms.DataGridView dgvILApps;

        #endregion
    }
}