namespace PSDPlugin.Forms
{
    partial class WriteBase
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbPsds = new System.Windows.Forms.ComboBox();
            this.btnBrowseAndroid = new System.Windows.Forms.Button();
            this.txtAndroidBasePath = new System.Windows.Forms.TextBox();
            this.lblAndroidPath = new System.Windows.Forms.Label();
            this.lblPSD = new System.Windows.Forms.Label();
            this.btnWriteAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(376, 89);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // cmbPsds
            // 
            this.cmbPsds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPsds.Enabled = false;
            this.cmbPsds.FormattingEnabled = true;
            this.cmbPsds.Location = new System.Drawing.Point(7, 91);
            this.cmbPsds.Name = "cmbPsds";
            this.cmbPsds.Size = new System.Drawing.Size(363, 21);
            this.cmbPsds.TabIndex = 30;
            // 
            // btnBrowseAndroid
            // 
            this.btnBrowseAndroid.Location = new System.Drawing.Point(376, 34);
            this.btnBrowseAndroid.Name = "btnBrowseAndroid";
            this.btnBrowseAndroid.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseAndroid.TabIndex = 32;
            this.btnBrowseAndroid.Text = "Browse..";
            this.btnBrowseAndroid.UseVisualStyleBackColor = true;
            // 
            // txtAndroidBasePath
            // 
            this.txtAndroidBasePath.Location = new System.Drawing.Point(7, 36);
            this.txtAndroidBasePath.Name = "txtAndroidBasePath";
            this.txtAndroidBasePath.Size = new System.Drawing.Size(363, 20);
            this.txtAndroidBasePath.TabIndex = 33;
            // 
            // lblAndroidPath
            // 
            this.lblAndroidPath.AutoSize = true;
            this.lblAndroidPath.Location = new System.Drawing.Point(4, 20);
            this.lblAndroidPath.Name = "lblAndroidPath";
            this.lblAndroidPath.Size = new System.Drawing.Size(125, 13);
            this.lblAndroidPath.TabIndex = 34;
            this.lblAndroidPath.Text = "Path to Android base file:";
            // 
            // lblPSD
            // 
            this.lblPSD.AutoSize = true;
            this.lblPSD.Location = new System.Drawing.Point(4, 75);
            this.lblPSD.Name = "lblPSD";
            this.lblPSD.Size = new System.Drawing.Size(65, 13);
            this.lblPSD.TabIndex = 35;
            this.lblPSD.Text = "Select PSD:";
            // 
            // btnWriteAll
            // 
            this.btnWriteAll.Location = new System.Drawing.Point(305, 173);
            this.btnWriteAll.Name = "btnWriteAll";
            this.btnWriteAll.Size = new System.Drawing.Size(146, 23);
            this.btnWriteAll.TabIndex = 36;
            this.btnWriteAll.Text = "Write all";
            this.btnWriteAll.UseVisualStyleBackColor = true;
            // 
            // WriteBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 208);
            this.Controls.Add(this.btnWriteAll);
            this.Controls.Add(this.lblPSD);
            this.Controls.Add(this.lblAndroidPath);
            this.Controls.Add(this.txtAndroidBasePath);
            this.Controls.Add(this.btnBrowseAndroid);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbPsds);
            this.Name = "WriteBase";
            this.Text = "WriteBase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbPsds;
        private System.Windows.Forms.Button btnBrowseAndroid;
        private System.Windows.Forms.TextBox txtAndroidBasePath;
        private System.Windows.Forms.Label lblAndroidPath;
        private System.Windows.Forms.Label lblPSD;
        private System.Windows.Forms.Button btnWriteAll;
    }
}