namespace Calendario
{
    partial class CambiarCuenta
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
            this.btnOutlook = new System.Windows.Forms.Button();
            this.btnGmail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOutlook
            // 
            this.btnOutlook.Image = global::Calendario.Properties.Resources.Outlook_icon__1_;
            this.btnOutlook.Location = new System.Drawing.Point(148, 12);
            this.btnOutlook.Name = "btnOutlook";
            this.btnOutlook.Size = new System.Drawing.Size(130, 130);
            this.btnOutlook.TabIndex = 1;
            this.btnOutlook.UseVisualStyleBackColor = true;
            this.btnOutlook.Click += new System.EventHandler(this.btnOutlook_Click);
            // 
            // btnGmail
            // 
            this.btnGmail.Image = global::Calendario.Properties.Resources.Web_Gmail_alt_Metro_icon;
            this.btnGmail.Location = new System.Drawing.Point(12, 12);
            this.btnGmail.Name = "btnGmail";
            this.btnGmail.Size = new System.Drawing.Size(130, 130);
            this.btnGmail.TabIndex = 0;
            this.btnGmail.UseVisualStyleBackColor = true;
            this.btnGmail.Click += new System.EventHandler(this.btnGmail_Click);
            // 
            // CambiarCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 157);
            this.Controls.Add(this.btnOutlook);
            this.Controls.Add(this.btnGmail);
            this.Name = "CambiarCuenta";
            this.Text = "Elegir Cuenta";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGmail;
        private System.Windows.Forms.Button btnOutlook;
    }
}