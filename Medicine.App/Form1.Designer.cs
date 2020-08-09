namespace Medicine.App
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.Panel_Logo = new System.Windows.Forms.Panel();
            this.Panel_Exit = new System.Windows.Forms.Panel();
            this.Panel_Title = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Label_Title = new System.Windows.Forms.Label();
            this.Panel_Head = new System.Windows.Forms.Panel();
            this.Panel_MiniSize = new System.Windows.Forms.Panel();
            this.Panel_Content = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Btn_Match = new System.Windows.Forms.Button();
            this.Btn_FileChoose = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Label_FilePath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Grid_Medichines = new System.Windows.Forms.DataGridView();
            this.Panel_Title.SuspendLayout();
            this.Panel_Head.SuspendLayout();
            this.Panel_Content.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Medichines)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_Logo
            // 
            this.Panel_Logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel_Logo.BackgroundImage")));
            this.Panel_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Panel_Logo.Location = new System.Drawing.Point(0, 0);
            this.Panel_Logo.Name = "Panel_Logo";
            this.Panel_Logo.Size = new System.Drawing.Size(60, 60);
            this.Panel_Logo.TabIndex = 0;
            // 
            // Panel_Exit
            // 
            this.Panel_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel_Exit.BackgroundImage")));
            this.Panel_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Panel_Exit.Location = new System.Drawing.Point(964, 0);
            this.Panel_Exit.Name = "Panel_Exit";
            this.Panel_Exit.Size = new System.Drawing.Size(60, 60);
            this.Panel_Exit.TabIndex = 1;
            // 
            // Panel_Title
            // 
            this.Panel_Title.Controls.Add(this.panel1);
            this.Panel_Title.Controls.Add(this.Label_Title);
            this.Panel_Title.Location = new System.Drawing.Point(60, 0);
            this.Panel_Title.Name = "Panel_Title";
            this.Panel_Title.Size = new System.Drawing.Size(200, 60);
            this.Panel_Title.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.panel1.Location = new System.Drawing.Point(5, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 30);
            this.panel1.TabIndex = 3;
            // 
            // Label_Title
            // 
            this.Label_Title.AutoSize = true;
            this.Label_Title.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_Title.ForeColor = System.Drawing.Color.White;
            this.Label_Title.Location = new System.Drawing.Point(10, 18);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(154, 24);
            this.Label_Title.TabIndex = 3;
            this.Label_Title.Text = "药品库存信息整理";
            // 
            // Panel_Head
            // 
            this.Panel_Head.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(59)))), ((int)(((byte)(75)))));
            this.Panel_Head.Controls.Add(this.Panel_MiniSize);
            this.Panel_Head.Controls.Add(this.Panel_Title);
            this.Panel_Head.Controls.Add(this.Panel_Exit);
            this.Panel_Head.Controls.Add(this.Panel_Logo);
            this.Panel_Head.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Head.Location = new System.Drawing.Point(0, 0);
            this.Panel_Head.Name = "Panel_Head";
            this.Panel_Head.Size = new System.Drawing.Size(1024, 60);
            this.Panel_Head.TabIndex = 4;
            // 
            // Panel_MiniSize
            // 
            this.Panel_MiniSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_MiniSize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel_MiniSize.BackgroundImage")));
            this.Panel_MiniSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Panel_MiniSize.Location = new System.Drawing.Point(904, 0);
            this.Panel_MiniSize.Name = "Panel_MiniSize";
            this.Panel_MiniSize.Size = new System.Drawing.Size(60, 60);
            this.Panel_MiniSize.TabIndex = 3;
            // 
            // Panel_Content
            // 
            this.Panel_Content.BackColor = System.Drawing.Color.White;
            this.Panel_Content.Controls.Add(this.panel3);
            this.Panel_Content.Controls.Add(this.panel2);
            this.Panel_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Content.Location = new System.Drawing.Point(0, 60);
            this.Panel_Content.Name = "Panel_Content";
            this.Panel_Content.Padding = new System.Windows.Forms.Padding(10);
            this.Panel_Content.Size = new System.Drawing.Size(1024, 708);
            this.Panel_Content.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.Grid_Medichines);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(10, 110);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1004, 588);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Btn_Match);
            this.panel2.Controls.Add(this.Btn_FileChoose);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1004, 100);
            this.panel2.TabIndex = 0;
            // 
            // Btn_Match
            // 
            this.Btn_Match.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.Btn_Match.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.Btn_Match.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Match.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Btn_Match.ForeColor = System.Drawing.Color.White;
            this.Btn_Match.Location = new System.Drawing.Point(800, 30);
            this.Btn_Match.Name = "Btn_Match";
            this.Btn_Match.Size = new System.Drawing.Size(100, 40);
            this.Btn_Match.TabIndex = 3;
            this.Btn_Match.Text = "匹配货号";
            this.Btn_Match.UseVisualStyleBackColor = false;
            // 
            // Btn_FileChoose
            // 
            this.Btn_FileChoose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.Btn_FileChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_FileChoose.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Btn_FileChoose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.Btn_FileChoose.Location = new System.Drawing.Point(666, 30);
            this.Btn_FileChoose.Name = "Btn_FileChoose";
            this.Btn_FileChoose.Size = new System.Drawing.Size(100, 40);
            this.Btn_FileChoose.TabIndex = 2;
            this.Btn_FileChoose.Text = "选择文件";
            this.Btn_FileChoose.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Label_FilePath);
            this.panel4.Location = new System.Drawing.Point(240, 30);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(400, 40);
            this.panel4.TabIndex = 1;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // Label_FilePath
            // 
            this.Label_FilePath.AutoSize = true;
            this.Label_FilePath.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Label_FilePath.Location = new System.Drawing.Point(10, 8);
            this.Label_FilePath.Name = "Label_FilePath";
            this.Label_FilePath.Size = new System.Drawing.Size(0, 24);
            this.Label_FilePath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(100, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Excel文件地址：";
            // 
            // Grid_Medichines
            // 
            this.Grid_Medichines.AllowUserToAddRows = false;
            this.Grid_Medichines.AllowUserToDeleteRows = false;
            this.Grid_Medichines.AllowUserToResizeRows = false;
            this.Grid_Medichines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Medichines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_Medichines.Location = new System.Drawing.Point(0, 0);
            this.Grid_Medichines.Name = "Grid_Medichines";
            this.Grid_Medichines.ReadOnly = true;
            this.Grid_Medichines.RowTemplate.Height = 23;
            this.Grid_Medichines.Size = new System.Drawing.Size(1004, 588);
            this.Grid_Medichines.TabIndex = 0;
            this.Grid_Medichines.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.Grid_Medichines_RowStateChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.Panel_Content);
            this.Controls.Add(this.Panel_Head);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药品信息整理";
            this.Panel_Title.ResumeLayout(false);
            this.Panel_Title.PerformLayout();
            this.Panel_Head.ResumeLayout(false);
            this.Panel_Content.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Medichines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Logo;
        private System.Windows.Forms.Panel Panel_Exit;
        private System.Windows.Forms.Panel Panel_Title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Label_Title;
        private System.Windows.Forms.Panel Panel_Head;
        private System.Windows.Forms.Panel Panel_Content;
        private System.Windows.Forms.Panel Panel_MiniSize;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Label_FilePath;
        private System.Windows.Forms.Button Btn_FileChoose;
        private System.Windows.Forms.Button Btn_Match;
        private System.Windows.Forms.DataGridView Grid_Medichines;
    }
}

