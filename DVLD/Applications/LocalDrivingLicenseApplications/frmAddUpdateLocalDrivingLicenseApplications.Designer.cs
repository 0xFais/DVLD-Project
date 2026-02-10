using System.ComponentModel;

namespace DVLD.Applications.LocalDrivingLicenseApplications
{
    partial class frmAddUpdateLocalDrivingLicenseApplications
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TpPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlPersonCardFilter1 = new DVLD.People.Controls.ctrlPersonCardFilter();
            this.TpApplicationInfo = new System.Windows.Forms.TabPage();
            this.cboxLicenseClass = new System.Windows.Forms.ComboBox();
            this.lblCreatedByUserName = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.lblLDLAppID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.TpPersonInfo.SuspendLayout();
            this.TpApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TpPersonInfo);
            this.tabControl1.Controls.Add(this.TpApplicationInfo);
            this.tabControl1.Location = new System.Drawing.Point(12, 74);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(460, 406);
            this.tabControl1.TabIndex = 0;
            // 
            // TpPersonInfo
            // 
            this.TpPersonInfo.Controls.Add(this.btnNext);
            this.TpPersonInfo.Controls.Add(this.ctrlPersonCardFilter1);
            this.TpPersonInfo.Location = new System.Drawing.Point(4, 22);
            this.TpPersonInfo.Name = "TpPersonInfo";
            this.TpPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TpPersonInfo.Size = new System.Drawing.Size(452, 380);
            this.TpPersonInfo.TabIndex = 0;
            this.TpPersonInfo.Text = "Person Info";
            this.TpPersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(371, 346);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlPersonCardFilter1
            // 
            //this.ctrlPersonCardFilter1._PersonID = 0;
            this.ctrlPersonCardFilter1.Location = new System.Drawing.Point(6, 6);
            this.ctrlPersonCardFilter1.Name = "ctrlPersonCardFilter1";
            this.ctrlPersonCardFilter1.Size = new System.Drawing.Size(443, 334);
            this.ctrlPersonCardFilter1.TabIndex = 0;
            // 
            // TpApplicationInfo
            // 
            this.TpApplicationInfo.Controls.Add(this.cboxLicenseClass);
            this.TpApplicationInfo.Controls.Add(this.lblCreatedByUserName);
            this.TpApplicationInfo.Controls.Add(this.lblAppFees);
            this.TpApplicationInfo.Controls.Add(this.lblAppDate);
            this.TpApplicationInfo.Controls.Add(this.lblLDLAppID);
            this.TpApplicationInfo.Controls.Add(this.label5);
            this.TpApplicationInfo.Controls.Add(this.label4);
            this.TpApplicationInfo.Controls.Add(this.label3);
            this.TpApplicationInfo.Controls.Add(this.label2);
            this.TpApplicationInfo.Controls.Add(this.label1);
            this.TpApplicationInfo.Location = new System.Drawing.Point(4, 22);
            this.TpApplicationInfo.Name = "TpApplicationInfo";
            this.TpApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TpApplicationInfo.Size = new System.Drawing.Size(452, 380);
            this.TpApplicationInfo.TabIndex = 1;
            this.TpApplicationInfo.Text = "Application Info";
            this.TpApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // cboxLicenseClass
            // 
            this.cboxLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxLicenseClass.FormattingEnabled = true;
            this.cboxLicenseClass.Location = new System.Drawing.Point(180, 116);
            this.cboxLicenseClass.Name = "cboxLicenseClass";
            this.cboxLicenseClass.Size = new System.Drawing.Size(230, 21);
            this.cboxLicenseClass.TabIndex = 9;
            this.cboxLicenseClass.SelectedIndexChanged += new System.EventHandler(this.cboxLicenseClass_SelectedIndexChanged);
            // 
            // lblCreatedByUserName
            // 
            this.lblCreatedByUserName.AutoSize = true;
            this.lblCreatedByUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUserName.Location = new System.Drawing.Point(176, 203);
            this.lblCreatedByUserName.Name = "lblCreatedByUserName";
            this.lblCreatedByUserName.Size = new System.Drawing.Size(63, 20);
            this.lblCreatedByUserName.TabIndex = 8;
            this.lblCreatedByUserName.Text = "??????";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFees.Location = new System.Drawing.Point(176, 160);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(63, 20);
            this.lblAppFees.TabIndex = 7;
            this.lblAppFees.Text = "??????";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.Location = new System.Drawing.Point(176, 73);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(63, 20);
            this.lblAppDate.TabIndex = 6;
            this.lblAppDate.Text = "??????";
            // 
            // lblLDLAppID
            // 
            this.lblLDLAppID.AutoSize = true;
            this.lblLDLAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLDLAppID.Location = new System.Drawing.Point(176, 35);
            this.lblLDLAppID.Name = "lblLDLAppID";
            this.lblLDLAppID.Size = new System.Drawing.Size(63, 20);
            this.lblLDLAppID.TabIndex = 5;
            this.lblLDLAppID.Text = "??????";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Created by User : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Application Fees : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "License Class : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Application Date : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "LDLApplication ID :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(395, 482);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(314, 482);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(22, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(239, 26);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "AddUpdateApplications";
            // 
            // frmAddUpdateLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 512);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAddUpdateLocalDrivingLicenseApplications";
            this.Text = "frmAddUpdateLocalDrivingLicenseApplications";
            this.Load += new System.EventHandler(this.frmAddUpdateLocalDrivingLicenseApplications_Load);
            this.tabControl1.ResumeLayout(false);
            this.TpPersonInfo.ResumeLayout(false);
            this.TpApplicationInfo.ResumeLayout(false);
            this.TpApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TpPersonInfo;
        private System.Windows.Forms.TabPage TpApplicationInfo;
        private People.Controls.ctrlPersonCardFilter ctrlPersonCardFilter1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxLicenseClass;
        private System.Windows.Forms.Label lblCreatedByUserName;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label lblLDLAppID;
    }
}