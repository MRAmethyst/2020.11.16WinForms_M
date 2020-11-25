namespace _2020._11._16WinForms_M
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnMATLAB = new System.Windows.Forms.Button();
            this.btnPicture = new System.Windows.Forms.Button();
            this.chartEBus = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvElc_P = new System.Windows.Forms.DataGridView();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btndelete_Point = new System.Windows.Forms.Button();
            this.labstate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartEBus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElc_P)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMATLAB
            // 
            this.btnMATLAB.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMATLAB.Location = new System.Drawing.Point(44, 279);
            this.btnMATLAB.Name = "btnMATLAB";
            this.btnMATLAB.Size = new System.Drawing.Size(81, 42);
            this.btnMATLAB.TabIndex = 0;
            this.btnMATLAB.Text = "调用M";
            this.btnMATLAB.UseVisualStyleBackColor = true;
            this.btnMATLAB.Click += new System.EventHandler(this.btnMATLAB_Click);
            // 
            // btnPicture
            // 
            this.btnPicture.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPicture.Location = new System.Drawing.Point(373, 279);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(81, 42);
            this.btnPicture.TabIndex = 1;
            this.btnPicture.Text = "绘图";
            this.btnPicture.UseVisualStyleBackColor = true;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // chartEBus
            // 
            chartArea2.Name = "ChartArea1";
            this.chartEBus.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartEBus.Legends.Add(legend2);
            this.chartEBus.Location = new System.Drawing.Point(359, 12);
            this.chartEBus.Name = "chartEBus";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "电压";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "相角";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "有功注入";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "无功注入";
            this.chartEBus.Series.Add(series5);
            this.chartEBus.Series.Add(series6);
            this.chartEBus.Series.Add(series7);
            this.chartEBus.Series.Add(series8);
            this.chartEBus.Size = new System.Drawing.Size(312, 239);
            this.chartEBus.TabIndex = 2;
            this.chartEBus.Text = "母线";
            // 
            // dgvElc_P
            // 
            this.dgvElc_P.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dgvElc_P.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElc_P.Location = new System.Drawing.Point(23, 12);
            this.dgvElc_P.Name = "dgvElc_P";
            this.dgvElc_P.RowTemplate.Height = 23;
            this.dgvElc_P.Size = new System.Drawing.Size(320, 239);
            this.dgvElc_P.TabIndex = 3;
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShow.Location = new System.Drawing.Point(151, 279);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(81, 42);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "显示";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(262, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 42);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btndelete_Point
            // 
            this.btndelete_Point.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btndelete_Point.Location = new System.Drawing.Point(488, 279);
            this.btndelete_Point.Name = "btndelete_Point";
            this.btndelete_Point.Size = new System.Drawing.Size(81, 42);
            this.btndelete_Point.TabIndex = 6;
            this.btndelete_Point.Text = "删除";
            this.btndelete_Point.UseVisualStyleBackColor = true;
            this.btndelete_Point.Click += new System.EventHandler(this.btndelete_Point_Click);
            // 
            // labstate
            // 
            this.labstate.AutoSize = true;
            this.labstate.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labstate.Location = new System.Drawing.Point(694, 320);
            this.labstate.Name = "labstate";
            this.labstate.Size = new System.Drawing.Size(52, 23);
            this.labstate.TabIndex = 7;
            this.labstate.Text = "就绪";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 352);
            this.Controls.Add(this.labstate);
            this.Controls.Add(this.btndelete_Point);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dgvElc_P);
            this.Controls.Add(this.chartEBus);
            this.Controls.Add(this.btnPicture);
            this.Controls.Add(this.btnMATLAB);
            this.Name = "Form1";
            this.Text = "调用MATLAB";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartEBus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElc_P)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMATLAB;
        private System.Windows.Forms.Button btnPicture;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEBus;
        private System.Windows.Forms.DataGridView dgvElc_P;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btndelete_Point;
        private System.Windows.Forms.Label labstate;
    }
}

