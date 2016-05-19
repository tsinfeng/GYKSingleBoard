namespace GYKDataAnalyzer
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_devtype = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBox_e_u_Filter = new System.Windows.Forms.ComboBox();
            this.textBox_e_u_endid = new System.Windows.Forms.TextBox();
            this.textBox_e_u_startid = new System.Windows.Forms.TextBox();
            this.comboBox_e_u_baud = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox_Time1 = new System.Windows.Forms.TextBox();
            this.textBox_AccMask = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_Mode = new System.Windows.Forms.ComboBox();
            this.comboBox_Filter = new System.Windows.Forms.ComboBox();
            this.textBox_Time0 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_AccCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_CANIndex = new System.Windows.Forms.ComboBox();
            this.comboBox_DevIndex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.button_StartCAN = new System.Windows.Forms.Button();
            this.button_StopCAN = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox_FrameFormat = new System.Windows.Forms.ComboBox();
            this.comboBox_FrameType = new System.Windows.Forms.ComboBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_SendType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Data = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bt_Import = new System.Windows.Forms.Button();
            this.bt_Export = new System.Windows.Forms.Button();
            this.bt_Clear = new System.Windows.Forms.Button();
            this.listBox_Info = new System.Windows.Forms.ListBox();
            this.timer_rec = new System.Windows.Forms.Timer(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox_Light = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.rb_UpLine = new System.Windows.Forms.RadioButton();
            this.rb_DownLine = new System.Windows.Forms.RadioButton();
            this.rb_Gyj = new System.Windows.Forms.RadioButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Light)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_devtype);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.comboBox_CANIndex);
            this.groupBox1.Controls.Add(this.comboBox_DevIndex);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 181);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备参数";
            // 
            // comboBox_devtype
            // 
            this.comboBox_devtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_devtype.FormattingEnabled = true;
            this.comboBox_devtype.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.comboBox_devtype.Location = new System.Drawing.Point(49, 24);
            this.comboBox_devtype.MaxDropDownItems = 15;
            this.comboBox_devtype.Name = "comboBox_devtype";
            this.comboBox_devtype.Size = new System.Drawing.Size(121, 21);
            this.comboBox_devtype.TabIndex = 7;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(34, 13);
            this.label18.TabIndex = 6;
            this.label18.Text = "类型:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.textBox_Time1);
            this.groupBox2.Controls.Add(this.textBox_AccMask);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.comboBox_Mode);
            this.groupBox2.Controls.Add(this.comboBox_Filter);
            this.groupBox2.Controls.Add(this.textBox_Time0);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_AccCode);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(10, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 117);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "初始化CAN参数";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBox_e_u_Filter);
            this.groupBox5.Controls.Add(this.textBox_e_u_endid);
            this.groupBox5.Controls.Add(this.textBox_e_u_startid);
            this.groupBox5.Controls.Add(this.comboBox_e_u_baud);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Location = new System.Drawing.Point(7, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(392, 88);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "-E-U Set";
            // 
            // comboBox_e_u_Filter
            // 
            this.comboBox_e_u_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_e_u_Filter.FormattingEnabled = true;
            this.comboBox_e_u_Filter.Items.AddRange(new object[] {
            "标准帧滤波",
            "扩展帧滤波",
            "禁能滤波"});
            this.comboBox_e_u_Filter.Location = new System.Drawing.Point(265, 22);
            this.comboBox_e_u_Filter.Name = "comboBox_e_u_Filter";
            this.comboBox_e_u_Filter.Size = new System.Drawing.Size(121, 21);
            this.comboBox_e_u_Filter.TabIndex = 2;
            // 
            // textBox_e_u_endid
            // 
            this.textBox_e_u_endid.Location = new System.Drawing.Point(321, 51);
            this.textBox_e_u_endid.Name = "textBox_e_u_endid";
            this.textBox_e_u_endid.Size = new System.Drawing.Size(65, 20);
            this.textBox_e_u_endid.TabIndex = 1;
            this.textBox_e_u_endid.Text = "fff";
            // 
            // textBox_e_u_startid
            // 
            this.textBox_e_u_startid.Location = new System.Drawing.Point(133, 51);
            this.textBox_e_u_startid.Name = "textBox_e_u_startid";
            this.textBox_e_u_startid.Size = new System.Drawing.Size(57, 20);
            this.textBox_e_u_startid.TabIndex = 1;
            this.textBox_e_u_startid.Text = "1";
            // 
            // comboBox_e_u_baud
            // 
            this.comboBox_e_u_baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_e_u_baud.FormattingEnabled = true;
            this.comboBox_e_u_baud.Items.AddRange(new object[] {
            "0x060003--1000Kbps",
            "0x060004--800Kbps",
            "0x060007--500Kbps",
            "0x1C0008--250Kbps",
            "0x1C0011--125Kbps",
            "0x160023--100Kbps",
            "0x1C002C--50Kbps",
            "0x1600B3--20Kbps",
            "0x1C00E0--10Kbps",
            "0x1C01C1--5Kbps\t"});
            this.comboBox_e_u_baud.Location = new System.Drawing.Point(70, 22);
            this.comboBox_e_u_baud.Name = "comboBox_e_u_baud";
            this.comboBox_e_u_baud.Size = new System.Drawing.Size(120, 21);
            this.comboBox_e_u_baud.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "波特率";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "滤波范围起始帧ID: 0x";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(196, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "滤波范围结束帧ID: 0x";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(196, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "滤波方式:";
            // 
            // textBox_Time1
            // 
            this.textBox_Time1.Location = new System.Drawing.Point(218, 50);
            this.textBox_Time1.Name = "textBox_Time1";
            this.textBox_Time1.Size = new System.Drawing.Size(28, 20);
            this.textBox_Time1.TabIndex = 1;
            this.textBox_Time1.Visible = false;
            // 
            // textBox_AccMask
            // 
            this.textBox_AccMask.Location = new System.Drawing.Point(74, 50);
            this.textBox_AccMask.Name = "textBox_AccMask";
            this.textBox_AccMask.Size = new System.Drawing.Size(70, 20);
            this.textBox_AccMask.TabIndex = 1;
            this.textBox_AccMask.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(152, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "定时器1:0x";
            this.label6.Visible = false;
            // 
            // comboBox_Mode
            // 
            this.comboBox_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Mode.FormattingEnabled = true;
            this.comboBox_Mode.Items.AddRange(new object[] {
            "正常",
            "只听"});
            this.comboBox_Mode.Location = new System.Drawing.Point(317, 52);
            this.comboBox_Mode.Name = "comboBox_Mode";
            this.comboBox_Mode.Size = new System.Drawing.Size(70, 21);
            this.comboBox_Mode.TabIndex = 1;
            this.comboBox_Mode.Visible = false;
            // 
            // comboBox_Filter
            // 
            this.comboBox_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Filter.FormattingEnabled = true;
            this.comboBox_Filter.Items.AddRange(new object[] {
            "双滤波",
            "单滤波"});
            this.comboBox_Filter.Location = new System.Drawing.Point(317, 23);
            this.comboBox_Filter.Name = "comboBox_Filter";
            this.comboBox_Filter.Size = new System.Drawing.Size(70, 21);
            this.comboBox_Filter.TabIndex = 1;
            this.comboBox_Filter.Visible = false;
            // 
            // textBox_Time0
            // 
            this.textBox_Time0.Location = new System.Drawing.Point(218, 21);
            this.textBox_Time0.Name = "textBox_Time0";
            this.textBox_Time0.Size = new System.Drawing.Size(28, 20);
            this.textBox_Time0.TabIndex = 1;
            this.textBox_Time0.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(280, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "模式:";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(256, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "滤波方式:";
            this.label7.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "屏蔽码:0x";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "定时器0:0x";
            this.label4.Visible = false;
            // 
            // textBox_AccCode
            // 
            this.textBox_AccCode.Location = new System.Drawing.Point(74, 21);
            this.textBox_AccCode.Name = "textBox_AccCode";
            this.textBox_AccCode.Size = new System.Drawing.Size(70, 20);
            this.textBox_AccCode.TabIndex = 1;
            this.textBox_AccCode.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "验收码:0x";
            this.label3.Visible = false;
            // 
            // comboBox_CANIndex
            // 
            this.comboBox_CANIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CANIndex.FormattingEnabled = true;
            this.comboBox_CANIndex.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_CANIndex.Location = new System.Drawing.Point(367, 25);
            this.comboBox_CANIndex.Name = "comboBox_CANIndex";
            this.comboBox_CANIndex.Size = new System.Drawing.Size(42, 21);
            this.comboBox_CANIndex.TabIndex = 1;
            // 
            // comboBox_DevIndex
            // 
            this.comboBox_DevIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DevIndex.FormattingEnabled = true;
            this.comboBox_DevIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.comboBox_DevIndex.Location = new System.Drawing.Point(231, 25);
            this.comboBox_DevIndex.Name = "comboBox_DevIndex";
            this.comboBox_DevIndex.Size = new System.Drawing.Size(41, 21);
            this.comboBox_DevIndex.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "第几路CAN:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "索引号:";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(462, 21);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 25);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "连接";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // button_StartCAN
            // 
            this.button_StartCAN.Location = new System.Drawing.Point(462, 66);
            this.button_StartCAN.Name = "button_StartCAN";
            this.button_StartCAN.Size = new System.Drawing.Size(75, 25);
            this.button_StartCAN.TabIndex = 5;
            this.button_StartCAN.Text = "启动CAN";
            this.button_StartCAN.UseVisualStyleBackColor = true;
            this.button_StartCAN.Click += new System.EventHandler(this.button_StartCAN_Click);
            // 
            // button_StopCAN
            // 
            this.button_StopCAN.Location = new System.Drawing.Point(462, 112);
            this.button_StopCAN.Name = "button_StopCAN";
            this.button_StopCAN.Size = new System.Drawing.Size(75, 25);
            this.button_StopCAN.TabIndex = 5;
            this.button_StopCAN.Text = "复位CAN";
            this.button_StopCAN.UseVisualStyleBackColor = true;
            this.button_StopCAN.Click += new System.EventHandler(this.button_StopCAN_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox_FrameFormat);
            this.groupBox3.Controls.Add(this.comboBox_FrameType);
            this.groupBox3.Controls.Add(this.button_Send);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.comboBox_SendType);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBox_Data);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.textBox_ID);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(12, 200);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(542, 88);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送数据帧";
            // 
            // comboBox_FrameFormat
            // 
            this.comboBox_FrameFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FrameFormat.FormattingEnabled = true;
            this.comboBox_FrameFormat.Items.AddRange(new object[] {
            "数据帧",
            "远程帧"});
            this.comboBox_FrameFormat.Location = new System.Drawing.Point(324, 21);
            this.comboBox_FrameFormat.Name = "comboBox_FrameFormat";
            this.comboBox_FrameFormat.Size = new System.Drawing.Size(70, 21);
            this.comboBox_FrameFormat.TabIndex = 1;
            // 
            // comboBox_FrameType
            // 
            this.comboBox_FrameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FrameType.FormattingEnabled = true;
            this.comboBox_FrameType.Items.AddRange(new object[] {
            "标准帧",
            "扩展帧"});
            this.comboBox_FrameType.Location = new System.Drawing.Point(197, 22);
            this.comboBox_FrameType.Name = "comboBox_FrameType";
            this.comboBox_FrameType.Size = new System.Drawing.Size(70, 21);
            this.comboBox_FrameType.TabIndex = 1;
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(325, 51);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(75, 25);
            this.button_Send.TabIndex = 5;
            this.button_Send.Text = "发送";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(275, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "帧格式:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(148, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "帧类型:";
            // 
            // comboBox_SendType
            // 
            this.comboBox_SendType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SendType.FormattingEnabled = true;
            this.comboBox_SendType.Items.AddRange(new object[] {
            "正常发送",
            "单次正常发送",
            "自发自收",
            "单次自发自收"});
            this.comboBox_SendType.Location = new System.Drawing.Point(71, 22);
            this.comboBox_SendType.Name = "comboBox_SendType";
            this.comboBox_SendType.Size = new System.Drawing.Size(70, 21);
            this.comboBox_SendType.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "发送格式:";
            // 
            // textBox_Data
            // 
            this.textBox_Data.Location = new System.Drawing.Point(56, 52);
            this.textBox_Data.Name = "textBox_Data";
            this.textBox_Data.Size = new System.Drawing.Size(251, 20);
            this.textBox_Data.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "数据:";
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(450, 20);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(70, 20);
            this.textBox_ID.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(400, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "帧ID:0x";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bt_Import);
            this.groupBox4.Controls.Add(this.bt_Export);
            this.groupBox4.Controls.Add(this.bt_Clear);
            this.groupBox4.Controls.Add(this.listBox_Info);
            this.groupBox4.Location = new System.Drawing.Point(9, 200);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(548, 491);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "信息";
            // 
            // bt_Import
            // 
            this.bt_Import.Location = new System.Drawing.Point(175, 16);
            this.bt_Import.Name = "bt_Import";
            this.bt_Import.Size = new System.Drawing.Size(75, 25);
            this.bt_Import.TabIndex = 3;
            this.bt_Import.Text = "导入数据";
            this.bt_Import.UseVisualStyleBackColor = true;
            this.bt_Import.Click += new System.EventHandler(this.bt_Import_Click);
            // 
            // bt_Export
            // 
            this.bt_Export.Location = new System.Drawing.Point(61, 16);
            this.bt_Export.Name = "bt_Export";
            this.bt_Export.Size = new System.Drawing.Size(75, 25);
            this.bt_Export.TabIndex = 2;
            this.bt_Export.Text = "开始保存";
            this.bt_Export.UseVisualStyleBackColor = true;
            this.bt_Export.Click += new System.EventHandler(this.bt_Export_Click);
            // 
            // bt_Clear
            // 
            this.bt_Clear.Location = new System.Drawing.Point(433, 16);
            this.bt_Clear.Name = "bt_Clear";
            this.bt_Clear.Size = new System.Drawing.Size(75, 25);
            this.bt_Clear.TabIndex = 1;
            this.bt_Clear.Text = "清除";
            this.bt_Clear.UseVisualStyleBackColor = true;
            this.bt_Clear.Click += new System.EventHandler(this.bt_Clear_Click);
            // 
            // listBox_Info
            // 
            this.listBox_Info.FormattingEnabled = true;
            this.listBox_Info.Location = new System.Drawing.Point(10, 48);
            this.listBox_Info.Name = "listBox_Info";
            this.listBox_Info.Size = new System.Drawing.Size(532, 433);
            this.listBox_Info.TabIndex = 0;
            this.listBox_Info.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_Info_MouseClick);
            this.listBox_Info.SelectedIndexChanged += new System.EventHandler(this.listBox_Info_SelectedIndexChanged);
            // 
            // timer_rec
            // 
            this.timer_rec.Tick += new System.EventHandler(this.timer_rec_Tick);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(567, 49);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 9;
            this.label19.Text = "数据分析：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(564, 67);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(445, 614);
            this.textBox1.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(462, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 11;
            this.button1.Text = "保存分析";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox_Light
            // 
            this.pictureBox_Light.Location = new System.Drawing.Point(678, 4);
            this.pictureBox_Light.Name = "pictureBox_Light";
            this.pictureBox_Light.Size = new System.Drawing.Size(40, 43);
            this.pictureBox_Light.TabIndex = 12;
            this.pictureBox_Light.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(615, 21);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 13);
            this.label20.TabIndex = 13;
            this.label20.Text = "指示灯：";
            // 
            // rb_UpLine
            // 
            this.rb_UpLine.AutoSize = true;
            this.rb_UpLine.Location = new System.Drawing.Point(754, 4);
            this.rb_UpLine.Name = "rb_UpLine";
            this.rb_UpLine.Size = new System.Drawing.Size(49, 17);
            this.rb_UpLine.TabIndex = 14;
            this.rb_UpLine.TabStop = true;
            this.rb_UpLine.Text = "上行";
            this.rb_UpLine.UseVisualStyleBackColor = true;
            // 
            // rb_DownLine
            // 
            this.rb_DownLine.AutoSize = true;
            this.rb_DownLine.Location = new System.Drawing.Point(754, 29);
            this.rb_DownLine.Name = "rb_DownLine";
            this.rb_DownLine.Size = new System.Drawing.Size(49, 17);
            this.rb_DownLine.TabIndex = 15;
            this.rb_DownLine.TabStop = true;
            this.rb_DownLine.Text = "下行";
            this.rb_DownLine.UseVisualStyleBackColor = true;
            // 
            // rb_Gyj
            // 
            this.rb_Gyj.AutoSize = true;
            this.rb_Gyj.Location = new System.Drawing.Point(16, 13);
            this.rb_Gyj.Name = "rb_Gyj";
            this.rb_Gyj.Size = new System.Drawing.Size(73, 17);
            this.rb_Gyj.TabIndex = 16;
            this.rb_Gyj.TabStop = true;
            this.rb_Gyj.Text = "过绝缘节";
            this.rb_Gyj.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "B.bmp");
            this.imageList1.Images.SetKeyName(1, "H.bmp");
            this.imageList1.Images.SetKeyName(2, "HU.bmp");
            this.imageList1.Images.SetKeyName(3, "UU.bmp");
            this.imageList1.Images.SetKeyName(4, "U2.bmp");
            this.imageList1.Images.SetKeyName(5, "U.bmp");
            this.imageList1.Images.SetKeyName(6, "LU.bmp");
            this.imageList1.Images.SetKeyName(7, "L.bmp");
            this.imageList1.Images.SetKeyName(8, "HUS.bmp");
            this.imageList1.Images.SetKeyName(9, "UUS.bmp");
            this.imageList1.Images.SetKeyName(10, "U2S.bmp");
            this.imageList1.Images.SetKeyName(11, "M.bmp");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rb_Gyj);
            this.panel1.Location = new System.Drawing.Point(834, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(108, 42);
            this.panel1.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 698);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rb_DownLine);
            this.Controls.Add(this.rb_UpLine);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.pictureBox_Light);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button_StopCAN);
            this.Controls.Add(this.button_StartCAN);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "解码核心板协议分析";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Light)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.ComboBox comboBox_CANIndex;
        private System.Windows.Forms.ComboBox comboBox_DevIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Time1;
        private System.Windows.Forms.TextBox textBox_AccMask;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Time0;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_AccCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Mode;
        private System.Windows.Forms.ComboBox comboBox_Filter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_StartCAN;
        private System.Windows.Forms.Button button_StopCAN;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox_FrameFormat;
        private System.Windows.Forms.ComboBox comboBox_FrameType;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox_SendType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_Data;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBox_Info;
        private System.Windows.Forms.Timer timer_rec;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBox_e_u_baud;
        private System.Windows.Forms.ComboBox comboBox_e_u_Filter;
        private System.Windows.Forms.TextBox textBox_e_u_endid;
        private System.Windows.Forms.TextBox textBox_e_u_startid;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBox_devtype;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox_Light;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.RadioButton rb_UpLine;
        private System.Windows.Forms.RadioButton rb_DownLine;
        private System.Windows.Forms.RadioButton rb_Gyj;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_Clear;
        private System.Windows.Forms.Button bt_Import;
        private System.Windows.Forms.Button bt_Export;
    }
}

