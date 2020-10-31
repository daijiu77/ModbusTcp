using NModbus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ModbusTcp
{
    public partial class Form1 : Form
    {
        byte[] data = null;
        byte[] resourceDatas = null;
        byte[] btData = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x00, 0x00, 0x00, 0x02 };
        string contentTxt = "";

        SocketTCP socketTCP = new SocketTCP();
        ModbusFactory modbusFactory;
        IModbusMaster master;

        Timer timer = new Timer();
        int sleepNum = 3000;

        DataObj dataObj = new DataObj();

        int tagNum = 0;

        public Form1()
        {
            InitializeComponent();
            init();
            init_comb();

            timer.Interval = 3000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Interval = sleepNum * 1000;
            if (1 == tagNum)
            {
                SocketSendData(dataObj.nAddrCode, dataObj.nCmdCode, dataObj.nRegisterAddr, dataObj.nRegisterCount);
            }
            else if (2 == tagNum)
            {
                NModbusSendData(dataObj.slaveAddress, dataObj.startAddress, dataObj.numberOfPoints);
            }
            else
            {
                timer.Interval = 3000;
            }
        }

        void init()
        {
            modbusFactory = new ModbusFactory();
            //socketTCP.IsAsynRecevice = true;
            txtDataPosition.Text = socketTCP.dataStartIndexOfReceive.ToString();

            loadDataFromConfig();

            txtIPAddr.LostFocus += Txt_LostFocus;
            txtPortNum.LostFocus += Txt_LostFocus;
            txtCmd.LostFocus += Txt_LostFocus;
            txtRegisterAddr.LostFocus += Txt_LostFocus;
            txtRegisterCount.LostFocus += Txt_LostFocus;
            txtSlaveAddress.LostFocus += Txt_LostFocus;
            txtStartAddress.LostFocus += Txt_LostFocus;
            txtNumberOfPoints.LostFocus += Txt_LostFocus;
            txtAddressCode.LostFocus += Txt_LostFocus;
            txtDataPosition.LostFocus += Txt_LostFocus;

            bttnTestConnect.Click += BttnTestConnect_Click;
            bttnTranslateHex.Click += BttnTranslateHex_Click;
            bttnSocketSend.Click += BttnSocketSend_Click;
            bttnNModbusSend.Click += BttnNModbusSend_Click;
            bttnClear.Click += BttnClear_Click;

            chkAutoSocket.CheckedChanged += ChkAutoSocket_CheckedChanged;
            chkAutoNModbus.CheckedChanged += ChkAutoNModbus_CheckedChanged;

            cmbSecondSocket.SelectedIndexChanged += CmbSecondSocket_SelectedIndexChanged;
            cmbSecondNModbus.SelectedIndexChanged += CmbSecondNModbus_SelectedIndexChanged;

            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;

            this.Closed += Form1_Closed;

            socketTCP.receive += SocketTCP_receive;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && null != resourceDatas)
            {
                txtMsg.Text = string.Join(" ", resourceDatas);
            }
            else
            {
                txtMsg.Text = contentTxt;
            }
        }

        private void CmbSecondNModbus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(chkAutoNModbus.Tag);
            if (0 != tagNum && n != tagNum) return;
            object obj = cmbSecondNModbus.SelectedItem;
            if (null == obj) return;
            ItemObj itemObj = (ItemObj)obj;
            sleepNum = (int)itemObj.val;
        }

        private void CmbSecondSocket_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(chkAutoSocket.Tag);
            if (0 != tagNum && n != tagNum) return;
            object obj = cmbSecondSocket.SelectedItem;
            if (null == obj) return;
            ItemObj itemObj = (ItemObj)obj;
            sleepNum = (int)itemObj.val;
        }

        private void ChkAutoNModbus_CheckedChanged(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(chkAutoNModbus.Tag);
            if (!chkAutoNModbus.Checked)
            {
                bttnNModbusSend.Enabled = true;                
                if (tagNum == n) tagNum = 0;
            }            
        }

        private void ChkAutoSocket_CheckedChanged(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(chkAutoSocket.Tag);
            if (!chkAutoSocket.Checked)
            {
                bttnSocketSend.Enabled = true;
                if (tagNum == n) tagNum = 0;
            }            
        }

        void init_comb()
        {
            int len = 11;
            cmbSecondSocket.Items.Clear();
            cmbSecondNModbus.Items.Clear();

            for (int i = 1; i < len; i++)
            {
                cmbSecondSocket.Items.Add(new ItemObj(i.ToString(), i));
                cmbSecondNModbus.Items.Add(new ItemObj(i.ToString(), i));
            }
        }

        private void Form1_Closed(object sender, EventArgs e)
        {
            timer.Enabled = false;
            ((IDisposable)socketTCP).Dispose();
        }

        private void BttnClear_Click(object sender, EventArgs e)
        {
            txtMsg.Text = "";
            contentTxt = "";
        }

        private void SocketTCP_receive(int[] datas, byte[] resourceDatas)
        {
            this.resourceDatas = resourceDatas;

            string txt = contentTxt;
            string dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (string.IsNullOrEmpty(txt))
            {
                txt = dt + "\t" + string.Join(" ", datas);
            }
            else
            {
                txt = dt + "\t" + string.Join(" ", datas) + "\r\n" + txt;
            }

            if(checkBox1.Checked && null != resourceDatas)
            {
                txtMsg.Text = string.Join(" ", resourceDatas);
            }
            else
            {
                txtMsg.Text = txt;
            }
            
            contentTxt = txt;
        }

        private void Txt_LostFocus(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string key = textBox.Name;
            string val = textBox.Text;
            setConfig(key, val);
            init_CodeData(key, val);
        }

        private void BttnNModbusSend_Click(object sender, EventArgs e)
        {            
            if (0 != tagNum) return;

            Init_Mast();

            if (null == master) return;

            string slaveAddress1 = txtSlaveAddress.Text.Trim();
            string startAddress1 = txtStartAddress.Text.Trim();
            string numberOfPoints1 = txtNumberOfPoints.Text.Trim();

            byte slaveAddress = 0;
            ushort startAddress = 0;
            ushort numberOfPoints = 0;

            byte.TryParse(slaveAddress1, out slaveAddress);
            ushort.TryParse(startAddress1, out startAddress);
            ushort.TryParse(numberOfPoints1, out numberOfPoints);

            if (chkAutoNModbus.Checked)
            {
                bttnNModbusSend.Enabled = false;
                int n = Convert.ToInt32(chkAutoNModbus.Tag);
                tagNum = n;

                dataObj.slaveAddress = slaveAddress;
                dataObj.startAddress = startAddress;
                dataObj.numberOfPoints = numberOfPoints;
                return;
            }

            NModbusSendData(slaveAddress, startAddress, numberOfPoints);
        }

        private void BttnSocketSend_Click(object sender, EventArgs e)
        {            
            if (0 != tagNum) return;
            string addrCode = txtAddressCode.Text.Trim();
            string cmdCode = txtCmd.Text.Trim();
            string registerAddr = txtRegisterAddr.Text.Trim();
            string registerCount = txtRegisterCount.Text.Trim();
            string dataPos = txtDataPosition.Text.Trim();

            int nAddrCode = 0;
            int nCmdCode = 0;
            int nRegisterAddr = 0;
            int nRegisterCount = 0;
            int nDataPos = 0;

            int.TryParse(addrCode, out nAddrCode);
            int.TryParse(cmdCode, out nCmdCode);
            int.TryParse(registerAddr, out nRegisterAddr);
            int.TryParse(registerCount, out nRegisterCount);
            int.TryParse(dataPos, out nDataPos);

            socketTCP.dataStartIndexOfReceive = nDataPos;

            setConnect();

            if (chkAutoSocket.Checked)
            {
                int n = Convert.ToInt32(chkAutoSocket.Tag);
                tagNum = n;
                bttnSocketSend.Enabled = false;
                
                dataObj.nAddrCode = nAddrCode;
                dataObj.nCmdCode = nCmdCode;
                dataObj.nRegisterAddr = nRegisterAddr;
                dataObj.nRegisterCount = nRegisterCount;
                dataObj.nDataPos = nDataPos;
                return;
            }

            SocketSendData(nAddrCode, nCmdCode, nRegisterAddr, nRegisterCount);
        }

        private void BttnTranslateHex_Click(object sender, EventArgs e)
        {
            string txt = txtDataOfSocket.Text;
            if (string.IsNullOrEmpty(txt)) return;

            if (null == data)
            {
                //setConfig(txtDataOfSocket.Name, txtDataOfSocket.Text);
                char[] arr = txt.ToCharArray();
                byte[] dtArr = null;
                int len = arr.Length;
                data = new byte[len * 2];
                int n = 0;
                int d = 0;
                foreach (var item in arr)
                {
                    d = (int)item;
                    dtArr = socketTCP.DecimalismTo16(d);
                    data[n] = dtArr[0];
                    data[n + 1] = dtArr[1];
                    n += 2;
                }

                txtDataOfSocket.Text = string.Join(" ", data);

                int nlen = data.Length;
                txtDataSize.Text = nlen.ToString();

                dtArr = socketTCP.DecimalismTo16(nlen);
                len = nlen + 2 + btData.Length;
                byte[] nbt = new byte[len];
                Array.Copy(btData, nbt, btData.Length);
                Array.Copy(dtArr, 0, nbt, btData.Length, dtArr.Length);
                n = btData.Length + 2;
                Array.Copy(data, 0, nbt, n, data.Length);
                txtCodeData.Text = string.Join(" ", nbt);
            }
            else
            {
                socketTCP.resultDataCount = data.Length;
                int[] result = socketTCP.GetResult(data, 0);
                int len = result.Length;
                char[] strArr = new char[len];
                char c = ' ';
                for (int i = 0; i < len; i++)
                {
                    c = (char)result[i];
                    strArr[i] = c;
                }
                txtDataOfSocket.Text = string.Join("", strArr);
                txtDataSize.Text = "";
                data = null;
                txtCodeData.Text = string.Join(" ", btData);
            }
        }

        private void BttnTestConnect_Click(object sender, EventArgs e)
        {
            setConnect();

            socketTCP.CloseConnection();
            socketTCP.Connect();
            if (socketTCP.IsConnected)
            {
                MessageBox.Show("连接成功");
            }
            else
            {
                MessageBox.Show("连接失败");
            }
        }

        void init_CodeData(string key, string val)
        {
            //                           0     1    2      3     4     5     6    7     8      9    10    11
            //byte[] dt = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x09, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00 };

            int n = 0;
            byte[] bt = null;
            if (key.Equals("txtAddressCode"))
            {
                int.TryParse(val, out n);
                bt = socketTCP.DecimalismTo16(n);
                btData[6] = bt[1];
            }
            else if (key.Equals("txtCmd"))
            {
                int.TryParse(val, out n);
                bt = socketTCP.DecimalismTo16(n);
                btData[7] = bt[1];
            }
            else if (key.Equals("txtRegisterAddr"))
            {
                int.TryParse(val, out n);
                bt = socketTCP.DecimalismTo16(n);
                btData[8] = bt[0];
                btData[9] = bt[1];
            }
            else if (key.Equals("txtRegisterCount"))
            {
                int.TryParse(val, out n);
                bt = socketTCP.DecimalismTo16(n);
                btData[10] = bt[0];
                btData[11] = bt[1];
            }
            else if (key.Equals("txtDataSize"))
            {
                int.TryParse(val, out n);
                bt = socketTCP.DecimalismTo16(n);
                btData[12] = bt[1];
            }

            txtCodeData.Text = string.Join(" ", btData);
        }

        void SocketSendData(int nAddrCode, int nCmdCode, int nRegisterAddr, int nRegisterCount)
        {
            if (null == data)
            {
                socketTCP.SendData(nAddrCode, nCmdCode, nRegisterAddr, nRegisterCount);
            }
            else
            {
                socketTCP.SendData(nAddrCode, nCmdCode, nRegisterAddr, nRegisterCount, data);
            }
        }

        void NModbusSendData(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            ushort[] registerBuffer = null;
            try
            {
                registerBuffer = master.ReadHoldingRegisters(slaveAddress, startAddress, numberOfPoints);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            if (null != registerBuffer)
            {
                int len = registerBuffer.Length;
                int[] dt = new int[len];
                for (int i = 0; i < len; i++)
                {
                    dt[i] = Convert.ToInt32(registerBuffer[i]);
                }
                SocketTCP_receive(dt, null);
            }
        }

        void Init_Mast()
        {
            if (null == master)
            {
                string ipAddress = txtIPAddr.Text.Trim();
                string txt = txtPortNum.Text.Trim();
                int port = 0;
                int.TryParse(txt, out port);

                try
                {
                    master = modbusFactory.CreateMaster(new TcpClient(ipAddress, port));
                    master.Transport.ReadTimeout = 300;
                    master.Transport.Retries = 300;
                }
                catch (Exception)
                {
                    master = null;
                    //throw;
                }
            }
        }

        void setConnect()
        {
            socketTCP.ipAddress = txtIPAddr.Text.Trim();
            string port = txtPortNum.Text.Trim();
            int n = 0;
            int.TryParse(port, out n);
            socketTCP.port = n;
        }

        List<TextBox> GetTextBox()
        {
            List<TextBox> list = new List<TextBox>();
            Control.ControlCollection cc = this.Controls;
            foreach (Control c in cc)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    list.Add((TextBox)c);
                }
            }

            cc = tabPage1.Controls;
            foreach (Control c in cc)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    list.Add((TextBox)c);
                }
            }

            cc = groupBox2.Controls;
            foreach (Control c in cc)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    list.Add((TextBox)c);
                }
            }
            return list;
        }

        void loadDataFromConfig()
        {
            Dictionary<string, string> dic = GetConfig();
            if (0 == dic.Count) return;

            string key = "";
            string val = "";
            List<TextBox> list = GetTextBox();
            foreach (var item in list)
            {
                key = item.Name;
                val = "";
                dic.TryGetValue(key, out val);
                if (string.IsNullOrEmpty(val)) continue;
                item.Text = val;
                init_CodeData(key, val);
            }
        }

        void setConfig(string key, string val)
        {
            string root = Application.StartupPath;
            string fpath = Path.Combine(root, "config.inf");
            string txt = "";
            if (File.Exists(fpath))
            {
                txt = File.ReadAllText(fpath);
            }

            if (key.Equals("txtIPAddr"))
            {
                key = "txtIPAddr";
            }

            if (string.IsNullOrEmpty(txt))
            {
                txt = key + "\t" + val;
            }
            else
            {
                Dictionary<string, string> dic = GetConfig();
                dic.Remove(key);
                dic.Add(key, val);
                txt = "";
                int n = 0;
                foreach (KeyValuePair<string, string> item in dic)
                {
                    if (0 == n)
                    {
                        txt = item.Key + "\t" + item.Value;
                    }
                    else
                    {
                        txt += "\r\n" + item.Key + "\t" + item.Value;
                    }
                    n++;
                }
            }

            File.WriteAllText(fpath, txt);
        }

        Dictionary<string, string> GetConfig()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string root = Application.StartupPath;
            string fpath = Path.Combine(root, "config.inf");
            if (!File.Exists(fpath)) return dic;
            string txt = File.ReadAllText(fpath);
            if (string.IsNullOrEmpty(txt)) return dic;

            string sp = "\r\n";
            string key = "";
            string val = "";
            if (-1 != txt.IndexOf(sp))
            {
                int nlen = "\r\n".Length;
                string s = "";
                int n = 0;
                while (-1 != txt.IndexOf(sp))
                {
                    n = txt.IndexOf(sp);
                    s = txt.Substring(0, n);
                    key = s.Substring(0, s.IndexOf("\t"));
                    val = s.Substring(s.IndexOf("\t") + "\t".Length);
                    dic.Add(key, val);
                    txt = txt.Substring(n + nlen);
                }
            }

            if (!string.IsNullOrEmpty(txt))
            {
                key = txt.Substring(0, txt.IndexOf("\t"));
                val = txt.Substring(txt.IndexOf("\t") + "\t".Length);
                dic.Add(key, val);
            }

            return dic;
        }
    }
}
