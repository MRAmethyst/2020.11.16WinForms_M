namespace _2020._11._16WinForms_M
{
    partial class Standard_Form
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
            this.btnfollow = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnfollow
            // 
            this.btnfollow.Location = new System.Drawing.Point(116, 147);
            this.btnfollow.Name = "btnfollow";
            this.btnfollow.Size = new System.Drawing.Size(75, 23);
            this.btnfollow.TabIndex = 0;
            this.btnfollow.Text = "继承";
            this.btnfollow.UseVisualStyleBackColor = true;
            this.btnfollow.Click += new System.EventHandler(this.btnfollow_Click);
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(106, 81);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(100, 21);
            this.txt1.TabIndex = 1;
            this.txt1.Text = "继承一下";
            // 
            // Standard_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 278);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.btnfollow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Standard_Form";
            this.Text = "Standard_Form";
            this.Load += new System.EventHandler(this.Standard_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnfollow;
        private System.Windows.Forms.TextBox txt1;
    }
}