using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemoBusTool
{
    public class MemobusTool
    {
        private Socket socket;//用于通信的套接字
        private IPAddress ipAddress;//服务器的IP地址
        private int port;//服务器的端口
        private byte localCpuNum;
        private byte targetCpuNum;

        private IPEndPoint ipEndPoint;//服务器的通信节点
        private Thread readThread;//接受响应线程
        private Ping ping;//测试网络连接状态
        private int overTime = 5000;//ping的超时时间
        private byte[] recData;//接收到的数据包

        public static byte ComSessionNum = 0;//生成用公共会话编号

        #region 构造方法及GetSet

        public IPAddress IpAddress
        {
            get => ipAddress;
            set => ipAddress = value;
        }
        public int Port
        {
            get => port;
            set => port = value;
        }
        public int OverTime
        {
            get => overTime;
            set => overTime = value;
        }
        public byte LocalCpuNum
        {
            get => localCpuNum;
            set => localCpuNum = value;
        }
        
        public byte TargetCpuNum
        {
            get => targetCpuNum;
            set => targetCpuNum = value;
        }

        /// <summary>
        /// 创建一个汇川ModbusTCP通信对象
        /// </summary>
        /// <param name="iPAddress">服务器IP</param>
        /// <param name="port">服务器端口</param>
        public MemobusTool(string iPAddress, int port, byte localCpuNum, byte targetCpuNum)
        {
            this.ipAddress = IPAddress.Parse(iPAddress);
            this.port = port;
            this.ipEndPoint = new IPEndPoint(ipAddress, port);
            this.ping = new Ping();
            this.localCpuNum = localCpuNum;
            this.targetCpuNum = targetCpuNum;
        }

        /*public InovanceModbusTCPTool()
        {
        }*/

        #endregion

        #region 测试连接、开启连接、关闭连接

        /// <summary>
        /// 测试与服务器的连接状态
        /// </summary>
        /// <returns>是否可以正常连接</returns>
        public bool Ping()
        {
            PingReply pingReply = ping.Send(this.ipAddress, this.overTime);
            if (pingReply.Status == IPStatus.Success)
            {
                return true;
            }
            return false;
        }

        public bool Connect()
        {
            try
            {
                if (Ping())
                {
                    this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    this.socket.SendTimeout = overTime;
                    //this.socket.ReceiveTimeout = overTime;
                    this.socket.Connect(this.ipEndPoint);
                }
                else
                {
                    //MessageBox.Show("连接超时");
                    return false;
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return false;
            }
            readThread = new Thread(ReceiveFrom);
            readThread.IsBackground = true;
            readThread.Start();
            return true;
        }

        public void CloseConnect()
        {
            if (socket != null)
            {
                readThread.Abort();
                try
                {
                    socket.Shutdown(SocketShutdown.Both);
                }
                catch
                {
                }
                try
                {
                    socket.Close();
                }
                catch
                {
                }
            }
            try
            {
                ((IDisposable)this).Dispose();
                ping.Dispose();
            }
            catch
            {
            }
        }

        #endregion

        /// <summary>
        /// 获取会话编号
        /// </summary>
        /// <returns>返回本次交互所需的会话编号</returns>
        public static UInt16 GetSessionNum()
        {
            ComSessionNum++;
            if (ComSessionNum == 0)
            {
                ComSessionNum = 1;
            }
            return ComSessionNum;
        }

        private bool SendTo(RequestCmd cmd)
        {
            bool success = false;
            int v;
            try
            {
                v = socket.Send(cmd.GetBytes());
            }
            catch
            {
                return false;
            }
            if (v > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ReceiveFrom()
        {
            while (true)
            {
                byte[] buffer = new byte[4096];
                int v = 0;
                try
                {
                    v = socket.Receive(buffer);
                }
                catch (Exception)
                {
                }
                if (v != 0)
                {
                    recData = new byte[v];
                    Array.ConstrainedCopy(buffer, 0, recData, 0, v);
                }
                else
                {
                    recData = null;
                }
            }
        }

        private void CheckRespones(Object o)
        {
            CheckRes checkRes = (CheckRes)o;
            while (true)
            {
                //防止有空值
                if (recData != null && checkRes != null)
                {
                    //创建返回结果
                    Respones respones = new Respones(recData);          
                    //判断会话号相同
                    if (checkRes.ReuqestSessionNum == respones.recSessionNum)
                    {
                        //防止操作报错
                        if (checkRes.Sfc != respones.sfc)
                        {
                            respones.errorCode = respones.data[17];
                        }
                        checkRes.Respones = respones;
                        checkRes.FindSuccess = true;
                        return;
                    }
                }
            }
        }
        #region 读取数据

        #region 读取UInt16量

        /// <summary>
        /// 读取一个字
        /// </summary>
        /// <param name="cpuNum">从站号</param>
        /// <param name="startAddress">读取的地址</param>
        /// <returns>读取到的字</returns>
        public ReadResult<UInt16> ReadU16(string startAddress)
        {
            ReadResult<UInt16> readResult = new ReadResult<UInt16>();//预备结果
            SFC cmdCode;
            ushort address = 0;
            if (startAddress.Contains("M") || startAddress.Contains("m"))
            {
                cmdCode = SFC.Read16More;
                address = ushort.Parse(startAddress.Substring(1));
            }
            else
            {
                return readResult;
            }

            RequestCmd cmd = new RequestCMDRead(MFC.Extend, cmdCode, this.localCpuNum,this.localCpuNum, DateType.M, address, 1);//创建请求报文
            CheckRes checkRes = new CheckRes(cmd.sessionNum);//创建检查响应目标对象
            bool v = SendTo(cmd);//发送请求
            Thread checkThread = new Thread(CheckRespones);//开启检查响应线程
            checkThread.IsBackground = true;
            checkThread.Start(checkRes);//启动线程，参数为具有本会话号的对象
            checkThread.Join(overTime);//利用检查线程阻塞本线程，超时时间由程序指定
            checkThread.Abort();

            //检查是否找到响应
            if (!checkRes.FindSuccess)
            {
                return readResult;
            }
            //检查响应中是否包含错误代码
            if (checkRes.Respones.errorCode != 0)
            {
                readResult.errorCode = checkRes.Respones.errorCode;
                readResult.isSuccess = false;
                return readResult;
            }
            readResult.isSuccess = true;
            readResult.result = checkRes.Respones.data[23];
            readResult.result = (UInt16)(readResult.result << 8);
            readResult.result = (UInt16)(readResult.result | checkRes.Respones.data[22]);

            return readResult;
        }

        /// <summary>
        /// 读取多个字
        /// </summary>
        /// <param name="cpuNum">从站号</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="reqNum">读取长度</param>
        /// <returns>读取到的字数组</returns>
        public ReadResult<UInt16[]> ReadU16(string startAddress, int reqNum)
        {
            ReadResult<UInt16[]> readResult = new ReadResult<UInt16[]>();//预备结果

            //读取超出范围
            if (reqNum > 2044)
            {
                readResult.errorCode = 0x50;
                return readResult;
            }
            SFC cmdCode;
            ushort address = 0;
            if (startAddress.Contains("M") || startAddress.Contains("m"))
            {
                cmdCode = SFC.Read16More;
                address = ushort.Parse(startAddress.Substring(1));
            }
            else
            {
                return readResult;
            }

            RequestCmd cmd = new RequestCMDRead(MFC.Extend, cmdCode, this.localCpuNum,this.targetCpuNum, DateType.M, address, (ushort)reqNum);//创建请求报文
            CheckRes checkRes = new CheckRes(cmd.sessionNum);//创建检查响应目标对象
            bool v = SendTo(cmd);//发送请求
            Thread checkThread = new Thread(CheckRespones);//开启检查响应线程
            checkThread.IsBackground = true;
            checkThread.Start(checkRes);//启动线程，参数为具有本会话号的对象
            checkThread.Join(overTime);//利用检查线程阻塞本线程，超时时间由程序指定
            checkThread.Abort();

            //检查是否找到响应
            if (!checkRes.FindSuccess)
            {
                return readResult;
            }
            //检查响应中是否包含错误代码
            if (checkRes.Respones.errorCode != 0)
            {
                readResult.errorCode = checkRes.Respones.errorCode;
                readResult.isSuccess = false;
                return readResult;
            }
            readResult.isSuccess = true;
            ushort v1 = BytesToUInt16(checkRes.Respones.data[21], checkRes.Respones.data[20]);
            byte[] resultByte = new byte[v1 * 2];//如果查找成功，则新建结果数组
            Array.ConstrainedCopy(checkRes.Respones.data, 22, resultByte, 0, (v1*2));//从结果报文中获取结果内容
            readResult.result = BytesToUInt16s(resultByte);

            return readResult;
        }

        #endregion

        #region 读取int16量

        /// <summary>
        /// 读取一个字
        /// </summary>
        /// <param name="cpuNum">从站号</param>
        /// <param name="startAddress">读取的地址</param>
        /// <returns>读取到的字</returns>
        public ReadResult<Int16> Read16(string startAddress)
        {
            ReadResult<Int16> readResult = new ReadResult<Int16>();//预备结果
            SFC cmdCode;
            ushort address = 0;
            if (startAddress.Contains("M") || startAddress.Contains("m"))
            {
                cmdCode = SFC.Read16More;
                address = ushort.Parse(startAddress.Substring(1));
            }
            else if (startAddress.Contains("SD") || startAddress.Contains("sd"))
            {
                cmdCode = SFC.Read16More;
                address = ushort.Parse(startAddress.Substring(2));
            }
            else
            {
                return readResult;
            }

            RequestCmd cmd = new RequestCMDRead(MFC.Extend, cmdCode, this.localCpuNum, this.targetCpuNum, DateType.M, address, 1);//创建请求报文
            CheckRes checkRes = new CheckRes(cmd.sessionNum);//创建检查响应目标对象
            bool v = SendTo(cmd);//发送请求
            Thread checkThread = new Thread(CheckRespones);//开启检查响应线程
            checkThread.IsBackground = true;
            checkThread.Start(checkRes);//启动线程，参数为具有本会话号的对象
            checkThread.Join(overTime);//利用检查线程阻塞本线程，超时时间由程序指定
            checkThread.Abort();

            //检查是否找到响应
            if (!checkRes.FindSuccess)
            {
                return readResult;
            }
            //检查响应中是否包含错误代码
            if (checkRes.Respones.errorCode != 0)
            {
                readResult.errorCode = checkRes.Respones.errorCode;
                readResult.isSuccess = false;
                return readResult;
            }
            readResult.isSuccess = true;
            UInt16 tempValue = BytesToUInt16(checkRes.Respones.data[23], checkRes.Respones.data[22]);

            readResult.result = (Int16)tempValue;

            return readResult;
        }

        /// <summary>
        /// 读取多个字
        /// </summary>
        /// <param name="cpuNum">从站号</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="reqNum">读取长度</param>
        /// <returns>读取到的字数组</returns>
        public ReadResult<Int16[]> Read16(string startAddress, int reqNum)
        {
            ReadResult<Int16[]> readResult = new ReadResult<Int16[]>();//预备结果
            //读取超出范围
            if (reqNum > 2044)
            {
                readResult.errorCode = 0x50;
                return readResult;
            }
            SFC cmdCode;
            ushort address = 0;
            if (startAddress.Contains("M") || startAddress.Contains("m"))
            {
                cmdCode = SFC.Read16More;
                address = ushort.Parse(startAddress.Substring(1));
            }
            else if (startAddress.Contains("SD") || startAddress.Contains("sd"))
            {
                cmdCode = SFC.Read16More;
                address = ushort.Parse(startAddress.Substring(2));
            }
            else
            {
                return readResult;
            }

            RequestCmd cmd = new RequestCMDRead(MFC.Extend, cmdCode, this.localCpuNum, this.targetCpuNum, DateType.M, address, (ushort)reqNum);//创建请求报文
            CheckRes checkRes = new CheckRes(cmd.sessionNum);//创建检查响应目标对象
            bool v = SendTo(cmd);//发送请求
            Thread checkThread = new Thread(CheckRespones);//开启检查响应线程
            checkThread.IsBackground = true;
            checkThread.Start(checkRes);//启动线程，参数为具有本会话号的对象
            checkThread.Join(overTime);//利用检查线程阻塞本线程，超时时间由程序指定
            checkThread.Abort();

            //检查是否找到响应
            if (!checkRes.FindSuccess)
            {
                return readResult;
            }
            //检查响应中是否包含错误代码
            if (checkRes.Respones.errorCode != 0)
            {
                readResult.errorCode = checkRes.Respones.errorCode;
                readResult.isSuccess = false;
                return readResult;
            }
            readResult.isSuccess = true;
            ushort v1 = BytesToUInt16(checkRes.Respones.data[21], checkRes.Respones.data[20]);//读取到的总数
            byte[] resultByte = new byte[v1 * 2];//如果查找成功，则新建结果数组
            Array.ConstrainedCopy(checkRes.Respones.data, 22, resultByte, 0, (v1 * 2));//从结果报文中获取结果内容
            UInt16[] tempArr = BytesToUInt16s(resultByte);
            readResult.result = new Int16[tempArr.Length];

            for (int i = 0; i < tempArr.Length; i++)
            {
                readResult.result[i] = (Int16)tempArr[i];
            }

            return readResult;
        }

        #endregion

        #region 读取Uint32量

        /// <summary>
        /// 读取一个双字
        /// </summary>
        /// <param name="cpuNum">从站号</param>
        /// <param name="startAddress">读取的地址</param>
        /// <returns>读取到的字</returns>
        public ReadResult<uint> ReadU32(string startAddress)
        {
            ReadResult<uint> readResult = new ReadResult<uint>();//预备结果

            ReadResult<ushort[]> readResultUint16 = ReadU16(startAddress, 2);

            readResult.isSuccess = readResultUint16.isSuccess;

            if (readResultUint16.isSuccess)
            {
                readResult.result = readResultUint16.result[1];
                readResult.result = readResult.result << 16;
                readResult.result = readResult.result | readResultUint16.result[0];
            }

            return readResult;
        }

        /// <summary>
        /// 读取多个双字
        /// </summary>
        /// <param name="cpuNum">从站号</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="reqNum">读取长度</param>
        /// <returns>读取到的字数组</returns>
        public ReadResult<uint[]> ReadU32(string startAddress, int reqNum)
        {
            ReadResult<uint[]> readResult = new ReadResult<uint[]>();//预备结果
            //读取超出范围
            if (reqNum > 1022)
            {
                readResult.errorCode = 0x50;
                return readResult;
            }
            readResult.result = new uint[reqNum];

            ReadResult<ushort[]> readResultUint16 = ReadU16(startAddress, 2 * reqNum);

            readResult.isSuccess = readResultUint16.isSuccess;

            if (readResultUint16.isSuccess)
            {
                for (int i = 0; i < reqNum; i++)
                {
                    readResult.result[i] = readResultUint16.result[(2 * i) + 1];
                    readResult.result[i] = readResult.result[i] << 16;
                    readResult.result[i] = readResult.result[i] | readResultUint16.result[2 * i];
                }
            }            

            return readResult;
        }

        #endregion

        #region 读取int32量

        /// <summary>
        /// 读取一个双字
        /// </summary>
        /// <param name="cpuNum">从站号</param>
        /// <param name="startAddress">读取的地址</param>
        /// <returns>读取到的字</returns>
        public ReadResult<int> Read32(string startAddress)
        {
            ReadResult<int> readResult = new ReadResult<int>();//预备结果
            int result = 0;

            ReadResult<ushort[]> readResultUint16 = ReadU16(startAddress, 2);

            readResult.isSuccess = readResultUint16.isSuccess;

            if (readResultUint16.isSuccess)
            {
                result = readResultUint16.result[1];
                result = result << 16;
                result = result | readResultUint16.result[0];
                readResult.result = result;
            }           

            return readResult;
        }

        /// <summary>
        /// 读取多个双字
        /// </summary>
        /// <param name="cpuNum">从站号</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="reqNum">读取长度</param>
        /// <returns>读取到的字数组</returns>
        public ReadResult<int[]> Read32(string startAddress, int reqNum)
        {
            ReadResult<int[]> readResult = new ReadResult<int[]>();//预备结果
            //读取超出范围
            if (reqNum > 1022)
            {
                readResult.errorCode = 0x50;
                return readResult;
            }
            readResult.result = new int[reqNum];

            ReadResult<ushort[]> readResultUint16 = ReadU16(startAddress, 2 * reqNum);

            readResult.isSuccess = readResultUint16.isSuccess;

            if (readResultUint16.isSuccess)
            {
                for (int i = 0; i < reqNum; i++)
                {
                    uint tempVar;
                    tempVar = readResultUint16.result[(2 * i) + 1];
                    tempVar = tempVar << 16;
                    tempVar = tempVar | readResultUint16.result[2 * i];
                    readResult.result[i] = (int)tempVar;
                }
            }

            return readResult;
        }

        #endregion


        #region 读取字符串

        /// <summary>
        /// 读取多个双字
        /// </summary>
        /// <param name="startAddress">起始地址</param>
        /// <param name="reqNum">读取长度</param>
        /// <returns>读取到的字符串</returns>
        public ReadResult<string> ReadString(string startAddress, int reqNum)
        {
            ReadResult<string> readResult = new ReadResult<string>();//预备结果
            //读取超出范围
            if (reqNum > 4088)
            {
                readResult.errorCode = 0x50;
                return readResult;
            }
            readResult.result = "";

            int readLength = (reqNum + 1) / 2;
            ReadResult<ushort[]> readResultUint16 = ReadU16(startAddress, readLength);

            readResult.isSuccess = readResultUint16.isSuccess;

            if (readResultUint16.isSuccess)
            {
                byte[] bytes = Uint16ToBytes(readResultUint16.result);
                string result = Encoding.ASCII.GetString(bytes, 0, reqNum);
                readResult.result = result;  
            }

            return readResult;
        }

        #endregion

        #endregion

        #region 写入数据

        #region 单个写入

        public bool Write(string startAddress, UInt16 value)
        {
            SFC cmdCode;
            ushort address = 0;
            if (startAddress.Contains("M") || startAddress.Contains("m"))
            {
                cmdCode = SFC.Write16More;
                address = ushort.Parse(startAddress.Substring(1));
            }
            else
            {
                return false;
            }
            byte[] vs = Uint16ToBytes(value);
            RequestCmd cmd = new RequestCMDWriteMore(MFC.Extend, cmdCode, this.localCpuNum, this.targetCpuNum, DateType.M, address, 1, vs);
            CheckRes checkRes = new CheckRes(cmd.sessionNum);//创建检查响应目标对象
            bool v = SendTo(cmd);//发送请求
            Thread checkThread = new Thread(CheckRespones);//开启检查响应线程
            checkThread.IsBackground = true;
            checkThread.Start(checkRes);//启动线程，参数为具有本会话号的对象
            checkThread.Join(overTime);//利用检查线程阻塞本线程，超时时间由程序指定
            checkThread.Abort();

            //检查是否找到响应
            if (!checkRes.FindSuccess)
            {
                return false;
            }
            
            //检查响应中是否包含错误代码
            if (checkRes.Respones.errorCode != 0)
            {
                return false;
            }

            byte[] cmdBytes = cmd.GetBytes();
            //比较写入的起始地址和数量是否一致
            if (cmdBytes[20] == checkRes.Respones.data[20] &&
                cmdBytes[21] == checkRes.Respones.data[21] &&
                cmdBytes[22] == checkRes.Respones.data[22] &&
                cmdBytes[23] == checkRes.Respones.data[23] &&
                cmdBytes[24] == checkRes.Respones.data[24] &&
                cmdBytes[25] == checkRes.Respones.data[25])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Write(string startAddress, Int16 value)
        {
            SFC cmdCode;
            ushort address = 0;
            if (startAddress.Contains("M") || startAddress.Contains("m"))
            {
                cmdCode = SFC.Write16More;
                address = ushort.Parse(startAddress.Substring(1));
            }
            else
            {
                return false;
            }
            byte[] vs = Int16ToBytes(value);
            RequestCmd cmd = new RequestCMDWriteMore(MFC.Extend, cmdCode, this.localCpuNum, this.targetCpuNum, DateType.M, address, 1, vs);
            CheckRes checkRes = new CheckRes(cmd.sessionNum);//创建检查响应目标对象
            bool v = SendTo(cmd);//发送请求
            Thread checkThread = new Thread(CheckRespones);//开启检查响应线程
            checkThread.IsBackground = true;
            checkThread.Start(checkRes);//启动线程，参数为具有本会话号的对象
            checkThread.Join(overTime);//利用检查线程阻塞本线程，超时时间由程序指定
            checkThread.Abort();

            //检查是否找到响应
            if (!checkRes.FindSuccess)
            {
                return false;
            }

            //检查响应中是否包含错误代码
            if (checkRes.Respones.errorCode != 0)
            {
                return false;
            }
            byte[] cmdBytes = cmd.GetBytes();
            //比较写入的起始地址和数量是否一致
            if (cmdBytes[20] == checkRes.Respones.data[20] &&
                cmdBytes[21] == checkRes.Respones.data[21] &&
                cmdBytes[22] == checkRes.Respones.data[22] &&
                cmdBytes[23] == checkRes.Respones.data[23] &&
                cmdBytes[24] == checkRes.Respones.data[24] &&
                cmdBytes[25] == checkRes.Respones.data[25])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Write(string startAddress, uint value)
        {
            UInt16[] tempArr = new UInt16[2];
            tempArr[0] = (UInt16)(value & 0x0000ffff);
            tempArr[1] = (UInt16)(value >> 16);
            bool v = Write(startAddress, tempArr);

            return v;
        }

        public bool Write(string startAddress, int value)
        {
            UInt16[] tempArr = new UInt16[2];
            uint valueU = (uint)value;
            tempArr[0] = (UInt16)(valueU & 0x0000ffff);
            tempArr[1] = (UInt16)(valueU >> 16);
            bool v = Write(startAddress, tempArr);

            return v;
        }

        #endregion

        #region 多个写入

        /// <summary>
        /// 写入多个16位无符号变量，最大数量不可以超过2043个
        /// </summary>
        /// <param name="startAddress">起始地址</param>
        /// <param name="value">要写入的数据</param>
        /// <returns>写入是否成功</returns>
        public bool Write(string startAddress, UInt16[] value)
        {
            SFC cmdCode;
            ushort address = 0;
            //检查写入是否超长
            if (value.Length > 2043)
            {
                return false;
            }

            if (startAddress.Contains("M") || startAddress.Contains("m"))
            {
                cmdCode = SFC.Write16More;
                address = ushort.Parse(startAddress.Substring(1));
            }
            else
            {
                return false;
            }
            byte[] vs = Uint16ToBytes(value);
            RequestCmd cmd = new RequestCMDWriteMore(MFC.Extend, cmdCode, this.localCpuNum, this.targetCpuNum, DateType.M, address, (UInt16)value.Length, vs);
            CheckRes checkRes = new CheckRes(cmd.sessionNum);//创建检查响应目标对象
            bool v = SendTo(cmd);//发送请求
            Thread checkThread = new Thread(CheckRespones);//开启检查响应线程
            checkThread.IsBackground = true;
            checkThread.Start(checkRes);//启动线程，参数为具有本会话号的对象
            checkThread.Join(overTime);//利用检查线程阻塞本线程，超时时间由程序指定
            checkThread.Abort();

            //检查是否找到响应
            if (!checkRes.FindSuccess)
            {
                return false;
            }

            //检查响应中是否包含错误代码
            if (checkRes.Respones.errorCode != 0)
            {
                return false;
            }
            byte[] cmdBytes = cmd.GetBytes();

            //比较写入的起始地址和数量是否一致
            if (cmdBytes[20] == checkRes.Respones.data[20] &&
                cmdBytes[21] == checkRes.Respones.data[21] &&
                cmdBytes[22] == checkRes.Respones.data[22] &&
                cmdBytes[23] == checkRes.Respones.data[23] &&
                cmdBytes[24] == checkRes.Respones.data[24] &&
                cmdBytes[25] == checkRes.Respones.data[25])
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 写入多个16位有符号变量，最大数量不可以超过2043个
        /// </summary>
        /// <param name="startAddress">起始地址</param>
        /// <param name="value">要写入的数据</param>
        /// <returns>写入是否成功</returns>
        public bool Write(string startAddress, Int16[] value)
        {
            SFC cmdCode;
            ushort address = 0;
            //检查写入是否超长
            if (value.Length > 2043)
            {
                return false;
            }
            if (startAddress.Contains("M") || startAddress.Contains("m"))
            {
                cmdCode = SFC.Write16More;
                address = ushort.Parse(startAddress.Substring(1));
            }
            else
            {
                return false;
            }
            byte[] vs = Int16ToBytes(value);
            RequestCmd cmd = new RequestCMDWriteMore(MFC.Extend, cmdCode, this.localCpuNum, this.targetCpuNum, DateType.M, address, (UInt16)value.Length, vs);
            CheckRes checkRes = new CheckRes(cmd.sessionNum);//创建检查响应目标对象
            bool v = SendTo(cmd);//发送请求
            Thread checkThread = new Thread(CheckRespones);//开启检查响应线程
            checkThread.IsBackground = true;
            checkThread.Start(checkRes);//启动线程，参数为具有本会话号的对象
            checkThread.Join(overTime);//利用检查线程阻塞本线程，超时时间由程序指定
            checkThread.Abort();


            //检查是否找到响应
            if (!checkRes.FindSuccess)
            {
                return false;
            }

            //检查响应中是否包含错误代码
            if (checkRes.Respones.errorCode != 0)
            {
                return false;
            }

            byte[] cmdBytes = cmd.GetBytes();
            //比较写入的起始地址和数量是否一致
            if (cmdBytes[20] == checkRes.Respones.data[20] &&
                cmdBytes[21] == checkRes.Respones.data[21] &&
                cmdBytes[22] == checkRes.Respones.data[22] &&
                cmdBytes[23] == checkRes.Respones.data[23] &&
                cmdBytes[24] == checkRes.Respones.data[24] &&
                cmdBytes[25] == checkRes.Respones.data[25])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 写入多个32位无符号变量，最大数量不可以超过1021个
        /// </summary>
        /// <param name="startAddress">起始地址</param>
        /// <param name="value">要写入的数据</param>
        /// <returns>写入是否成功</returns>
        public bool Write(string startAddress, uint[] value)
        {
            //检查写入是否超长
            if (value.Length > 1021)
            {
                return false;
            }
            UInt16[] tempArr = new ushort[value.Length * 2];

            for (int i = 0; i < value.Length; i++)
            {
                tempArr[i * 2] = (UInt16)(value[i] & 0x0000ffff);
                tempArr[(i * 2) + 1] = (UInt16)(value[i] >> 16);
            }

            bool v = Write(startAddress, tempArr);

            return v;
        }

        /// <summary>
        /// 写入多个32位有符号变量，最大数量不可以超过1021个
        /// </summary>
        /// <param name="startAddress">起始地址</param>
        /// <param name="value">要写入的数据</param>
        /// <returns>写入是否成功</returns>
        public bool Write(string startAddress, int[] value)
        {
            //检查写入是否超长
            if (value.Length > 1021)
            {
                return false;
            }
            UInt16[] tempArr = new UInt16[value.Length * 2];

            for (int i = 0; i < value.Length; i++)
            {
                uint tempVar = (uint)value[i];
                tempArr[i * 2] = (UInt16)(tempVar & 0x0000ffff);
                tempArr[(i * 2) + 1] = (UInt16)(tempVar >> 16);
            }

            bool v = Write(startAddress, tempArr);

            return v;
        }

        /// <summary>
        /// 写入字符串，最大长度不可以超过4088
        /// </summary>
        /// <param name="startAddress">起始地址</param>
        /// <param name="value">要写入的数据</param>
        /// <returns>写入是否成功</returns>
        public bool Write(string startAddress, string value)
        {
            //检查写入是否超长
            if (value.Length > 4088)
            {
                return false;
            }
            int length = (value.Length + 1) / 2;

            byte[] bytes = Encoding.ASCII.GetBytes(value);

            ushort[] tempArr = BytesToUInt16s(bytes);

            bool v = Write(startAddress, tempArr);

            return v;
        }

        #endregion

        #endregion

        #region 工具函数(byte转short、int等)
        public bool ByteArrayEquals(byte[] b1, byte[] b2)
        {
            if (b1.Length == b2.Length)
            {
                for (int i = 0; i < b1.Length; i++)
                {
                    if (b1[i] != b2[i])
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool ByteToBool(byte value)
        {
            return value == 0 ? false : true;
        }

        /// <summary>
        /// 将byte数组中的bool按规律和数量要求提取为Bool数组
        /// </summary>
        /// <param name="bytes">要转换的Byte数组</param>
        /// <param name="num">要转换多少Bool量</param>
        /// <returns>结果Bool数组</returns>
        public bool[] ByteToBool(byte[] bytes, int num)
        {
            bool[] bools = new bool[num];

            for (int i = 0; i < bytes.Length; i++)//遍历所有数组
            {
                if (i != num / 8)//计算整字节数量，比较是否是最后一个字节
                {
                    byte tool = 0x01;//用于位与的工具数字
                    for (int j = 0; j < 8; j++)//遍历本byte中的每一位
                    {
                        bools[j + (i * 8)] = ByteToBool((byte)(bytes[i] & tool));//工具数与要检查的byte位与后仅保留1位，转化为bool值后赋给结果
                        tool = (byte)(tool << 1);
                    }
                }
                else
                {
                    byte tool = 0x01;//用于位与的工具数字
                    for (int j = 0; j < num % 8; j++)//遍历本byte中的每一位
                    {
                        bools[j + (i * 8)] = ByteToBool((byte)(bytes[i] & tool));//工具数与要检查的byte位与后仅保留1位，转化为bool值后赋给结果
                        tool = (byte)(tool << 1);
                    }
                }
            }

            return bools;
        }

        public byte[] BoolsToBytes(bool[] values)
        {
            byte[] result = new byte[(values.Length / 8) + 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = 0;
                byte tool = 0x01;
                for (int j = 0; (i * 8) + j < values.Length; j++)
                {
                    if (values[(i * 8) + j])
                    {
                        result[i] = (byte)(result[i] | tool);
                    }
                    tool = (byte)(tool << 1);
                }
            }
            return result;
        }

        public UInt16 BytesToUInt16(byte high, byte low)
        {
            UInt16 result;
            result = high;
            result = (UInt16)(result << 8);
            result = (UInt16)(result | low);

            return result;
        }

        public UInt16 BytesToUInt16(byte[] bytes)
        {
            UInt16 result;
            result = bytes[1];
            result = (UInt16)(result << 8);
            result = (UInt16)(result | bytes[0]);

            return result;
        }

        /// <summary>
        /// 将byte数组转换为uint16数组
        /// 目前格式为byte[2n]为低位，byte[2n+1]为高位
        /// </summary>
        /// <param name="bytes">要转换的byte数组</param>
        /// <returns>转换后的uint16数组</returns>
        public UInt16[] BytesToUInt16s(byte[] bytes)
        {
            //准备结果
            UInt16[] uints = new UInt16[(bytes.Length / 2) + 1];

            //遍历参数
            for (int i = 0; i < uints.Length; i++)
            {
                //准备数组下标，避免多次运算
                int n = 2 * i;

                //将第n个参数值写入结果低位
                uints[i] = bytes[n];

                //判断是否超出参数长度
                if (n + 1 < bytes.Length)
                {
                    //将第n + 1个参数左移8位后于结果位或，得到合并后的值
                    uints[i] = (UInt16)(uints[i] | ((bytes[n + 1]) << 8));
                }

                /*uints[i] = bytes[(i * 2) + 1];
                uints[i] = (UInt16)(uints[i] << 8);
                uints[i] = (UInt16)(uints[i] | bytes[i * 2]);*/
            }
            return uints;
        }

        /// <summary>
        /// 低8位在前
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] Uint16ToBytes(UInt16 value)
        {
            byte[] bytes = new byte[2];

            bytes[0] = (byte)(value & 0x00ff);
            bytes[1] = (byte)(value >> 8);

            return bytes;
        }

        public byte[] Uint16ToBytes(UInt16[] value)
        {
            byte[] bytes = new byte[value.Length * 2];
            for (int i = 0; i < value.Length; i++)
            {
                bytes[i * 2] = (byte)(value[i] & 0x00ff);
                bytes[(i * 2) + 1] = (byte)(value[i] >> 8);
            }
            return bytes;
        }

        public byte[] Int16ToBytes(Int16 value)
        {
            byte[] bytes = new byte[2];
            bytes[0] = (byte)(value & 0x00ff);
            bytes[1] = (byte)(value >> 8);
            return bytes;
        }

        public byte[] Int16ToBytes(Int16[] value)
        {
            byte[] bytes = new byte[value.Length * 2];
            for (int i = 0; i < value.Length; i++)
            {
                bytes[i * 2] = (byte)(value[i] & 0x00ff);
                bytes[(i * 2) + 1] = (byte)(value[i] >> 8);
            }
            return bytes;
        }

        public byte[] MakeTargetRespones(byte[] value)
        {
            byte[] result = new byte[12];
            Array.Copy(value, 14, result, 0, 12);
            return result;
        }

        #endregion

    }

    #region 结果类、参数枚举等

    #region 结果类

    /// <summary>
    /// 读取到的结果
    /// </summary>
    /// <typeparam name="isSuccess">结果是否成功</typeparam>
    /// <typeparam name="T">读取到的结果内容</typeparam>
    public class ReadResult<T>
    {
        public bool isSuccess;
        public byte errorCode;
        public T result;

        public ReadResult()
        {
            this.isSuccess = false;
            this.result = default(T);
        }
    }

    #endregion

    #region 参数枚举

    /// <summary>
    /// 主功能码
    /// </summary>
    public enum MFC : byte
    {
        //命令码
        /// <summary>
        /// 标准
        /// </summary>
        Standard = 0x20,

        /// <summary>
        /// 扩展
        /// </summary>
        Extend = 0x43,
    }

    /// <summary>
    /// 子功能码
    /// </summary>
    public enum SFC : byte
    {
        //命令码
        /// <summary>
        /// 读取多个16位变量
        /// </summary>
        Read16More = 0x49,

        /// <summary>
        /// 写入多个16位变量
        /// </summary>
        Write16More = 0x4B,
    }

    public enum DateType : byte
    {
        /// <summary>
        /// 保持寄存器
        /// </summary>
        M = 0x4D,

        /// <summary>
        /// 数据寄存器
        /// </summary>
        G = 0x47,

        /// <summary>
        /// 输入寄存器
        /// </summary>
        I = 0x49,

        /// <summary>
        /// 输出寄存器
        /// </summary>
        O = 0x4F,

        /// <summary>
        /// 系统寄存器
        /// </summary>
        S = 0x53,
    }

    /// <summary>
    /// 指示要操作的数据长度
    /// </summary>
    public enum DateLength : byte
    {
        /// <summary>
        /// 16位
        /// </summary>
        Word = 2,

        /// <summary>
        /// 32位
        /// </summary>
        DWord = 3,
    }

    #endregion

    #region 请求报文

    public abstract class RequestCmd
    {
        //218报文头关键值
        public byte cmdType = 0x11;//Memobus指令为11，响应为19，通用信息12
        public byte sessionNum;//会话识别号(序列号),每次自增
        public byte tragetChannelNum = 0;//目标通道编号，MP系列以外的设备均为00
        public byte sourceChannelNum = 0;//发送源通道编号，MP系列以外的设备均为00
        public ushort dateTotalLength;//218报头和后续数据的字节总长

        abstract public byte[] GetBytes();
    }

    class RequestCMDRead : RequestCmd
    {
        public UInt16 length = 0x0C;//后续命令长度
        public MFC mfc;//主功能码
        public SFC sfc;//子功能码
        public byte localCpuNum;//CPU编号
        public byte targetCpuNum;//CPU编号
        public DateType dateType;//寄存器种类
        public uint startAddress;//起始地址
        public UInt16 reqNum;//读取数量

        /// <summary>
        /// 创建读取多个16位变量的报文
        /// </summary>
        /// <param name="mfc">主功能码</param>
        /// <param name="sfc">子功能码</param>
        /// <param name="localCpuNum">本CPU编号</param>
        /// <param name="targetCpuNum">目标CPU编号</param>
        /// <param name="dateType">寄存器类型</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="reqNum">读取数量</param>
        public RequestCMDRead(MFC mfc, SFC sfc, byte localCpuNum,byte targetCpuNum, DateType dateType, uint startAddress, ushort reqNum)
        {
            sessionNum = MemobusTool.GetSessionNum();
            dateTotalLength = 26;

            this.mfc = mfc;
            this.sfc = sfc;
            this.localCpuNum = localCpuNum;
            this.targetCpuNum = targetCpuNum;
            this.dateType = dateType;
            this.startAddress = startAddress;
            this.reqNum = reqNum;
        }

        override public byte[] GetBytes()
        {
            byte[] bytes = new byte[this.dateTotalLength];
            //组成218报文头
            bytes[0] = cmdType;
            bytes[1] = sessionNum;
            bytes[2] = tragetChannelNum;
            bytes[3] = sourceChannelNum;
            bytes[4] = 0;
            bytes[5] = 0;
            bytes[6] = (byte)(dateTotalLength & 0x00ff);
            bytes[7] = (byte)(dateTotalLength >> 8);
            bytes[8] = 0;
            bytes[9] = 0;
            bytes[10] = 0;
            bytes[11] = 0;

            //组成Memobus报文数据部分
            bytes[12] = (byte)(length & 0x00ff);
            bytes[13] = (byte)(length >> 8);
            bytes[14] = (byte)mfc;
            bytes[15] = (byte)sfc;
            bytes[16] = (byte)(localCpuNum | (targetCpuNum << 4));
            bytes[17] = 0;
            bytes[18] = (byte)dateType;
            bytes[19] = 0;
            bytes[20] = (byte)(startAddress & 0x000000ff);
            bytes[21] = (byte)((startAddress & 0x0000ff00) >> 8);
            bytes[22] = (byte)((startAddress & 0x00ff0000) >> 16);
            bytes[23] = (byte)((startAddress & 0xff000000) >> 32);
            bytes[24] = (byte)(reqNum & 0x00ff);
            bytes[25] = (byte)(reqNum >> 8);

            return bytes;
        }
    }

    class RequestCMDWriteMore : RequestCmd
    {
        public UInt16 length;//后续命令长度
        public MFC mfc;//主功能码
        public SFC sfc;//子功能码
        public byte localCpuNum;//CPU编号
        public byte targetCpuNum;//CPU编号
        public DateType dateType;//寄存器种类
        public uint startAddress;//起始地址
        public UInt16 reqNum;//读取数量
        public byte[] data;//要写入的内容

        /// <summary>
        /// 创建用于写入多个16位数据的命令
        /// </summary>
        /// <param name="mfc">主功能码</param>
        /// <param name="sfc">子功能码</param>
        /// <param name="localCpuNum">本CPU编号</param>
        /// <param name="targetCpuNum">本CPU编号</param>
        /// <param name="dateType">寄存器类型</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="reqNum">读取数量</param>
        /// <param name="bytes">要写入的字节数组</param>
        public RequestCMDWriteMore(MFC mfc, SFC sfc, byte localCpuNum, byte targetCpuNum, DateType dateType, uint startAddress, ushort reqNum, byte[] bytes)
        {
            sessionNum = MemobusTool.GetSessionNum();
            dateTotalLength = (ushort)(26 + bytes.Length);

            length = (UInt16)(12 + bytes.Length);
            this.mfc = mfc;
            this.sfc = sfc;
            this.localCpuNum = localCpuNum;
            this.targetCpuNum = targetCpuNum;
            this.dateType = dateType;
            this.startAddress = startAddress;
            this.reqNum = reqNum;
            this.data = bytes;
        }

        override public byte[] GetBytes()
        {
            byte[] bytes = new byte[this.dateTotalLength];
            //组成218报文头
            bytes[0] = cmdType;
            bytes[1] = sessionNum;
            bytes[2] = tragetChannelNum;
            bytes[3] = sourceChannelNum;
            bytes[4] = 0;
            bytes[5] = 0;
            bytes[6] = (byte)(dateTotalLength & 0x00ff);
            bytes[7] = (byte)(dateTotalLength >> 8);
            bytes[8] = 0;
            bytes[9] = 0;
            bytes[10] = 0;
            bytes[11] = 0;

            //组成Memobus报文数据部分
            bytes[12] = (byte)(length & 0x00ff);
            bytes[13] = (byte)(length >> 8);
            bytes[14] = (byte)mfc;
            bytes[15] = (byte)sfc;
            bytes[16] = (byte)(localCpuNum | (targetCpuNum << 4));
            bytes[17] = 0;
            bytes[18] = (byte)dateType;
            bytes[19] = 0;
            bytes[20] = (byte)(startAddress & 0x000000ff);
            bytes[21] = (byte)((startAddress & 0x0000ff00) >> 8);
            bytes[22] = (byte)((startAddress & 0x00ff0000) >> 16);
            bytes[23] = (byte)((startAddress & 0xff000000) >> 32);
            bytes[24] = (byte)(reqNum & 0x00ff);
            bytes[25] = (byte)(reqNum >> 8);

            for (int i = 0; i < data.Length; i++)
            {
                bytes[26 + i] = data[i];
            }

            return bytes;
        }
    }

    #endregion

    #region 响应报文

    class CheckRes
    {
        private UInt16 reuqestSessionNum;
        private byte sfc;
        private bool findSuccess = false;

        private Respones respones;

        public CheckRes(ushort reuqestSessionNum)
        {
            this.reuqestSessionNum = reuqestSessionNum;
        }

        public ushort ReuqestSessionNum { get => reuqestSessionNum; set => reuqestSessionNum = value; }
        public bool FindSuccess { get => findSuccess; set => findSuccess = value; }
        internal byte Sfc { get => sfc; set => sfc = value; }
        internal Respones Respones { get => respones; set => respones = value; }
    }

    class Respones
    {
        public byte recSessionNum;//会话识别号(序列号),每次自增
        public ushort dateTotalLength;//218报头和后续数据的字节总长
        public UInt16 length;//响应内容部分的长度
        public byte sfc;//接收到的子功能码
        public byte[] data;

        public byte errorCode = 0;

        public Respones(byte[] bytes)
        {
            this.recSessionNum = bytes[1];
            this.dateTotalLength = (UInt16)(bytes[7] << 8);
            this.dateTotalLength = (UInt16)(this.dateTotalLength | bytes[6]);
            this.length = (UInt16)(bytes[13] << 8);
            this.length = (UInt16)(this.length | bytes[12]);
            this.sfc = bytes[15];
            data = new byte[bytes.Length];
            Array.ConstrainedCopy(bytes, 0, data, 0, bytes.Length);
        }
    }

    #endregion

    #endregion

}
