namespace MemoBusTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_StopThreadRead = new System.Windows.Forms.Button();
            this.cb_ThreadReadOpen = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_IsNotUDWord = new System.Windows.Forms.CheckBox();
            this.cb_IsNotUWord = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_SlaveNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_WriteDWord = new System.Windows.Forms.Button();
            this.btn_ReadDWord = new System.Windows.Forms.Button();
            this.tb_WriteDWordValue = new System.Windows.Forms.TextBox();
            this.tb_WriteDWordAddress = new System.Windows.Forms.TextBox();
            this.tb_ReadDWordLength = new System.Windows.Forms.TextBox();
            this.tb_ReadDWordAddress = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_WriteWord = new System.Windows.Forms.Button();
            this.btn_ReadWord = new System.Windows.Forms.Button();
            this.tb_WriteWordValue = new System.Windows.Forms.TextBox();
            this.tb_WriteWordAddress = new System.Windows.Forms.TextBox();
            this.tb_ReadWordLength = new System.Windows.Forms.TextBox();
            this.tb_ReadWordAddress = new System.Windows.Forms.TextBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_StopThreadRead
            // 
            this.btn_StopThreadRead.Location = new System.Drawing.Point(535, 244);
            this.btn_StopThreadRead.Name = "btn_StopThreadRead";
            this.btn_StopThreadRead.Size = new System.Drawing.Size(93, 23);
            this.btn_StopThreadRead.TabIndex = 74;
            this.btn_StopThreadRead.Text = "停止线程";
            this.btn_StopThreadRead.UseVisualStyleBackColor = true;
            this.btn_StopThreadRead.Click += new System.EventHandler(this.btn_StopThreadRead_Click);
            // 
            // cb_ThreadReadOpen
            // 
            this.cb_ThreadReadOpen.AutoSize = true;
            this.cb_ThreadReadOpen.Location = new System.Drawing.Point(469, 248);
            this.cb_ThreadReadOpen.Name = "cb_ThreadReadOpen";
            this.cb_ThreadReadOpen.Size = new System.Drawing.Size(60, 16);
            this.cb_ThreadReadOpen.TabIndex = 73;
            this.cb_ThreadReadOpen.Text = "线程读";
            this.cb_ThreadReadOpen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_ThreadReadOpen.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(10, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(618, 1);
            this.label7.TabIndex = 72;
            this.label7.Text = "label7";
            // 
            // cb_IsNotUDWord
            // 
            this.cb_IsNotUDWord.AutoSize = true;
            this.cb_IsNotUDWord.Location = new System.Drawing.Point(259, 163);
            this.cb_IsNotUDWord.Name = "cb_IsNotUDWord";
            this.cb_IsNotUDWord.Size = new System.Drawing.Size(60, 16);
            this.cb_IsNotUDWord.TabIndex = 71;
            this.cb_IsNotUDWord.Text = "有符号";
            this.cb_IsNotUDWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_IsNotUDWord.UseVisualStyleBackColor = true;
            // 
            // cb_IsNotUWord
            // 
            this.cb_IsNotUWord.AutoSize = true;
            this.cb_IsNotUWord.Location = new System.Drawing.Point(259, 79);
            this.cb_IsNotUWord.Name = "cb_IsNotUWord";
            this.cb_IsNotUWord.Size = new System.Drawing.Size(60, 16);
            this.cb_IsNotUWord.TabIndex = 70;
            this.cb_IsNotUWord.Text = "有符号";
            this.cb_IsNotUWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_IsNotUWord.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(257, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 69;
            this.label6.Text = "从站号";
            // 
            // tb_SlaveNum
            // 
            this.tb_SlaveNum.Location = new System.Drawing.Point(259, 26);
            this.tb_SlaveNum.Name = "tb_SlaveNum";
            this.tb_SlaveNum.Size = new System.Drawing.Size(100, 21);
            this.tb_SlaveNum.TabIndex = 68;
            this.tb_SlaveNum.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 67;
            this.label5.Text = "端口";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 66;
            this.label4.Text = "IP";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(12, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(618, 1);
            this.label3.TabIndex = 65;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(618, 1);
            this.label2.TabIndex = 64;
            this.label2.Text = "label2";
            // 
            // btn_WriteDWord
            // 
            this.btn_WriteDWord.Location = new System.Drawing.Point(535, 198);
            this.btn_WriteDWord.Name = "btn_WriteDWord";
            this.btn_WriteDWord.Size = new System.Drawing.Size(93, 23);
            this.btn_WriteDWord.TabIndex = 62;
            this.btn_WriteDWord.Text = "写入DWord(32)";
            this.btn_WriteDWord.UseVisualStyleBackColor = true;
            this.btn_WriteDWord.Click += new System.EventHandler(this.btn_WriteDWord_Click);
            // 
            // btn_ReadDWord
            // 
            this.btn_ReadDWord.Location = new System.Drawing.Point(535, 160);
            this.btn_ReadDWord.Name = "btn_ReadDWord";
            this.btn_ReadDWord.Size = new System.Drawing.Size(93, 23);
            this.btn_ReadDWord.TabIndex = 61;
            this.btn_ReadDWord.Text = "读取DWord(32)";
            this.btn_ReadDWord.UseVisualStyleBackColor = true;
            this.btn_ReadDWord.Click += new System.EventHandler(this.btn_ReadDWord_Click);
            // 
            // tb_WriteDWordValue
            // 
            this.tb_WriteDWordValue.Location = new System.Drawing.Point(135, 198);
            this.tb_WriteDWordValue.Name = "tb_WriteDWordValue";
            this.tb_WriteDWordValue.Size = new System.Drawing.Size(312, 21);
            this.tb_WriteDWordValue.TabIndex = 60;
            // 
            // tb_WriteDWordAddress
            // 
            this.tb_WriteDWordAddress.Location = new System.Drawing.Point(12, 198);
            this.tb_WriteDWordAddress.Name = "tb_WriteDWordAddress";
            this.tb_WriteDWordAddress.Size = new System.Drawing.Size(100, 21);
            this.tb_WriteDWordAddress.TabIndex = 59;
            this.tb_WriteDWordAddress.Text = "m100";
            // 
            // tb_ReadDWordLength
            // 
            this.tb_ReadDWordLength.Location = new System.Drawing.Point(135, 160);
            this.tb_ReadDWordLength.Name = "tb_ReadDWordLength";
            this.tb_ReadDWordLength.Size = new System.Drawing.Size(100, 21);
            this.tb_ReadDWordLength.TabIndex = 58;
            // 
            // tb_ReadDWordAddress
            // 
            this.tb_ReadDWordAddress.Location = new System.Drawing.Point(12, 160);
            this.tb_ReadDWordAddress.Name = "tb_ReadDWordAddress";
            this.tb_ReadDWordAddress.Size = new System.Drawing.Size(100, 21);
            this.tb_ReadDWordAddress.TabIndex = 57;
            this.tb_ReadDWordAddress.Text = "m0";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 281);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(616, 328);
            this.listBox1.TabIndex = 56;
            // 
            // btn_WriteWord
            // 
            this.btn_WriteWord.Location = new System.Drawing.Point(535, 114);
            this.btn_WriteWord.Name = "btn_WriteWord";
            this.btn_WriteWord.Size = new System.Drawing.Size(93, 23);
            this.btn_WriteWord.TabIndex = 55;
            this.btn_WriteWord.Text = "写入Word(16)";
            this.btn_WriteWord.UseVisualStyleBackColor = true;
            this.btn_WriteWord.Click += new System.EventHandler(this.btn_WriteWord_Click);
            // 
            // btn_ReadWord
            // 
            this.btn_ReadWord.Location = new System.Drawing.Point(535, 76);
            this.btn_ReadWord.Name = "btn_ReadWord";
            this.btn_ReadWord.Size = new System.Drawing.Size(93, 23);
            this.btn_ReadWord.TabIndex = 53;
            this.btn_ReadWord.Text = "读取Word(16)";
            this.btn_ReadWord.UseVisualStyleBackColor = true;
            this.btn_ReadWord.Click += new System.EventHandler(this.btn_ReadWord_Click);
            // 
            // tb_WriteWordValue
            // 
            this.tb_WriteWordValue.Location = new System.Drawing.Point(135, 114);
            this.tb_WriteWordValue.Name = "tb_WriteWordValue";
            this.tb_WriteWordValue.Size = new System.Drawing.Size(312, 21);
            this.tb_WriteWordValue.TabIndex = 52;
            // 
            // tb_WriteWordAddress
            // 
            this.tb_WriteWordAddress.Location = new System.Drawing.Point(12, 114);
            this.tb_WriteWordAddress.Name = "tb_WriteWordAddress";
            this.tb_WriteWordAddress.Size = new System.Drawing.Size(100, 21);
            this.tb_WriteWordAddress.TabIndex = 51;
            this.tb_WriteWordAddress.Text = "m100";
            // 
            // tb_ReadWordLength
            // 
            this.tb_ReadWordLength.Location = new System.Drawing.Point(135, 76);
            this.tb_ReadWordLength.Name = "tb_ReadWordLength";
            this.tb_ReadWordLength.Size = new System.Drawing.Size(100, 21);
            this.tb_ReadWordLength.TabIndex = 48;
            // 
            // tb_ReadWordAddress
            // 
            this.tb_ReadWordAddress.Location = new System.Drawing.Point(12, 76);
            this.tb_ReadWordAddress.Name = "tb_ReadWordAddress";
            this.tb_ReadWordAddress.Size = new System.Drawing.Size(100, 21);
            this.tb_ReadWordAddress.TabIndex = 47;
            this.tb_ReadWordAddress.Text = "m0";
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(135, 26);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(100, 21);
            this.tb_port.TabIndex = 44;
            this.tb_port.Text = "10002";
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(12, 26);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(100, 21);
            this.tb_ip.TabIndex = 43;
            this.tb_ip.Text = "192.168.1.55";
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(535, 24);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(93, 23);
            this.connect.TabIndex = 41;
            this.connect.Text = "连接";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 608);
            this.Controls.Add(this.btn_StopThreadRead);
            this.Controls.Add(this.cb_ThreadReadOpen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_IsNotUDWord);
            this.Controls.Add(this.cb_IsNotUWord);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_SlaveNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_WriteDWord);
            this.Controls.Add(this.btn_ReadDWord);
            this.Controls.Add(this.tb_WriteDWordValue);
            this.Controls.Add(this.tb_WriteDWordAddress);
            this.Controls.Add(this.tb_ReadDWordLength);
            this.Controls.Add(this.tb_ReadDWordAddress);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_WriteWord);
            this.Controls.Add(this.btn_ReadWord);
            this.Controls.Add(this.tb_WriteWordValue);
            this.Controls.Add(this.tb_WriteWordAddress);
            this.Controls.Add(this.tb_ReadWordLength);
            this.Controls.Add(this.tb_ReadWordAddress);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.tb_ip);
            this.Controls.Add(this.connect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MemobusTool v1.0.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_StopThreadRead;
        private System.Windows.Forms.CheckBox cb_ThreadReadOpen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cb_IsNotUDWord;
        private System.Windows.Forms.CheckBox cb_IsNotUWord;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_SlaveNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_WriteDWord;
        private System.Windows.Forms.Button btn_ReadDWord;
        private System.Windows.Forms.TextBox tb_WriteDWordValue;
        private System.Windows.Forms.TextBox tb_WriteDWordAddress;
        private System.Windows.Forms.TextBox tb_ReadDWordLength;
        private System.Windows.Forms.TextBox tb_ReadDWordAddress;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_WriteWord;
        private System.Windows.Forms.Button btn_ReadWord;
        private System.Windows.Forms.TextBox tb_WriteWordValue;
        private System.Windows.Forms.TextBox tb_WriteWordAddress;
        private System.Windows.Forms.TextBox tb_ReadWordLength;
        private System.Windows.Forms.TextBox tb_ReadWordAddress;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.Button connect;
    }
}

