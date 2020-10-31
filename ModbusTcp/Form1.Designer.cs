namespace ModbusTcp
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAutoSocket = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbSecondSocket = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDataPosition = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAddressCode = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bttnSocketSend = new System.Windows.Forms.Button();
            this.bttnTranslateHex = new System.Windows.Forms.Button();
            this.txtDataOfSocket = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDataSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRegisterCount = new System.Windows.Forms.TextBox();
            this.txtRegisterAddr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCmd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbSecondNModbus = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.chkAutoNModbus = new System.Windows.Forms.CheckBox();
            this.txtNumberOfPoints = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtStartAddress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSlaveAddress = new System.Windows.Forms.TextBox();
            this.bttnNModbusSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIPAddr = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPortNum = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.bttnTestConnect = new System.Windows.Forms.Button();
            this.bttnClear = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtCodeData = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.bttnSocketSend);
            this.groupBox1.Location = new System.Drawing.Point(15, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 310);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "采用 Socket";
            // 
            // chkAutoSocket
            // 
            this.chkAutoSocket.AutoSize = true;
            this.chkAutoSocket.Location = new System.Drawing.Point(16, 179);
            this.chkAutoSocket.Name = "chkAutoSocket";
            this.chkAutoSocket.Size = new System.Drawing.Size(48, 16);
            this.chkAutoSocket.TabIndex = 20;
            this.chkAutoSocket.Tag = "1";
            this.chkAutoSocket.Text = "自动";
            this.chkAutoSocket.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(172, 180);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 19;
            this.label17.Text = "秒";
            // 
            // cmbSecondSocket
            // 
            this.cmbSecondSocket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSecondSocket.FormattingEnabled = true;
            this.cmbSecondSocket.Location = new System.Drawing.Point(105, 177);
            this.cmbSecondSocket.Name = "cmbSecondSocket";
            this.cmbSecondSocket.Size = new System.Drawing.Size(61, 20);
            this.cmbSecondSocket.TabIndex = 18;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(70, 180);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 17;
            this.label16.Text = "频率";
            // 
            // txtDataPosition
            // 
            this.txtDataPosition.Location = new System.Drawing.Point(269, 74);
            this.txtDataPosition.Name = "txtDataPosition";
            this.txtDataPosition.Size = new System.Drawing.Size(100, 21);
            this.txtDataPosition.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(198, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 15;
            this.label15.Text = "数据位置";
            // 
            // txtAddressCode
            // 
            this.txtAddressCode.Location = new System.Drawing.Point(85, 16);
            this.txtAddressCode.Name = "txtAddressCode";
            this.txtAddressCode.Size = new System.Drawing.Size(100, 21);
            this.txtAddressCode.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 14;
            this.label14.Text = "地址码";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(12, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "(非16进制)";
            // 
            // bttnSocketSend
            // 
            this.bttnSocketSend.Location = new System.Drawing.Point(287, 260);
            this.bttnSocketSend.Name = "bttnSocketSend";
            this.bttnSocketSend.Size = new System.Drawing.Size(113, 39);
            this.bttnSocketSend.TabIndex = 10;
            this.bttnSocketSend.Text = "发送";
            this.bttnSocketSend.UseVisualStyleBackColor = true;
            // 
            // bttnTranslateHex
            // 
            this.bttnTranslateHex.Location = new System.Drawing.Point(340, 105);
            this.bttnTranslateHex.Name = "bttnTranslateHex";
            this.bttnTranslateHex.Size = new System.Drawing.Size(26, 61);
            this.bttnTranslateHex.TabIndex = 9;
            this.bttnTranslateHex.Text = "OK";
            this.bttnTranslateHex.UseVisualStyleBackColor = true;
            // 
            // txtDataOfSocket
            // 
            this.txtDataOfSocket.Location = new System.Drawing.Point(83, 105);
            this.txtDataOfSocket.Multiline = true;
            this.txtDataOfSocket.Name = "txtDataOfSocket";
            this.txtDataOfSocket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDataOfSocket.Size = new System.Drawing.Size(251, 61);
            this.txtDataOfSocket.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "数据(写入)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "byte";
            // 
            // txtDataSize
            // 
            this.txtDataSize.Enabled = false;
            this.txtDataSize.Location = new System.Drawing.Point(85, 74);
            this.txtDataSize.Name = "txtDataSize";
            this.txtDataSize.Size = new System.Drawing.Size(65, 21);
            this.txtDataSize.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "数据长度";
            // 
            // txtRegisterCount
            // 
            this.txtRegisterCount.Location = new System.Drawing.Point(269, 45);
            this.txtRegisterCount.Name = "txtRegisterCount";
            this.txtRegisterCount.Size = new System.Drawing.Size(100, 21);
            this.txtRegisterCount.TabIndex = 7;
            // 
            // txtRegisterAddr
            // 
            this.txtRegisterAddr.Location = new System.Drawing.Point(85, 45);
            this.txtRegisterAddr.Name = "txtRegisterAddr";
            this.txtRegisterAddr.Size = new System.Drawing.Size(100, 21);
            this.txtRegisterAddr.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "寄存器数量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "寄存器地址";
            // 
            // txtCmd
            // 
            this.txtCmd.Location = new System.Drawing.Point(269, 16);
            this.txtCmd.Name = "txtCmd";
            this.txtCmd.Size = new System.Drawing.Size(100, 21);
            this.txtCmd.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "功能码";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.cmbSecondNModbus);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.chkAutoNModbus);
            this.groupBox2.Controls.Add(this.txtNumberOfPoints);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtStartAddress);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtSlaveAddress);
            this.groupBox2.Controls.Add(this.bttnNModbusSend);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(441, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 310);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "采用 NModbus 组件";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(180, 282);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 12);
            this.label19.TabIndex = 21;
            this.label19.Text = "秒";
            // 
            // cmbSecondNModbus
            // 
            this.cmbSecondNModbus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSecondNModbus.FormattingEnabled = true;
            this.cmbSecondNModbus.Location = new System.Drawing.Point(113, 277);
            this.cmbSecondNModbus.Name = "cmbSecondNModbus";
            this.cmbSecondNModbus.Size = new System.Drawing.Size(61, 20);
            this.cmbSecondNModbus.TabIndex = 20;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(79, 280);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 19;
            this.label18.Text = "频率";
            // 
            // chkAutoNModbus
            // 
            this.chkAutoNModbus.AutoSize = true;
            this.chkAutoNModbus.Location = new System.Drawing.Point(25, 279);
            this.chkAutoNModbus.Name = "chkAutoNModbus";
            this.chkAutoNModbus.Size = new System.Drawing.Size(48, 16);
            this.chkAutoNModbus.TabIndex = 18;
            this.chkAutoNModbus.Tag = "2";
            this.chkAutoNModbus.Text = "自动";
            this.chkAutoNModbus.UseVisualStyleBackColor = true;
            // 
            // txtNumberOfPoints
            // 
            this.txtNumberOfPoints.Location = new System.Drawing.Point(88, 78);
            this.txtNumberOfPoints.Name = "txtNumberOfPoints";
            this.txtNumberOfPoints.Size = new System.Drawing.Size(100, 21);
            this.txtNumberOfPoints.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 17;
            this.label13.Text = "寄存器数量";
            // 
            // txtStartAddress
            // 
            this.txtStartAddress.Location = new System.Drawing.Point(277, 42);
            this.txtStartAddress.Name = "txtStartAddress";
            this.txtStartAddress.Size = new System.Drawing.Size(100, 21);
            this.txtStartAddress.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(218, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "起始地址";
            // 
            // txtSlaveAddress
            // 
            this.txtSlaveAddress.Location = new System.Drawing.Point(88, 42);
            this.txtSlaveAddress.Name = "txtSlaveAddress";
            this.txtSlaveAddress.Size = new System.Drawing.Size(100, 21);
            this.txtSlaveAddress.TabIndex = 11;
            // 
            // bttnNModbusSend
            // 
            this.bttnNModbusSend.Location = new System.Drawing.Point(277, 260);
            this.bttnNModbusSend.Name = "bttnNModbusSend";
            this.bttnNModbusSend.Size = new System.Drawing.Size(113, 39);
            this.bttnNModbusSend.TabIndex = 14;
            this.bttnNModbusSend.Text = "发送";
            this.bttnNModbusSend.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "站号";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "IP Address";
            // 
            // txtIPAddr
            // 
            this.txtIPAddr.Location = new System.Drawing.Point(92, 25);
            this.txtIPAddr.Name = "txtIPAddr";
            this.txtIPAddr.Size = new System.Drawing.Size(179, 21);
            this.txtIPAddr.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(307, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "Port Number";
            // 
            // txtPortNum
            // 
            this.txtPortNum.Location = new System.Drawing.Point(382, 25);
            this.txtPortNum.Name = "txtPortNum";
            this.txtPortNum.Size = new System.Drawing.Size(100, 21);
            this.txtPortNum.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 390);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 6;
            this.label12.Text = "接收数据";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(15, 414);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMsg.Size = new System.Drawing.Size(825, 133);
            this.txtMsg.TabIndex = 15;
            // 
            // bttnTestConnect
            // 
            this.bttnTestConnect.Location = new System.Drawing.Point(524, 25);
            this.bttnTestConnect.Name = "bttnTestConnect";
            this.bttnTestConnect.Size = new System.Drawing.Size(75, 23);
            this.bttnTestConnect.TabIndex = 3;
            this.bttnTestConnect.Text = "测试连接";
            this.bttnTestConnect.UseVisualStyleBackColor = true;
            // 
            // bttnClear
            // 
            this.bttnClear.Location = new System.Drawing.Point(225, 385);
            this.bttnClear.Name = "bttnClear";
            this.bttnClear.Size = new System.Drawing.Size(75, 23);
            this.bttnClear.TabIndex = 16;
            this.bttnClear.Text = "Clear";
            this.bttnClear.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 20);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(393, 234);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkAutoSocket);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cmbSecondSocket);
            this.tabPage1.Controls.Add(this.txtCmd);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtDataPosition);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.txtRegisterAddr);
            this.tabPage1.Controls.Add(this.txtAddressCode);
            this.tabPage1.Controls.Add(this.txtRegisterCount);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtDataSize);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.bttnTranslateHex);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtDataOfSocket);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(385, 208);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "参数项";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtCodeData);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(385, 208);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "源码";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtCodeData
            // 
            this.txtCodeData.Location = new System.Drawing.Point(15, 16);
            this.txtCodeData.Multiline = true;
            this.txtCodeData.Name = "txtCodeData";
            this.txtCodeData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCodeData.Size = new System.Drawing.Size(352, 173);
            this.txtCodeData.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(72, 390);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "原数据";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 559);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.bttnClear);
            this.Controls.Add(this.bttnTestConnect);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPortNum);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtIPAddr);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modbus-TCP";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRegisterCount;
        private System.Windows.Forms.TextBox txtRegisterAddr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCmd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDataOfSocket;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDataSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bttnSocketSend;
        private System.Windows.Forms.Button bttnTranslateHex;
        private System.Windows.Forms.Button bttnNModbusSend;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIPAddr;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPortNum;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button bttnTestConnect;
        private System.Windows.Forms.TextBox txtNumberOfPoints;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtStartAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSlaveAddress;
        private System.Windows.Forms.TextBox txtAddressCode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button bttnClear;
        private System.Windows.Forms.TextBox txtDataPosition;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkAutoSocket;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbSecondSocket;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbSecondNModbus;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox chkAutoNModbus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtCodeData;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

