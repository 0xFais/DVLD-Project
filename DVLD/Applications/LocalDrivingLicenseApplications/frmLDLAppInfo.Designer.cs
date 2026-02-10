namespace DVLD.Applications.LocalDrivingLicenseApplications
{
    partial class frmLDLAppInfo
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
            this.ctlrLDLAppInfo1 = new DVLD.Applications.LocalDrivingLicenseApplications.Controls.ctrlLDLAppInfo();
            this.SuspendLayout();
            // 
            // ctlrLDLAppInfo1
            // 
            this.ctlrLDLAppInfo1.Location = new System.Drawing.Point(10, 12);
            this.ctlrLDLAppInfo1.Name = "ctlrLDLAppInfo1";
            this.ctlrLDLAppInfo1.Size = new System.Drawing.Size(404, 267);
            this.ctlrLDLAppInfo1.TabIndex = 0;
            // 
            // frmLDLAppInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 288);
            this.Controls.Add(this.ctlrLDLAppInfo1);
            this.Name = "frmLDLAppInfo";
            this.Text = "Local Driving License Application Info";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlLDLAppInfo ctlrLDLAppInfo1;
    }
}