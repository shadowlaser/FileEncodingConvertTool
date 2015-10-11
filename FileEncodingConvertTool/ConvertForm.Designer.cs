namespace FECT
{
    partial class ConvertForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.backup = new System.Windows.Forms.CheckBox();
            this.folderPathLbl = new System.Windows.Forms.Label();
            this.txtDEncode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(444, 30);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(78, 60);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "Go";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(100, 30);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(304, 25);
            this.txtFolder.TabIndex = 3;
            // 
            // backup
            // 
            this.backup.AutoSize = true;
            this.backup.Location = new System.Drawing.Point(327, 67);
            this.backup.Name = "backup";
            this.backup.Size = new System.Drawing.Size(77, 19);
            this.backup.TabIndex = 4;
            this.backup.Text = "backup";
            this.backup.UseVisualStyleBackColor = true;
            // 
            // folderPathLbl
            // 
            this.folderPathLbl.AutoSize = true;
            this.folderPathLbl.Location = new System.Drawing.Point(12, 36);
            this.folderPathLbl.Name = "folderPathLbl";
            this.folderPathLbl.Size = new System.Drawing.Size(82, 15);
            this.folderPathLbl.TabIndex = 5;
            this.folderPathLbl.Text = "文件夹路径";
            // 
            // txtDEncode
            // 
            this.txtDEncode.Location = new System.Drawing.Point(100, 61);
            this.txtDEncode.Name = "txtDEncode";
            this.txtDEncode.Size = new System.Drawing.Size(152, 25);
            this.txtDEncode.TabIndex = 6;
            this.txtDEncode.Text = "utf8";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "目标编码";
            // 
            // ConvertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 101);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDEncode);
            this.Controls.Add(this.folderPathLbl);
            this.Controls.Add(this.backup);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.btnConvert);
            this.Name = "ConvertForm";
            this.Text = "ConvertForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.CheckBox backup;
        private System.Windows.Forms.Label folderPathLbl;
        private System.Windows.Forms.TextBox txtDEncode;
        private System.Windows.Forms.Label label1;
    }
}

