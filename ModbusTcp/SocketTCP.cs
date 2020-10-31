using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ModbusTcp
{
    public delegate void Receive(int[] data, byte[] resourceDatas);

    class SocketTCP: IDisposable
    {
        private Socket newclient;
        private bool isConnected = false;
        private Thread thread = null;
        private bool isRun = false;
        private int onceNum = 0;
        private bool isRecevice = false;
        private SynchronizationContext m_SyncContext = null;
        private byte[] plusData = null;
        private bool isBus = false;

        public event Receive receive = null;

        public void Connect()
        {
            if (isConnected) return;

            if (null != newclient)
            {
                newclient.Dispose();
            }

            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            newclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            newclient.SendTimeout = 3000;
            newclient.ReceiveTimeout = 3000;
            isConnected = false;

            try
            {
                newclient.Connect(ie);
                isConnected = true;
            }
            catch (Exception)
            {

                //throw;
            }

            if (isConnected && null == thread)
            {
                m_SyncContext = SynchronizationContext.Current;
                thread = new Thread(run);
                thread.Start();
            }
        }

        void run()
        {
            isRun = true;
            byte[] data = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00 };
            byte[] dtResult = new byte[1024];
            onceNum = 0;
            while (isRun)
            {
                Thread.Sleep(100);
                if (isConnected)
                {
                    if (isRecevice)
                    {
                        isRecevice = false;
                        byte[] dt = new byte[1024];
                        newclient.Receive(dt);

                        int[] result = GetResult(dt, dataStartIndexOfReceive);
                        m_SyncContext.Post(SendOrPostCallback, new object[] { result, dt });
                    }

                    if (30 == onceNum)
                    {
                        onceNum = 0;
                        plusData = null == plusData ? data : plusData;
                        try
                        {
                            isBus = true;
                            newclient.Send(plusData);
                            newclient.Receive(dtResult);
                            isBus = false;
                        }
                        catch (Exception)
                        {

                            //throw;
                        }
                    }
                    onceNum++;
                }
            }
        }

        void SendOrPostCallback(object state)
        {
            object[] arr = (object[])state;
            int[] data = (int[])arr[0];
            byte[] resourceDatas = (byte[])arr[1];
            receive(data, resourceDatas);
        }

        public void SendData(byte[] data)
        {
            if (false == isConnected)
            {
                Connect();
            }

            if (!isConnected) return;

            while (isBus)
            {
                Thread.Sleep(100);
            }

            plusData = data;

            //data = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x01, 0x05, 0x00, 0x00, 0xFF, 0x00 };
            onceNum = 0;
            resultDataCount = data[5];
            newclient.Send(data);

            if (null == receive) return;

            isRecevice = IsAsynRecevice;    
            if(false == IsAsynRecevice)
            {
                byte[] dt = new byte[1024];
                newclient.Receive(dt);

                int[] result = GetResult(dt, dataStartIndexOfReceive);
                receive(result, dt);
            }
        }

        /// <summary>
        /// 向硬件发送数据
        /// </summary>
        /// <param name="addressCode">地址码</param>
        /// <param name="commandCode">功能码：1 读线圈状态, 2 读离散输入状态, 3 读保持寄存器, 4 读输入寄存器, 5 写线圈状态, 6 写单个保持寄存器, 10 写多个保持寄存器, 16 写多个线圈</param>
        /// <param name="registerAddress">寄存器地址</param>
        /// <param name="registerCount">寄存器数量</param>
        public void SendData(int addressCode, int commandCode, int registerAddress, int registerCount)
        {
            //0x03 = 功能码(寄存器地址), 0x02 0x58 = 600的十六进制(寄存器起始地址), 0x00 0x02 = 两个寄存器地址
            //                         0     1    2      3     4     5     6    7     8      9    10    11          
            byte[] dt = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x9E, 0x98, 0x00, 0x02 };

            byte[] arr = DecimalismTo16(addressCode);
            dt[6] = arr[1];

            arr = DecimalismTo16(commandCode);
            dt[7] = arr[1];

            arr = DecimalismTo16(registerAddress);
            dt[8] = arr[0];
            dt[9] = arr[1];

            arr = DecimalismTo16(registerCount);
            dt[10] = arr[0];
            dt[11] = arr[1];

            SendData(dt);
        }

        /// <summary>
        /// 向硬件发送数据
        /// </summary>
        /// <param name="addressCode">地址码</param>
        /// <param name="commandCode">功能码：1 读线圈状态, 2 读离散输入状态, 3 读保持寄存器, 4 读输入寄存器, 5 写线圈状态, 6 写单个保持寄存器, 10 写多个保持寄存器, 16 写多个线圈</param>
        /// <param name="registerAddress">寄存器地址</param>
        /// <param name="registerCount">寄存器数量</param>
        /// <param name="data">要写入的数据</param>
        public void SendData(int addressCode, int commandCode, int registerAddress, int registerCount, byte[] data)
        {
            //                         0     1    2      3     4     5     6    7     8      9    10    11    12    13
            byte[] dt = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x09, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            byte[] arr = DecimalismTo16(addressCode);
            dt[6] = arr[1];

            arr = DecimalismTo16(commandCode);
            dt[7] = arr[1];

            arr = DecimalismTo16(registerAddress);
            dt[8] = arr[0];
            dt[9] = arr[1];

            arr = DecimalismTo16(registerCount);
            dt[10] = arr[0];
            dt[11] = arr[1];

            int len = data.Length;
            arr = DecimalismTo16(len);
            dt[12] = arr[0];
            dt[13] = arr[1];

            len += dt.Length;
            arr = new byte[len];

            Array.Copy(dt, arr, dt.Length);
            Array.Copy(data, 0, arr, dt.Length, data.Length);
            SendData(arr);
        }

        public byte[] DecimalismTo16(int decNum)
        {
            byte[] n16 = new byte[2];
            string s = Convert.ToString(decNum, 16);

            string[] arr = null;
            int len = s.Length;
            if (2 < len)
            {
                arr = new string[2];
                arr[1] = s.Substring(0, len - 2);
                arr[0] = s.Substring(len - 2);
            }
            else
            {
                arr = new string[] { s };
            }

            len = arr.Length;
            int num = 0;
            int n = 1;

            for (int i = 0; i < len; i++)
            {
                num = Convert.ToInt32(arr[i], 16);
                n16[n] = (byte)num;
                n--;
            }
            return n16;
        }

        public int[] GetResult(byte[] data, int startIndex)
        {
            int[] result = null;
            if (null == data) return result;
            if (startIndex > data.Length) return result;

            List<int> list = new List<int>();
            int n = 0;
            int x = 0;
            int len = data.Length;
            for (int i = startIndex; i < len; i += 2)
            {
                if ((i + 1) >= len) break;
                //if (0 == data[i] && 0 == data[i + 1]) break;
                n = GetInt32ByByte(data[i], data[i + 1]);
                list.Add(n);
                x += 1;
                if (x >= resultDataCount) break;                
            }
            result = list.ToArray();
            return result;
        }

        public void CloseConnection()
        {
            isConnected = false;
            if (null == newclient) return;
            newclient.Close();
            newclient.Dispose();
            newclient = null;
        }

        public string ipAddress { get; set; }

        public int resultDataCount { get; set; }

        public int port { get; set; }

        /// <summary>
        /// 接收到的数据开始取值位置(默认从第9字节开始获取数据)
        /// </summary>
        public int dataStartIndexOfReceive { get; set; } = 9;

        public bool IsConnected
        {
            get { return isConnected; }
        }

        /// <summary>
        /// 是否异步获取返回的数据
        /// </summary>
        public bool IsAsynRecevice { get; set; } = false;


        int GetInt32ByByte(byte a, byte b)
        {
            int n1 = a * 256; //Convert.ToInt32(a.ToString(), 16) * 256;
            int n2 = b; // Convert.ToInt32(b.ToString(), 16);
            return n1 + n2;
        }

        void IDisposable.Dispose()
        {
            isRun = false;
        }
    }
}
