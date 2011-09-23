namespace testthemx_winform
{
    partial class frmMain
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
            this.txtDn = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtErrMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDn
            // 
            this.txtDn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDn.Location = new System.Drawing.Point(12, 12);
            this.txtDn.Name = "txtDn";
            this.txtDn.Size = new System.Drawing.Size(295, 20);
            this.txtDn.TabIndex = 0;
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.Location = new System.Drawing.Point(313, 10);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(90, 23);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtErrMessage
            // 
            this.txtErrMessage.AutoSize = true;
            this.txtErrMessage.Location = new System.Drawing.Point(9, 39);
            this.txtErrMessage.Name = "txtErrMessage";
            this.txtErrMessage.Size = new System.Drawing.Size(0, 13);
            this.txtErrMessage.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 62);
            this.Controls.Add(this.txtErrMessage);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtDn);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1000000, 100);
            this.MinimumSize = new System.Drawing.Size(428, 100);
            this.Name = "frmMain";
            this.Text = "MX Checker";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDn;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label txtErrMessage;
    }
}

