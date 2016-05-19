using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;//using regular expression
using System.IO;
using System.Threading;

//1.ZLGCAN系列接口卡信息的数据类型。
public struct VCI_BOARD_INFO 
{ 
	public UInt16	hw_Version;
    public UInt16 fw_Version;
    public UInt16 dr_Version;
    public UInt16 in_Version;
    public UInt16 irq_Num;
    public byte can_Num;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst=20)] public byte []str_Serial_Num;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
    public byte[] str_hw_Type;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public byte[] Reserved;
}


/////////////////////////////////////////////////////
//2.定义CAN信息帧的数据类型。
unsafe public struct VCI_CAN_OBJ  //使用不安全代码
{
    public uint ID;
    public uint TimeStamp;
    public byte TimeFlag;
    public byte SendType;
    public byte RemoteFlag;//是否是远程帧
    public byte ExternFlag;//是否是扩展帧
    public byte DataLen;

    public fixed byte Data[8];

    public fixed byte Reserved[3];

}
////2.定义CAN信息帧的数据类型。
//public struct VCI_CAN_OBJ 
//{
//    public UInt32 ID;
//    public UInt32 TimeStamp;
//    public byte TimeFlag;
//    public byte SendType;
//    public byte RemoteFlag;//是否是远程帧
//    public byte ExternFlag;//是否是扩展帧
//    public byte DataLen;
//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
//    public byte[] Data;
//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
//    public byte[] Reserved;

//    public void Init()
//    {
//        Data = new byte[8];
//        Reserved = new byte[3];
//    }
//}

//3.定义CAN控制器状态的数据类型。
public struct VCI_CAN_STATUS 
{
    public byte ErrInterrupt;
    public byte regMode;
    public byte regStatus;
    public byte regALCapture;
    public byte regECCapture;
    public byte regEWLimit;
    public byte regRECounter;
    public byte regTECounter;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] Reserved;
}

//4.定义错误信息的数据类型。
public struct VCI_ERR_INFO 
{
    public UInt32 ErrCode;
    public byte Passive_ErrData1;
    public byte Passive_ErrData2;
    public byte Passive_ErrData3;
    public byte ArLost_ErrData;
}

//5.定义初始化CAN的数据类型
public struct VCI_INIT_CONFIG 
{
    public UInt32 AccCode;
    public UInt32 AccMask;
    public UInt32 Reserved;
    public byte Filter;
    public byte Timing0;
    public byte Timing1;
    public byte Mode;
}

public struct CHGDESIPANDPORT 
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
    public byte[] szpwd;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
    public byte[] szdesip;
    public Int32 desport;

    public void Init()
    {
        szpwd = new byte[10];
        szdesip = new byte[20];
    }
}

///////// new add struct for filter /////////
//typedef struct _VCI_FILTER_RECORD{
//    DWORD ExtFrame;	//是否为扩展帧
//    DWORD Start;
//    DWORD End;
//}VCI_FILTER_RECORD,*PVCI_FILTER_RECORD;
public struct VCI_FILTER_RECORD
{
    public UInt32 ExtFrame;
    public UInt32 Start;
    public UInt32 End;
}


namespace GYKDataAnalyzer
{
    public partial class Form1 : Form
    {
        const int VCI_PCI5121 = 1;
        const int VCI_PCI9810 = 2;
        const int VCI_USBCAN1 = 3;
        const int VCI_USBCAN2 = 4;
        const int VCI_USBCAN2A = 4;
        const int VCI_PCI9820 = 5;
        const int VCI_CAN232 = 6;
        const int VCI_PCI5110 = 7;
        const int VCI_CANLITE = 8;
        const int VCI_ISA9620 = 9;
        const int VCI_ISA5420 = 10;
        const int VCI_PC104CAN = 11;
        const int VCI_CANETUDP = 12;
        const int VCI_CANETE = 12;
        const int VCI_DNP9810 = 13;
        const int VCI_PCI9840 = 14;
        const int VCI_PC104CAN2 = 15;
        const int VCI_PCI9820I = 16;
        const int VCI_CANETTCP = 17;
        const int VCI_PEC9920 = 18;
        const int VCI_PCI5010U = 19;
        const int VCI_USBCAN_E_U = 20;
        const int VCI_USBCAN_2E_U = 21;
        const int VCI_PCI5020U = 22;
        const int VCI_EG20T_CAN = 23;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DeviceType"></param>
        /// <param name="DeviceInd"></param>
        /// <param name="Reserved"></param>
        /// <returns></returns>

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_OpenDevice(UInt32 DeviceType, UInt32 DeviceInd, UInt32 Reserved);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_CloseDevice(UInt32 DeviceType, UInt32 DeviceInd);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_InitCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_INIT_CONFIG pInitConfig);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ReadBoardInfo(UInt32 DeviceType, UInt32 DeviceInd, ref VCI_BOARD_INFO pInfo);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ReadErrInfo(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_ERR_INFO pErrInfo);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ReadCANStatus(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_STATUS pCANStatus);

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_GetReference(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, UInt32 RefType, ref byte pData);
        [DllImport("controlcan.dll")]
        //static extern UInt32 VCI_SetReference(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, UInt32 RefType, ref byte pData);
        unsafe static extern UInt32 VCI_SetReference(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, UInt32 RefType, byte* pData);

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_GetReceiveNum(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ClearBuffer(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_StartCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ResetCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_Transmit(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_OBJ pSend, UInt32 Len);

        //[DllImport("controlcan.dll")]
        //static extern UInt32 VCI_Receive(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_OBJ pReceive, UInt32 Len, Int32 WaitTime);
        [DllImport("controlcan.dll", CharSet = CharSet.Ansi)]
        static extern UInt32 VCI_Receive(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, IntPtr pReceive, UInt32 Len, Int32 WaitTime);

        //static UInt32 m_devtype = 4;//USBCAN2
        static UInt32 m_devtype = 21;//USBCAN-2e-u
        //usb-e-u 波特率
        static UInt32[] GCanBrTab = new UInt32[10]{
	                0x060003, 0x060004, 0x060007,
		                0x1C0008, 0x1C0011, 0x160023,
		                0x1C002C, 0x1600B3, 0x1C00E0,
		                0x1C01C1
                };
        ////////////////////////////////////////
        const UInt32 STATUS_OK = 1;

        UInt32 m_bOpen = 0;
        UInt32 m_devind = 0;
        UInt32 m_canind = 0;

        VCI_CAN_OBJ[] m_recobj = new VCI_CAN_OBJ[50];

        UInt32[] m_arrdevtype = new UInt32[20];
        //export CAN data
        bool blRecordData = false;
        static string sSaveFilePath = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox_DevIndex.SelectedIndex = 0;
            comboBox_CANIndex.SelectedIndex = 0;
            textBox_AccCode.Text = "00000000";
            textBox_AccMask.Text = "FFFFFFFF";
            textBox_Time0.Text = "00";
            textBox_Time1.Text = "14";
            comboBox_Filter.SelectedIndex = 1;
            comboBox_Mode.SelectedIndex = 0;
            comboBox_SendType.SelectedIndex = 2;
            comboBox_FrameFormat.SelectedIndex = 0;
            comboBox_FrameType.SelectedIndex = 0;
            textBox_ID.Text = "00000123";
            textBox_Data.Text = "00 01 02 03 04 05 06 07 ";

            comboBox_e_u_baud.SelectedIndex = 2;//500Kbps
            comboBox_e_u_Filter.SelectedIndex = 0;//禁用
            //textBox_e_u_startid.Text = "1";
            //textBox_e_u_endid.Text = "ff";

            //
            Int32 curindex = 0;
            comboBox_devtype.Items.Clear();

            curindex = comboBox_devtype.Items.Add("USBCAN_E_U");
            m_arrdevtype[curindex] = VCI_USBCAN_E_U;

            curindex = comboBox_devtype.Items.Add("USBCAN_2E_U");
            m_arrdevtype[curindex] = VCI_USBCAN_2E_U;

            curindex = comboBox_devtype.Items.Add("PCI5010U");
            m_arrdevtype[curindex] = VCI_PCI5010U;

            curindex = comboBox_devtype.Items.Add("PCI5020U");
            m_arrdevtype[curindex] = VCI_PCI5020U;

            comboBox_devtype.SelectedIndex = 0;
            comboBox_devtype.MaxDropDownItems = comboBox_devtype.Items.Count;

            pictureBox_Light.Image = imageList1.Images[11];
            //timer_print.Enabled = false;
            bt_Export.Enabled = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_bOpen==1)
            {
                VCI_CloseDevice(m_devtype, m_devind);
            }
        }

        unsafe private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (m_bOpen==1)
            {
                VCI_CloseDevice(m_devtype, m_devind);
                m_bOpen = 0;
                if ("结束保存" == bt_Export.Text) //
                {
                    bt_Export.PerformClick();
                }
            }
            else
            {             
                m_devtype = m_arrdevtype[comboBox_devtype.SelectedIndex];

                m_devind=(UInt32)comboBox_DevIndex.SelectedIndex;
                m_canind = (UInt32)comboBox_CANIndex.SelectedIndex;
                if (VCI_OpenDevice(m_devtype, m_devind, 0) == 0)
                {
                    MessageBox.Show("打开设备失败,请检查设备类型和设备索引号是否正确", "错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //USB-E-U 代码
                UInt32 baud;
                baud = GCanBrTab[comboBox_e_u_baud.SelectedIndex];
                if (VCI_SetReference(m_devtype, m_devind, m_canind, 0,  (byte*)&baud) != STATUS_OK)
                {

                    MessageBox.Show("设置波特率错误，打开设备失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    VCI_CloseDevice(m_devtype, m_devind);
                    return;
                }
                	//滤波设置


                //////////////////////////////////////////////////////////////////////////

                m_bOpen = 1;
                VCI_INIT_CONFIG config=new VCI_INIT_CONFIG();
                config.AccCode=System.Convert.ToUInt32("0x" + textBox_AccCode.Text,16);
                config.AccMask = System.Convert.ToUInt32("0x" + textBox_AccMask.Text, 16);
                config.Timing0 = System.Convert.ToByte("0x" + textBox_Time0.Text, 16);
                config.Timing1 = System.Convert.ToByte("0x" + textBox_Time1.Text, 16);
                config.Filter = (Byte)comboBox_Filter.SelectedIndex;
                config.Mode = (Byte)comboBox_Mode.SelectedIndex;
                VCI_InitCAN(m_devtype, m_devind, m_canind, ref config);

                //////////////////////////////////////////////////////////////////////////
                Int32 filterMode = comboBox_e_u_Filter.SelectedIndex;
                if (2!=filterMode)//不是禁用
                {
                    VCI_FILTER_RECORD filterRecord=new VCI_FILTER_RECORD();
                    filterRecord.ExtFrame = (UInt32)filterMode;
                    filterRecord.Start = System.Convert.ToUInt32("0x" + textBox_e_u_startid.Text, 16);
                    filterRecord.End = System.Convert.ToUInt32("0x" + textBox_e_u_endid.Text, 16);
                    //填充滤波表格
                    VCI_SetReference(m_devtype, m_devind, m_canind, 1, (byte*)&filterRecord);
                    //使滤波表格生效
                    byte tm = 0;
                    if (VCI_SetReference(m_devtype, m_devind, m_canind, 2, &tm) != STATUS_OK)
                    {
                        MessageBox.Show("设置滤波失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        VCI_CloseDevice(m_devtype, m_devind);
                        return;
                    }
                }
                //////////////////////////////////////////////////////////////////////////
            }
            buttonConnect.Text = m_bOpen==1?"断开":"连接";
            timer_rec.Enabled = m_bOpen==1?true:false;
            button_StartCAN.Enabled = true;
        }

        unsafe private void timer_rec_Tick(object sender, EventArgs e)
        {
            UInt32 res = new UInt32();
            res=VCI_GetReceiveNum(m_devtype,m_devind,m_canind);
            if(res==0)
                return;
            //res = VCI_Receive(m_devtype, m_devind, m_canind, ref m_recobj[0],50, 100);

            /////////////////////////////////////
            UInt32 con_maxlen = 50;
            IntPtr pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VCI_CAN_OBJ)) * (Int32)con_maxlen);


            res = VCI_Receive(m_devtype, m_devind, m_canind, pt, con_maxlen, 100);
            ////////////////////////////////////////////////////////

            String str = "";
            //Frame ID
            //string strFrameID = "";
            bool blRun = false;


            for (UInt32 i = 0; i < res; i++)
            {
                VCI_CAN_OBJ obj = (VCI_CAN_OBJ)Marshal.PtrToStructure((IntPtr)((UInt32)pt + i * Marshal.SizeOf(typeof(VCI_CAN_OBJ))), typeof(VCI_CAN_OBJ));

                str = DateTime.Now.ToString("MM/dd HH:mm:ss:fff") + " ";
                str += "  帧ID:0x" + System.Convert.ToString((Int32)obj.ID, 16);
                if ("379" == System.Convert.ToString((Int32)obj.ID, 16))
                {
                    //strFrameID = "0x379";
                    blRun = true;
                }
                else
                {
                    blRun = false;
                }

                str += "  帧格式:";
                if (obj.RemoteFlag == 0)
                    str += "数据帧 ";
                else
                    str += "远程帧 ";
                if (obj.ExternFlag == 0)
                    str += "标准帧 ";
                else
                    str += "扩展帧 ";

                //////////////////////////////////////////
                if (obj.RemoteFlag == 0)
                {
                    str += "数据: ";
                    string strDataPack = "";
                    byte len = (byte)(obj.DataLen % 9);
                    byte j = 0;
                    if (j++ < len)
                        strDataPack += " " + System.Convert.ToString(obj.Data[0], 16);
                    if (j++ < len)
                        strDataPack += " " + System.Convert.ToString(obj.Data[1], 16);
                    if (j++ < len)
                        strDataPack += " " + System.Convert.ToString(obj.Data[2], 16);
                    if (j++ < len)
                        strDataPack += " " + System.Convert.ToString(obj.Data[3], 16);
                    if (j++ < len)
                        strDataPack += " " + System.Convert.ToString(obj.Data[4], 16);
                    if (j++ < len)
                        strDataPack += " " + System.Convert.ToString(obj.Data[5], 16);
                    if (j++ < len)
                        strDataPack += " " + System.Convert.ToString(obj.Data[6], 16);
                    if (j++ < len)
                        strDataPack += " " + System.Convert.ToString(obj.Data[7], 16);
                    str += strDataPack;

                    if (true == blRun)
                    {
                        //textBox1.Text = strFrameID + strDataPack;
                        string[] strDataByte = strDataPack.Trim().Split(' ');
                        int num = strDataByte.Length;
                        string strLightFlash = "0";
                        string strLightNum = "0";
                        string strIsolationNode = "0";
                        int freSystemNumber = 0;   //up or down line
                        
                        if (8 == num)
                        {
                            CanProtocol.get_bits_string(strDataByte[0], 5, 3, ref strLightNum);
                            CanProtocol.get_bits_string(strDataByte[0], 7, 7, ref strLightFlash);
                            CanProtocol.get_bits_string(strDataByte[0], 6, 6, ref strIsolationNode);
                            freSystemNumber = int.Parse(strDataByte[1], System.Globalization.NumberStyles.AllowHexSpecifier);

                            if (1 == Convert.ToInt32(strLightFlash, 2))
                            {
                                if (2 == Convert.ToInt32(strLightNum, 2)) //red and yellow flash
                                {
                                    pictureBox_Light.Image = imageList1.Images[8];
                                }
                                else if(3 == Convert.ToInt32(strLightNum, 2)) //double yellow flash
                                {
                                    pictureBox_Light.Image = imageList1.Images[9];
                                }
                                else if(4 == Convert.ToInt32(strLightNum,2)) //yellow 2 flash
                                {
                                    pictureBox_Light.Image = imageList1.Images[10];
                                }
                            }
                            else
                            {
                                pictureBox_Light.Image = imageList1.Images[Convert.ToInt32(strLightNum, 2)];
                            }

                            if (freSystemNumber == 1 || freSystemNumber == 2 ||
                               freSystemNumber == 5 || freSystemNumber == 6)
                            {
                                rb_DownLine.Checked = true;
                            }
                            else if (freSystemNumber == 3 || freSystemNumber == 4 ||
                                     freSystemNumber == 7 || freSystemNumber == 8)
                            {
                                rb_UpLine.Checked = true;
                            }

                            if (1 == Convert.ToInt32(strIsolationNode, 2))
                            {
                                rb_Gyj.Checked = true;
                            }
                            else
                            {
                                rb_Gyj.Checked = false;
                            }

                        }
                    }

                }
                listBox_Info.Items.Add(str);
                listBox_Info.SelectedIndex = listBox_Info.Items.Count - 1;
                print_Can_Log(str);
            }

            Marshal.FreeHGlobal(pt);
        }


        private void button_StartCAN_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
                return;
            VCI_StartCAN(m_devtype, m_devind, m_canind);
            bt_Export.Enabled = true; //enable export data
            button_StartCAN.Enabled = false;
        }

        private void button_StopCAN_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
                return;
            
            DialogResult dr = MessageBox.Show("重置CAN，Yes or No？", "消息内容", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                VCI_ResetCAN(m_devtype, m_devind, m_canind);
                buttonConnect.PerformClick();
                button_StartCAN.Enabled = true;
            }
            
        }

        unsafe private void button_Send_Click(object sender, EventArgs e)
        {
            if(m_bOpen==0)
                return;

            VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
            //sendobj.Init();
            sendobj.SendType = (byte)comboBox_SendType.SelectedIndex;
            sendobj.RemoteFlag = (byte)comboBox_FrameFormat.SelectedIndex;
            sendobj.ExternFlag = (byte)comboBox_FrameType.SelectedIndex;
            sendobj.ID = System.Convert.ToUInt32("0x"+textBox_ID.Text,16);
            int len = (textBox_Data.Text.Length+1) / 3;
            sendobj.DataLen =System.Convert.ToByte(len);
            String strdata = textBox_Data.Text;
            int i=-1;
            if(i++<len-1)
                sendobj.Data[0]=System.Convert.ToByte("0x" +strdata.Substring(i * 3, 2),16);
            if (i++ < len - 1)
                sendobj.Data[1]=System.Convert.ToByte("0x" +strdata.Substring(i * 3, 2),16);
            if (i++ < len - 1)
                sendobj.Data[2]=System.Convert.ToByte("0x" +strdata.Substring(i * 3, 2),16);
            if (i++ < len - 1)
                sendobj.Data[3]=System.Convert.ToByte("0x" +strdata.Substring(i * 3, 2),16);
            if (i++ < len - 1)
                sendobj.Data[4]=System.Convert.ToByte("0x" +strdata.Substring(i * 3, 2),16);
            if (i++ < len - 1)
                sendobj.Data[5]=System.Convert.ToByte("0x" +strdata.Substring(i * 3, 2),16);
            if (i++ < len - 1)
                sendobj.Data[6]=System.Convert.ToByte("0x" +strdata.Substring(i * 3, 2),16);
            if (i++ < len - 1)
                sendobj.Data[7] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);

            if(VCI_Transmit(m_devtype,m_devind,m_canind,ref sendobj,1)==0)
            {
                MessageBox.Show("发送失败", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private string ChangeToTwoHex(string value)
        {
            string strTemp = value.Trim();
            if (strTemp.Length > 2 || strTemp.Length <= 0)
                return "";
            if (strTemp.Length == 2)
                return value;
            else
                strTemp = '0' + strTemp;
            return strTemp;
        }


        private void listBox_Info_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (false == timer_rec.Enabled)
            {
                string st = listBox_Info.SelectedItem.ToString();

                string pattern1 = @"(?<=帧ID:)(?![\r\n])((?!帧格式).)+";
                string pattern2 = @"标准帧 数据:(.+)";
                string strAddress = "";
                string strHex = "";
                //
                Match mt = Regex.Match(st, pattern1);
                if ("" == mt.Value)
                {
                    MessageBox.Show("获取数据包地址发生错误！");
                    return;
                }
                strAddress = mt.Value.Trim();
                //get protocol data package
                mt = Regex.Match(st, pattern2);
                if ("" == mt.Value)
                {
                    MessageBox.Show("");
                }
                //MessageBox.Show(mt.Value);
                string strData = mt.Value.Trim();
                string[] strNum = strData.Split(new char[] { ' ' });

                int i = 0;
                foreach (string strN in strNum)
                {
                    //MessageBox.Show(strN);
                    if (i >= 2)
                    {
                        strHex += ChangeToTwoHex(strN) + " ";
                    }
                    i++;
                }
                strHex = strHex.Trim();
                //MessageBox.Show(strHex);

                //display translation information of hex number
                string str_output_text = "";
                switch (strAddress.ToLower())
                {
                    case "0x370":
                        textBox1.Text = "对不起，暂不支持此地址解释！";
                        break;
                    case "0x371":
                        textBox1.Text = "对不起，暂不支持此地址解释！";
                        break;
                    case "0x378":
                        CanProtocol.hex0378(strHex, out str_output_text);
                        break;
                    case "0x379":
                        CanProtocol.hex0379(strHex, out str_output_text);
                        break;
                    case "0x37a":
                        CanProtocol.hex037A(strHex, out str_output_text);
                        break;
                    case "0x37b":
                        CanProtocol.hex037B(strHex, out str_output_text);
                        break;
                    default:
                        textBox1.Text = "对不起，不能解释错误地址：" + strAddress + "!";
                        break;
                }
                textBox1.Text = str_output_text;
            }
        }


        //private void listBox_Info_MouseClick(object sender, EventArgs e)
        private void listBox_Info_MouseClick(object sender, EventArgs e)
        {
            string st = "";
            try
            {
                st = listBox_Info.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("你选取的数据为空，无法解释："+ex.ToString());
            }
            //st = "接收到数据:  帧ID:0x37b 帧格式:数据帧 标准帧 数据: 2c 2c ff ff f fb f8 f6"; //test
            //MessageBox.Show(st);

            string pattern1 = @"(?<=帧ID:)(?![\r\n])((?!帧格式).)+";
            string pattern2 = @"标准帧 数据:(.+)";
            string strAddress = "";
            string strHex = "";
            //
            Match mt = Regex.Match(st, pattern1);
            if ("" == mt.Value)
            {
                MessageBox.Show("获取数据包地址发生错误！");
                return;
            }
            strAddress = mt.Value.Trim();
            //get protocol data package
            mt = Regex.Match(st, pattern2);
            if ("" == mt.Value)
            {
                MessageBox.Show("");
            }
            //MessageBox.Show(mt.Value);
            string strData = mt.Value.Trim();
            string[] strNum = strData.Split(new char[] { ' ' });

            int i = 0;
            foreach (string strN in strNum)
            {
                //MessageBox.Show(strN);
                if (i >= 2)
                {
                    strHex += ChangeToTwoHex(strN) + " ";
                }
                i++;
            }
            strHex = strHex.Trim();
            //MessageBox.Show(strHex);

            //display translation information of hex number
            string str_output_text = "";
            switch (strAddress.ToLower())
            {
                case "0x370":
                    MessageBox.Show("对不起，暂不支持此地址解释！");
                    break;
                case "0x371":
                    MessageBox.Show("对不起，暂不支持此地址解释！");
                    break;
                case "0x378":
                    CanProtocol.hex0378(strHex, out str_output_text);
                    break;
                case "0x379":
                    CanProtocol.hex0379(strHex, out str_output_text);
                    break;
                case "0x37a":
                    CanProtocol.hex037A(strHex, out str_output_text);
                    break;
                case "0x37b":
                    CanProtocol.hex037B(strHex, out str_output_text);
                    break;
                default:
                    MessageBox.Show("对不起，不能解释错误地址："+strAddress+"!");
                    break;
            }
            textBox1.Text = str_output_text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ("" == textBox1.Text.Trim())
            {
                MessageBox.Show("数据分析为空，无法保存！");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "文本文件|*.txt|所有文件|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                string filePathName = saveFileDialog.FileName;

                FileStream fs = new FileStream(filePathName, FileMode.Create);
                byte[] data = System.Text.Encoding.Default.GetBytes(textBox1.Text);
                fs.Write(data, 0, data.Length);
                fs.Flush();
                fs.Close();

            }

        }

        private void bt_Clear_Click(object sender, EventArgs e)
        {
            listBox_Info.Items.Clear();
        }

        private void bt_Export_Click(object sender, EventArgs e)
        {
            blRecordData = (blRecordData == false) ? true : false;
            //string str = "";
            if (true == blRecordData)
            {
                

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "所有文件|*.*|文本文件|*.txt";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    sSaveFilePath = saveFileDialog.FileName;
                    bt_Export.Text = "结束保存";

                }
                //timer_print.Enabled = true;
            }
            else
            {
                bt_Export.Text = "开始保存";
                //timer_print.Enabled = false;
                sSaveFilePath = "";
            }
        }//bt_Export_Click

        
        private void print_Can_Log(string str_text)
        {
            if (("" != sSaveFilePath) && (blRecordData == true) )
            {
                FileStream fs = new FileStream(sSaveFilePath, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.WriteLine(str_text);
                sw.Flush();
                sw.Close();
                fs.Close();

            }
        }
        

        /*
        unsafe private void timer_print_Tick(object sender, EventArgs e)
        {
            
            UInt32 res = new UInt32();
            res = VCI_GetReceiveNum(m_devtype, m_devind, m_canind);
            if (res == 0)
                return;
            //res = VCI_Receive(m_devtype, m_devind, m_canind, ref m_recobj[0],50, 100);

            /////////////////////////////////////
            UInt32 con_maxlen = 50;
            IntPtr pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VCI_CAN_OBJ)) * (Int32)con_maxlen);


            res = VCI_Receive(m_devtype, m_devind, m_canind, pt, con_maxlen, 100);
            ////////////////////////////////////////////////////////

            String str = "";
            //Frame ID
            //string strFrameID = "";


            for (UInt32 i = 0; i < res; i++)
            {
                VCI_CAN_OBJ obj = (VCI_CAN_OBJ)Marshal.PtrToStructure((IntPtr)((UInt32)pt + i * Marshal.SizeOf(typeof(VCI_CAN_OBJ))), typeof(VCI_CAN_OBJ));

                str = DateTime.Now.ToString("MM/dd hh:mm:ss:fff") + " ";
                str += "  帧ID:0x" + System.Convert.ToString((Int32)obj.ID, 16);

                str += "  帧格式:";
                if (obj.RemoteFlag == 0)
                    str += "数据帧 ";
                else
                    str += "远程帧 ";
                if (obj.ExternFlag == 0)
                    str += "标准帧 ";
                else
                    str += "扩展帧 ";

                //////////////////////////////////////////
                if (obj.RemoteFlag == 0)
                {
                    str += "数据: ";
                    string strDataPack = "";
                    byte len = (byte)(obj.DataLen % 9);
                    byte j = 0;
                    if (j++ < len)
                        strDataPack += " " + System.Convert.ToString(obj.Data[0], 16);
                    if (j++ < len)
                        strDataPack += " " + System.Convert.ToString(obj.Data[1], 16);
                    if (j++ < len)
                        strDataPack += " " + System.Convert.ToString(obj.Data[2], 16);
                    if (j++ < len)
                        strDataPack += " " + System.Convert.ToString(obj.Data[3], 16);
                    if (j++ < len)
                        strDataPack += " " + System.Convert.ToString(obj.Data[4], 16);
                    if (j++ < len)
                        strDataPack += " " + System.Convert.ToString(obj.Data[5], 16);
                    if (j++ < len)
                        strDataPack += " " + System.Convert.ToString(obj.Data[6], 16);
                    if (j++ < len)
                        strDataPack += " " + System.Convert.ToString(obj.Data[7], 16);
                    str += strDataPack;

                    //textBox1.Text = str;
                    if (("" != sSaveFilePath) && blRecordData)
                    {
                        FileStream fs = new FileStream(sSaveFilePath, FileMode.Append);
                        StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                        sw.WriteLine(str);
                        sw.Flush();
                        sw.Close();
                        fs.Close();

                    }

                }
                //Marshal.FreeHGlobal(pt);
            }
        }
        */

        private void bt_Import_Click(object sender, EventArgs e)
        {
            if ("连接" == buttonConnect.Text)
            {
                listBox_Info.Items.Clear();

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "(*.*)|*.txt";                //Filter file type
                ofd.RestoreDirectory = true; //member old file path
                if (ofd.ShowDialog() == DialogResult.OK)
                {                 
                    StreamReader sr = new StreamReader(ofd.FileName, Encoding.Default);
                    string line = "";
                    //string strText = "";
                    
                    while ((line = sr.ReadLine()) != null)
                    {
                        //strText += line;
                        listBox_Info.Items.Add(line);
                    }
                    
                }

            }
            else
            {
                MessageBox.Show("CAN输出数据时不能导入！");
            }
        }//




    }
}   