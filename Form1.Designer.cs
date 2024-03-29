﻿namespace MemoBusTool
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
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
            this.tb_LocalCpuNum = new System.Windows.Forms.TextBox();
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
            this.tb_ReadOffset = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_WriteOffset = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_TargetCpuNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_WriteString = new System.Windows.Forms.Button();
            this.btn_ReadString = new System.Windows.Forms.Button();
            this.tb_WriteString = new System.Windows.Forms.TextBox();
            this.tb_WriteStringAddress = new System.Windows.Forms.TextBox();
            this.tb_ReadStringLength = new System.Windows.Forms.TextBox();
            this.tb_ReadStringAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_StopThreadRead
            // 
            this.btn_StopThreadRead.Location = new System.Drawing.Point(535, 327);
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
            this.cb_ThreadReadOpen.Location = new System.Drawing.Point(469, 331);
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
            this.label7.Location = new System.Drawing.Point(10, 314);
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
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 69;
            this.label6.Text = "本CPU号";
            // 
            // tb_LocalCpuNum
            // 
            this.tb_LocalCpuNum.Location = new System.Drawing.Point(259, 26);
            this.tb_LocalCpuNum.Name = "tb_LocalCpuNum";
            this.tb_LocalCpuNum.Size = new System.Drawing.Size(100, 21);
            this.tb_LocalCpuNum.TabIndex = 68;
            this.tb_LocalCpuNum.Text = "1";
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
            this.listBox1.Location = new System.Drawing.Point(12, 357);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(616, 376);
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
            this.tb_port.Text = "10001";
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(12, 26);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(100, 21);
            this.tb_ip.TabIndex = 43;
            this.tb_ip.Text = "192.168.1.1";
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
            // tb_ReadOffset
            // 
            this.tb_ReadOffset.Location = new System.Drawing.Point(98, 328);
            this.tb_ReadOffset.Name = "tb_ReadOffset";
            this.tb_ReadOffset.Size = new System.Drawing.Size(100, 21);
            this.tb_ReadOffset.TabIndex = 75;
            this.tb_ReadOffset.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 76;
            this.label1.Text = "读PLC地址偏移";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(225, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 78;
            this.label8.Text = "读PLC地址偏移";
            // 
            // tb_WriteOffset
            // 
            this.tb_WriteOffset.Location = new System.Drawing.Point(311, 328);
            this.tb_WriteOffset.Name = "tb_WriteOffset";
            this.tb_WriteOffset.Size = new System.Drawing.Size(100, 21);
            this.tb_WriteOffset.TabIndex = 77;
            this.tb_WriteOffset.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(377, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 80;
            this.label9.Text = "目标CPU号";
            // 
            // tb_TargetCpuNum
            // 
            this.tb_TargetCpuNum.Location = new System.Drawing.Point(379, 26);
            this.tb_TargetCpuNum.Name = "tb_TargetCpuNum";
            this.tb_TargetCpuNum.Size = new System.Drawing.Size(100, 21);
            this.tb_TargetCpuNum.TabIndex = 79;
            this.tb_TargetCpuNum.Text = "2";
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(12, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(618, 1);
            this.label10.TabIndex = 87;
            this.label10.Text = "label10";
            // 
            // btn_WriteString
            // 
            this.btn_WriteString.Location = new System.Drawing.Point(535, 281);
            this.btn_WriteString.Name = "btn_WriteString";
            this.btn_WriteString.Size = new System.Drawing.Size(93, 23);
            this.btn_WriteString.TabIndex = 86;
            this.btn_WriteString.Text = "写入字符串";
            this.btn_WriteString.UseVisualStyleBackColor = true;
            this.btn_WriteString.Click += new System.EventHandler(this.btn_WriteString_Click);
            // 
            // btn_ReadString
            // 
            this.btn_ReadString.Location = new System.Drawing.Point(535, 243);
            this.btn_ReadString.Name = "btn_ReadString";
            this.btn_ReadString.Size = new System.Drawing.Size(93, 23);
            this.btn_ReadString.TabIndex = 85;
            this.btn_ReadString.Text = "读取字符串";
            this.btn_ReadString.UseVisualStyleBackColor = true;
            this.btn_ReadString.Click += new System.EventHandler(this.btn_ReadString_Click);
            // 
            // tb_WriteString
            // 
            this.tb_WriteString.Location = new System.Drawing.Point(135, 281);
            this.tb_WriteString.Name = "tb_WriteString";
            this.tb_WriteString.Size = new System.Drawing.Size(312, 21);
            this.tb_WriteString.TabIndex = 84;
            // 
            // tb_WriteStringAddress
            // 
            this.tb_WriteStringAddress.Location = new System.Drawing.Point(12, 281);
            this.tb_WriteStringAddress.Name = "tb_WriteStringAddress";
            this.tb_WriteStringAddress.Size = new System.Drawing.Size(100, 21);
            this.tb_WriteStringAddress.TabIndex = 83;
            this.tb_WriteStringAddress.Text = "m100";
            // 
            // tb_ReadStringLength
            // 
            this.tb_ReadStringLength.Location = new System.Drawing.Point(135, 243);
            this.tb_ReadStringLength.Name = "tb_ReadStringLength";
            this.tb_ReadStringLength.Size = new System.Drawing.Size(100, 21);
            this.tb_ReadStringLength.TabIndex = 82;
            // 
            // tb_ReadStringAddress
            // 
            this.tb_ReadStringAddress.Location = new System.Drawing.Point(12, 243);
            this.tb_ReadStringAddress.Name = "tb_ReadStringAddress";
            this.tb_ReadStringAddress.Size = new System.Drawing.Size(100, 21);
            this.tb_ReadStringAddress.TabIndex = 81;
            this.tb_ReadStringAddress.Text = "m0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 747);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_WriteString);
            this.Controls.Add(this.btn_ReadString);
            this.Controls.Add(this.tb_WriteString);
            this.Controls.Add(this.tb_WriteStringAddress);
            this.Controls.Add(this.tb_ReadStringLength);
            this.Controls.Add(this.tb_ReadStringAddress);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tb_TargetCpuNum);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_WriteOffset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_ReadOffset);
            this.Controls.Add(this.btn_StopThreadRead);
            this.Controls.Add(this.cb_ThreadReadOpen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_IsNotUDWord);
            this.Controls.Add(this.cb_IsNotUWord);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_LocalCpuNum);
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
            this.Text = "MemobusTool v";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_TargetCpuNum;

        #endregion

        private System.Windows.Forms.Button btn_StopThreadRead;
        private System.Windows.Forms.CheckBox cb_ThreadReadOpen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cb_IsNotUDWord;
        private System.Windows.Forms.CheckBox cb_IsNotUWord;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_LocalCpuNum;
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
        private System.Windows.Forms.TextBox tb_ReadOffset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_WriteOffset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_WriteString;
        private System.Windows.Forms.Button btn_ReadString;
        private System.Windows.Forms.TextBox tb_WriteString;
        private System.Windows.Forms.TextBox tb_WriteStringAddress;
        private System.Windows.Forms.TextBox tb_ReadStringLength;
        private System.Windows.Forms.TextBox tb_ReadStringAddress;
    }
}

