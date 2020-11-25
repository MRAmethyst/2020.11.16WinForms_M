namespace _2020._11._16WinForms_M
{
    partial class delete_Piont
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
            this.btnyes = new System.Windows.Forms.Button();
            this.chkpoint1 = new System.Windows.Forms.CheckBox();
            this.chkpoint2 = new System.Windows.Forms.CheckBox();
            this.chkpoint3 = new System.Windows.Forms.CheckBox();
            this.chkpoint4 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnyes
            // 
            this.btnyes.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnyes.Location = new System.Drawing.Point(166, 121);
            this.btnyes.Name = "btnyes";
            this.btnyes.Size = new System.Drawing.Size(61, 29);
            this.btnyes.TabIndex = 7;
            this.btnyes.Text = "确定";
            this.btnyes.UseVisualStyleBackColor = true;
            this.btnyes.Click += new System.EventHandler(this.btnyes_Click);
            // 
            // chkpoint1
            // 
            this.chkpoint1.AutoSize = true;
            this.chkpoint1.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkpoint1.Location = new System.Drawing.Point(33, 40);
            this.chkpoint1.Name = "chkpoint1";
            this.chkpoint1.Size = new System.Drawing.Size(33, 18);
            this.chkpoint1.TabIndex = 8;
            this.chkpoint1.Text = "1";
            this.chkpoint1.UseVisualStyleBackColor = true;
            // 
            // chkpoint2
            // 
            this.chkpoint2.AutoSize = true;
            this.chkpoint2.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkpoint2.Location = new System.Drawing.Point(119, 40);
            this.chkpoint2.Name = "chkpoint2";
            this.chkpoint2.Size = new System.Drawing.Size(33, 18);
            this.chkpoint2.TabIndex = 9;
            this.chkpoint2.Text = "2";
            this.chkpoint2.UseVisualStyleBackColor = true;
            // 
            // chkpoint3
            // 
            this.chkpoint3.AutoSize = true;
            this.chkpoint3.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkpoint3.Location = new System.Drawing.Point(33, 83);
            this.chkpoint3.Name = "chkpoint3";
            this.chkpoint3.Size = new System.Drawing.Size(33, 18);
            this.chkpoint3.TabIndex = 10;
            this.chkpoint3.Text = "3";
            this.chkpoint3.UseVisualStyleBackColor = true;
            // 
            // chkpoint4
            // 
            this.chkpoint4.AutoSize = true;
            this.chkpoint4.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkpoint4.Location = new System.Drawing.Point(119, 83);
            this.chkpoint4.Name = "chkpoint4";
            this.chkpoint4.Size = new System.Drawing.Size(33, 18);
            this.chkpoint4.TabIndex = 11;
            this.chkpoint4.Text = "4";
            this.chkpoint4.UseVisualStyleBackColor = true;
            // 
            // delete_Piont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 173);
            this.Controls.Add(this.chkpoint4);
            this.Controls.Add(this.chkpoint3);
            this.Controls.Add(this.chkpoint2);
            this.Controls.Add(this.chkpoint1);
            this.Controls.Add(this.btnyes);
            this.Name = "delete_Piont";
            this.Text = "节点删除";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnyes;
        private System.Windows.Forms.CheckBox chkpoint1;
        private System.Windows.Forms.CheckBox chkpoint2;
        private System.Windows.Forms.CheckBox chkpoint3;
        private System.Windows.Forms.CheckBox chkpoint4;
    }
}