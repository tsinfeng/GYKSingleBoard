using System;
using System.Collections.Generic;
using System.Text;

namespace GYKDataAnalyzer
{
    class CanProtocol
    {
        private static string HexToBin(string strEncode)
        {
            int status_num = int.Parse(strEncode, System.Globalization.NumberStyles.AllowHexSpecifier);
            string binary_str = "";//  存储转换后的编码
            binary_str = Convert.ToString(status_num, 2);

            return binary_str;
        }

        //-1 CAN数据有有误
        public static int hex0378(string txt, out string txt_output)
        {
            string resultText = "";
            resultText = "帧地址：0x0378 属于机车信号发送的自检信息";
            resultText = resultText + "帧数据：" + txt.Trim();
            int num = 0;
            string[] data_byte = txt.Trim().Split(' ');
            num = data_byte.Length;
            if (8 != num)
            {
                //MessageBox.Show("CAN数据有有误，请检查！");
                txt_output = "";
                return -1;
            }

            string error_sign = "\r\n\r\n" + "错误标志：";
            error_sign = error_sign + " " + data_byte[0] + " " + data_byte[1];
            resultText += error_sign;

            string str_status = "";
            str_status = data_byte[2];
            //MessageBox.Show(HexToBin(str_status));
            int can_diff_num = 0;
            string can_diff_str = "";
            int can_noget_num = 0;
            string can_noget_str = "";
            int i = 0;
            foreach (char chr in HexToBin(str_status).ToCharArray())
            {
                if (i < 3)
                {
                    can_diff_str += chr;
                }
                else
                {
                    can_noget_str += chr;
                }
                i++;
            }
            can_diff_num = Convert.ToInt32(can_diff_str, 2);
            if ("" != can_noget_str)
            {
                can_noget_num = Convert.ToInt32(can_noget_str, 2);
            }
            //MessageBox.Show(can_diff_num.ToString() + "; " + can_noget_num.ToString());
            resultText += "\r\n\r\n" + "CAN通信状态:  CAN总线发送来的数据，前后2次数据不一致计数：" + can_diff_num.ToString();
            resultText += "\r\n\r\n" + "CAN通信状态:  CAN总线每400ms未收到从GKJ发送来的数据计数：" + can_noget_num.ToString();


            //断线检查的幅度
            int ampl = int.Parse(data_byte[3], System.Globalization.NumberStyles.AllowHexSpecifier);
            int display_val = ampl / 2;
            resultText += "\r\n\r\n" + "断线检查的幅度：" + display_val.ToString() + " " + "实际值：" + data_byte[3];

            //控制信息
            //int d7 为 ctl_char[0]
            //int ampl = int.Parse(data_byte[4], System.Globalization.NumberStyles.AllowHexSpecifier);
            char[] ctl_char = HexToBin(data_byte[4]).ToCharArray();
            resultText += "\r\n\r\n" + "控制信息:  显示值:" + data_byte[4] + " " + "D7的值：" + ctl_char[0].ToString();

            //版本号：
            int iYear = 2000;
            int iMonth = 0;
            int iDay = 0;
            iDay += int.Parse(data_byte[5], System.Globalization.NumberStyles.AllowHexSpecifier);
            iMonth += int.Parse(data_byte[6], System.Globalization.NumberStyles.AllowHexSpecifier);
            iYear += int.Parse(data_byte[7], System.Globalization.NumberStyles.AllowHexSpecifier);
            resultText += "\r\n\r\n" + "版本号：" + data_byte[5] + " " + data_byte[6] + " " + data_byte[7] + " " +
                iYear.ToString() + "年" + iMonth.ToString() + "月" + iDay.ToString() + "日";

            txt_output = resultText;
            return 0;
        }
        public static int hex037B(string txt, out string str_output)
        {
            string resultText = "";
            resultText = "帧地址：0x037B 属于机车信号发送的自检信息 ";
            resultText = resultText + "帧数据：" + txt.Trim();
            int num = 0;
            string[] data_byte = txt.Trim().Split(' ');
            num = data_byte.Length;
            if (8 != num)
            {
                //MessageBox.Show("CAN数据有有误，请检查！");
                str_output = "";
                return -1;
            }

            //低频编码
            string lowFreCode = "\r\n\r\n" + "低频载频编码：";
            lowFreCode = lowFreCode + " " + data_byte[0] + " " + data_byte[1];
            resultText += lowFreCode;

            //信号载频数值
            string strFre = "";
            strFre += data_byte[2] + data_byte[3];
            float iOrgnFre = int.Parse(strFre, System.Globalization.NumberStyles.AllowHexSpecifier);
            float flFre = iOrgnFre / 10;
            resultText += "\r\n\r\n" + "信号载频数值：" + flFre.ToString() + "Hz";

            //信号低频数值
            string strLowFre = "";
            strLowFre += data_byte[4] + data_byte[5];
            float iOrgnLowFre = int.Parse(strLowFre, System.Globalization.NumberStyles.AllowHexSpecifier);
            float flLowFre = iOrgnLowFre / 10;
            resultText += "\r\n\r\n" + "信号低频数值：" + flLowFre.ToString() + "Hz";

            //信号幅度数值
            string strAmpl = "";
            strAmpl += data_byte[6] + data_byte[7];
            float iOrgnAmpl = int.Parse(strAmpl, System.Globalization.NumberStyles.AllowHexSpecifier);
            float flAmpl = iOrgnAmpl / 10;
            resultText += "\r\n\r\n" + "信号幅度数值：" + flAmpl.ToString() + "mV";
            str_output = resultText;
            return 0;
        }

        public static bool get_bits_string(string strHex, int high_bit, int low_bit, ref string str_value) //D7-D1
        {
            //int iTotalValue = int.Parse(strHex, System.Globalization.NumberStyles.AllowHexSpecifier);
            char[] chBin = HexToBin(strHex).ToCharArray();
            char[] chArr = new char[8];
            string strPart = "";
            int i;
            for (i = 0; i < 8; i++)
            {
                chArr[i] = '0';
            }
            i = 0;
            foreach (char chr in chBin)
            {
                i++;
                //MessageBox.Show(chr.ToString());
            }
            int j;
            int k = 0;
            for (j = 8 - i; j < 8; j++)
            {
                chArr[j] = chBin[k];
                k++;
            }
            string strBin = new string(chArr);
            //MessageBox.Show(strBin);
            for (i = System.Math.Abs(high_bit - 7); i <= System.Math.Abs(low_bit - 7); i++)
            {
                strPart += chArr[i];
            }
            str_value = strPart;

            return true;
        }
        public static int hex0379(string txt, out string str_output)
        {
            string[] strLightColour = { "B灯", "H灯", "HU灯", "UU灯", "U2灯", "U灯", "LU灯", "L灯" };
            string[] FreSystemInfo = {"制式不明",
                                      "移频550Hz", "移频750Hz", "移频650Hz", "移频850Hz",
                                      "UM71:1700Hz", "UM71:2300Hz", "UM71:2000Hz", "UM71:2600Hz",
                                      "交流计数 25/75Hz(A)", "交流计数 25/75Hz(B)", "交流计数 50Hz(A)", "交流计数 50Hz(B)",
                                      "极频",
                                      "其它","其它"};
            string[] strFreShift = {"7", "8", "8.5", "9",
                                    "9.5", "11", "12.5", "13.5",
                                    "15", "16.5", "17.5", "18.5",
                                    "20", "21.5", "22.5", "23.5",
                                    "24.5", "26", "空1", "空2",
                                    "无码B", "无码H"};
            string[] strUM71 = {"10.3", "11.4", "12.5", "13.6",
                                      "14.7", "15.8", "16.9", "18.0",
                                      "19.1", "20.2", "21.3", "22.4",
                                      "23.5", "24.6", "25.7", "26.8",
                                      "27.9", "29.0", "空1", "空2",
                                      "无码B", "无码H"};
            string[] strACCounting = {"绿码", "绿黄码", "黄码", "双黄码",
                                    "红黄码", "绿码", "绿黄码", "黄码",
                                    "双黄码", "红黄码", "6", "7",
                                    "8", "9", "10", "11",
                                    "12", "13", "14", "15",
                                    "无码B", "无码H"};
            string[] strPolarfre = {"双正码", "单正码", "双负码", "单负码",
                                    "无脉冲", "空1", "空2", "空3",
                                    "空4", "空5", "空6", "空7",
                                    "空8", "空9", "空10", "空11",
                                    "空12", "空13", "空14", "空15",
                                    "空16", "空17"};

            string resultText = "";
            resultText = "帧地址：0x0379 机车信号插件发送的自检信息 ";
            resultText = resultText + "帧数据：" + txt.Trim();
            int num = 0;
            string[] data_byte = txt.Trim().Split(' ');
            num = data_byte.Length;
            if (8 != num)
            {
                //MessageBox.Show("CAN数据有有误，请检查！");
                str_output = "";
                return -1;
            }

            //灯位信息
            string strLightFlash = "";
            string strChangeStatus = "";
            string strLight = "";
            string strSpeedCode = "";
            get_bits_string(data_byte[0], 7, 7, ref strLightFlash);
            get_bits_string(data_byte[0], 6, 6, ref strChangeStatus);
            get_bits_string(data_byte[0], 5, 3, ref strLight);
            get_bits_string(data_byte[0], 2, 0, ref strSpeedCode);
            int i;
            i = Convert.ToInt32(strLight, 2);
            resultText += "\r\n\r\n" + "灯位信息：" + strLightColour[i];
            if (1 == int.Parse(strLightFlash))
            {
                resultText += "\r\n\r\n" + "灯位信息：" + "闪灯状态";
            }
            else
            {
                resultText += "\r\n\r\n" + "灯位信息：" + "非闪灯状态";
            }
            resultText += "\r\n\r\n" + "绝缘节：上升沿或下降沿（状态变化）过绝缘，D6=" + strChangeStatus;
            resultText += "\r\n\r\n" + "速度码：" + strSpeedCode;

            //制式信息
            int iFreSystemIndex = 0;
            i = int.Parse(data_byte[1], System.Globalization.NumberStyles.AllowHexSpecifier);
            iFreSystemIndex = i;
            resultText += "\r\n\r\n" + "制式信息：" + FreSystemInfo[i];

            //低频信息
            string LowFreD7 = "";
            string LowFreBin = "";
            get_bits_string(data_byte[2], 7, 7, ref LowFreD7);
            if (1 == int.Parse(LowFreD7))
            {
                resultText += "\r\n\r\n" + "低频信息：" + "接收25.7Hz自主锁频的上下行";
            }
            else
            {
                resultText += "\r\n\r\n" + "低频信息：" + "未接收25.7Hz自主锁频的上下行";
            }
            get_bits_string(data_byte[2], 6, 0, ref LowFreBin);
            i = Convert.ToInt32(LowFreBin, 2) - 1;
            if (-1 == i)
            {

                resultText += "\r\n\r\n" + "低频信息：" + "移频无码0" + " " + "UM71无码0" + " " +
                                                    "交流计数无码0" + " " + "极频无码0";
            }
            else if (i >= 0 && i <= 21) //LowFre 1-22
            {
                switch (iFreSystemIndex)
                {
                    case 0:
                        resultText += "\r\n\r\n" + "低频信息：" + "移频" + strFreShift[i] + " " + "UM71" + strUM71[i] + " " +
                                                   "交流计数" + strACCounting[i] + " " + "极频" + strPolarfre[i];
                        break;
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        resultText += "\r\n\r\n" + "低频信息：" + "移频" + strFreShift[i];
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        resultText += "\r\n\r\n" + "低频信息：" + "UM71 " + strUM71[i];
                        break;
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                        resultText += "\r\n\r\n" + "低频信息：" + "交流计数" + strACCounting[i];
                        break;
                    case 13:
                        resultText += "\r\n\r\n" + "低频信息：" + "极频" + strPolarfre[i];
                        break;
                    default:
                        resultText += "\r\n\r\n" + "低频信息：" + "移频" + strFreShift[i] + " " + "UM71" + strUM71[i] + " " +
                                                   "交流计数" + strACCounting[i] + " " + "极频" + strPolarfre[i];
                        break;
                }
            }
            else
            {
                resultText += "\r\n\r\n" + "低频信息：" + "移频乱码" + i.ToString() + " " + "UM71乱码" + i.ToString() + " " +
                                                        "交流计数乱码" + i.ToString() + " " + "极频乱码" + i.ToString();
            }

            //运行状态0
            string strLookDev = "";
            string strLooking = "";
            string strSelectSys = "";
            string strLookDevSlectState = "";
            get_bits_string(data_byte[3], 7, 7, ref strLookDev);
            get_bits_string(data_byte[3], 6, 5, ref strLooking);
            get_bits_string(data_byte[3], 4, 4, ref strSelectSys);
            get_bits_string(data_byte[3], 3, 2, ref strLookDevSlectState);
            if (1 == int.Parse(strLookDev))
            {
                resultText += "\r\n\r\n" + "运行状态0：" + "上下行来自监控装置 有效" + strLookDev;
            }
            else
            {
                resultText += "\r\n\r\n" + "运行状态0：" + "上下行来自监控装置 无效" + strLookDev;
            }

            if (0 == int.Parse(strLooking))
            {
                resultText += "\r\n\r\n" + "运行状态0：" + "表示监控要求的上下行 按下行开关接收" + strLooking;
            }
            else if (1 == int.Parse(strLooking))
            {
                resultText += "\r\n\r\n" + "运行状态0：" + "表示监控要求的上下行 表示强制下行" + strLooking;
            }
            else if (2 == int.Parse(strLooking))
            {
                resultText += "\r\n\r\n" + "运行状态0：" + "表示监控要求的上下行 表示强制上行" + strLooking;
            }
            else if (3 == int.Parse(strLooking))
            {
                resultText += "\r\n\r\n" + "运行状态0：" + "表示监控要求的上下行 表示无效（非法）" + strLooking;
            }

            if (1 == int.Parse(strSelectSys))
            {
                resultText += "\r\n\r\n" + "运行状态0：" + "选择制式来自监控装置 有效" + strSelectSys;
            }
            else
            {
                resultText += "\r\n\r\n" + "运行状态0：" + "选择制式来自监控装置 无效" + strSelectSys;
            }

            if (0 == int.Parse(strLookDevSlectState))
            {
                resultText += "\r\n\r\n" + "运行状态0：" + "监控装置要求的制式选择 按照设置线进行接收 " + strLookDevSlectState;
            }
            else if (1 == int.Parse(strLookDevSlectState))
            {
                resultText += "\r\n\r\n" + "运行状态0：" + "监控装置要求的制式选择 按照强制进行接收 " + strLookDevSlectState;
            }
            else
            {
                resultText += "\r\n\r\n" + "运行状态0：" + "监控装置要求的制式选择 无效 " + strLookDevSlectState;
            }

            //运行状态1
            string strJZGF = "";
            string strJ25_50 = "";
            string strRun1D1 = "";
            string strRun1D0 = "";
            get_bits_string(data_byte[4], 7, 4, ref strJZGF);
            get_bits_string(data_byte[4], 3, 2, ref strJ25_50);
            get_bits_string(data_byte[4], 1, 1, ref strRun1D1);
            get_bits_string(data_byte[4], 0, 0, ref strRun1D0);
            resultText += "\r\n\r\n" + "运行状态1：J Z G F设置线状态：" + strJZGF + " （1表示设置）";
            resultText += "\r\n\r\n" + "运行状态1：JL25、JL50设置线状态：" + strJ25_50 + " （0表示允许接收）";
            if (1 == int.Parse(strRun1D1))
            {
                resultText += "\r\n\r\n" + "运行状态1：上下行开关位置在下行";
            }
            else
            {
                resultText += "\r\n\r\n" + "运行状态1：上下行开关位置在上行";
            }
            if (1 == int.Parse(strRun1D0))
            {
                resultText += "\r\n\r\n" + "运行状态1：按下行接收";
            }
            else
            {
                resultText += "\r\n\r\n" + "运行状态1：按上行接收";
            }

            //运行状态2
            string strCDE = "";
            string strRun2D4 = "";
            string strRun2D3 = "";
            //string strRun2D2 = "";
            string strRun2D10 = "";
            get_bits_string(data_byte[5], 7, 5, ref strCDE);
            get_bits_string(data_byte[5], 4, 4, ref strRun2D4);
            get_bits_string(data_byte[5], 3, 3, ref strRun2D3);
            //get_bits_string(data_byte[5], 2, 2, ref strRun2D2);
            get_bits_string(data_byte[5], 1, 0, ref strRun2D10);
            resultText += "\r\n\r\n" + "运行状态2： C D E 设置线状态：" + strCDE + " （1表示设置）";
            resultText += "\r\n\r\n" + "运行状态2： “2”表示电化/非电化选择状态 " + strRun2D4 + " （1表示设置）";
            resultText += "\r\n\r\n" + "运行状态2： “+”表示使能UM2000轨道电路显示输出状态 " + strRun2D3 + " （1表示设置）";
            if (0 == int.Parse(strRun2D10))
            {
                resultText += "\r\n\r\n" + "运行状态2：" + "接收ZPW2000信号时，上下载频都不允许接收 状态值：" + strRun2D10;
            }
            else if (1 == int.Parse(strRun2D10))
            {
                resultText += "\r\n\r\n" + "运行状态2：" + "表示运行接收1700/2000信息 状态值：" + strRun2D10;
            }
            else if (2 == int.Parse(strRun2D10))
            {
                resultText += "\r\n\r\n" + "运行状态2：" + "表示运行接收2300/2600信息 状态值：" + strRun2D10;
            }
            else if (3 == int.Parse(strRun2D10))
            {
                resultText += "\r\n\r\n" + "运行状态2：" + "接收ZPW2000信号时，上下载频都允许接收 状态值：" + strRun2D10;
            }

            //计时信息
            string strTime = "";
            int iTime = 0;
            strTime = data_byte[7] + data_byte[6];
            iTime = int.Parse(strTime, System.Globalization.NumberStyles.AllowHexSpecifier);
            resultText += "\r\n\r\n" + "计时信息：机号识别绝缘点至CAN启动总线发送之间的延时" + iTime.ToString() + "ms";
            //MessageBox.Show(":::::" + strValue);

            str_output = resultText;
            return 0;
        }

        private static string comp_code(string true_code) //求一个byte字符串的反码
        {
            int num = int.Parse(true_code, System.Globalization.NumberStyles.AllowHexSpecifier);
            if (num > 255 || num < 0)
                return "00";
            num = 255 - num;
            return num.ToString("x2");
        }
        public static int hex037A(string txt, out string str_output)
        {
            string resultText = "";
            resultText = "帧地址：0x037A 机车信号插件发送的自检信息 ";
            resultText = resultText + "帧数据：" + txt.Trim();
            int num = 0;
            string[] data_byte = txt.Trim().Split(' ');
            num = data_byte.Length;
            if (8 != num)
            {
                //MessageBox.Show("CAN数据有有误，请检查！");
                str_output = "";
                return -1;
            }

            //int b7 = int.Parse(data_byte[0], System.Globalization.NumberStyles.AllowHexSpecifier);
            //b7 = 255 - b7;
            string strHexValue = comp_code(data_byte[0]);
            resultText += "\r\n\r\n" + "反码数据(与0x379对应)：" + strHexValue;

            strHexValue = comp_code(data_byte[1]);
            resultText += " " + strHexValue;
            strHexValue = comp_code(data_byte[2]);
            resultText += " " + strHexValue;
            strHexValue = comp_code(data_byte[3]);
            resultText += " " + strHexValue;
            strHexValue = comp_code(data_byte[4]);
            resultText += " " + strHexValue;
            strHexValue = comp_code(data_byte[5]);
            resultText += " " + strHexValue;
            strHexValue = comp_code(data_byte[6]);
            resultText += " " + strHexValue;
            strHexValue = comp_code(data_byte[7]);
            resultText += " " + strHexValue;

            //b7 = ~b7;
            str_output = resultText;
            return 0;
        }
    }
}
