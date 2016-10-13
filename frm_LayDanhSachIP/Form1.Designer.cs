namespace frm_LayDanhSachIP
{
    partial class Form1
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
            this.lsbIP = new System.Windows.Forms.ListBox();
            this.btnLayDSIP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsbIP
            // 
            this.lsbIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbIP.FormattingEnabled = true;
            this.lsbIP.ItemHeight = 18;
            this.lsbIP.Location = new System.Drawing.Point(39, 12);
            this.lsbIP.Name = "lsbIP";
            this.lsbIP.Size = new System.Drawing.Size(183, 202);
            this.lsbIP.TabIndex = 0;
            // 
            // btnLayDSIP
            // 
            this.btnLayDSIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLayDSIP.Location = new System.Drawing.Point(52, 239);
            this.btnLayDSIP.Name = "btnLayDSIP";
            this.btnLayDSIP.Size = new System.Drawing.Size(153, 31);
            this.btnLayDSIP.TabIndex = 1;
            this.btnLayDSIP.Text = "Lấy danh sách IP";
            this.btnLayDSIP.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 282);
            this.Controls.Add(this.btnLayDSIP);
            this.Controls.Add(this.lsbIP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLayDSIP;
        public System.Windows.Forms.ListBox lsbIP;
    }
}

