
namespace MyEmail
{
    partial class ReceiveForm
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
            this.backBtn = new System.Windows.Forms.Button();
            this.emailWebBrowser = new System.Windows.Forms.WebBrowser();
            this.infoLabel = new System.Windows.Forms.Label();
            this.emailListBox = new System.Windows.Forms.ListBox();
            this.receiverLb = new System.Windows.Forms.Label();
            this.dateLb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.Transparent;
            this.backBtn.BackgroundImage = global::MyEmail.Properties.Resources.back;
            this.backBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.ForeColor = System.Drawing.Color.White;
            this.backBtn.Location = new System.Drawing.Point(12, 12);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(50, 50);
            this.backBtn.TabIndex = 14;
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // emailWebBrowser
            // 
            this.emailWebBrowser.Location = new System.Drawing.Point(224, 73);
            this.emailWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.emailWebBrowser.Name = "emailWebBrowser";
            this.emailWebBrowser.Size = new System.Drawing.Size(1028, 676);
            this.emailWebBrowser.TabIndex = 17;
            // 
            // infoLabel
            // 
            this.infoLabel.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.infoLabel.ForeColor = System.Drawing.Color.Transparent;
            this.infoLabel.Location = new System.Drawing.Point(376, 15);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(876, 46);
            this.infoLabel.TabIndex = 18;
            this.infoLabel.Text = "消息提示";
            // 
            // emailListBox
            // 
            this.emailListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailListBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.emailListBox.FormattingEnabled = true;
            this.emailListBox.HorizontalScrollbar = true;
            this.emailListBox.ItemHeight = 21;
            this.emailListBox.Location = new System.Drawing.Point(12, 73);
            this.emailListBox.Name = "emailListBox";
            this.emailListBox.Size = new System.Drawing.Size(188, 674);
            this.emailListBox.TabIndex = 20;
            this.emailListBox.SelectedIndexChanged += new System.EventHandler(this.emailListBox_SelectedIndexChanged);
            // 
            // receiverLb
            // 
            this.receiverLb.BackColor = System.Drawing.Color.Transparent;
            this.receiverLb.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.receiverLb.ForeColor = System.Drawing.Color.White;
            this.receiverLb.Location = new System.Drawing.Point(165, 12);
            this.receiverLb.Name = "receiverLb";
            this.receiverLb.Size = new System.Drawing.Size(205, 23);
            this.receiverLb.TabIndex = 21;
            this.receiverLb.Text = "寄件人名称";
            // 
            // dateLb
            // 
            this.dateLb.BackColor = System.Drawing.Color.Transparent;
            this.dateLb.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateLb.ForeColor = System.Drawing.Color.White;
            this.dateLb.Location = new System.Drawing.Point(163, 40);
            this.dateLb.Name = "dateLb";
            this.dateLb.Size = new System.Drawing.Size(207, 21);
            this.dateLb.TabIndex = 22;
            this.dateLb.Text = "发送邮件日期";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(83, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 21);
            this.label3.TabIndex = 23;
            this.label3.Text = "寄件人";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(83, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 21);
            this.label4.TabIndex = 24;
            this.label4.Text = "邮件日期";
            // 
            // ReceiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MyEmail.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateLb);
            this.Controls.Add(this.receiverLb);
            this.Controls.Add(this.emailListBox);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.emailWebBrowser);
            this.Controls.Add(this.backBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReceiveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceiveForm_FormClosing);
            this.Load += new System.EventHandler(this.ReceiveForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.WebBrowser emailWebBrowser;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.ListBox emailListBox;
        private System.Windows.Forms.Label receiverLb;
        private System.Windows.Forms.Label dateLb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}