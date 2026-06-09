using OpenTK.Graphics.ES10;
using ScottPlot;
using ScottPlot.Plottables;
using System;
using System.Globalization;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Text;

namespace VICTOR4080
{
    public partial class Form1 : Form
    {
        enum VICTOR4080SetItems
        {
            Connect = 0,
            Display = 1,
            Func1   = 2,
            Func2   = 3,
            SerPal  = 4,
            Range   = 5,
            Speed   = 6,
            Freq    = 7,
            Level   = 8,
            Bias    = 9
        }

        private readonly SerialPort _serialPort = new();
        private readonly Queue<string> _rxQueue = new();

        private readonly List<DateTime> _allTime = [];
        private readonly List<double> _valA = [];
        private readonly List<double> _valB = [];

        private Plot _plt;
        private DataLogger _loggerA;
        private DataLogger _loggerB;
        private System.Windows.Forms.Timer _renderTimer;
        private const int ViewMaxPoint = 1000;

        private string lb2Func = "功能: ";
        private string lb2Func1 = "";
        private string lb2Func2 = "";
        private string lb2Func3 = "-";
        private string lb2Func4 = "";

        private string lb3Range = "量程: ";
        private string lb3Range1 = "";

        private string lb4Speed = "速度: ";
        private string lb4Speed1 = "";

        private string lb5Freq = "频率: ";
        private string lb5Freq1 = "";

        private string lb6Level = "电平: ";
        private string lb6Level1 = "";

        private string lb7Bias = "偏置: ";
        private string lb7Bias1 = "";

        public Form1()
        {
            InitializeComponent();

            //Lable
            InitLable();

            //CobomBox
            InitComboBox();

            //Timer
            InitRenderTimer();

            // 初始化绘图
            InitChart();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                SerialPort_DataSend("FETCH?");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(SerialPort.GetPortNames());
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                //关闭串口
                timer1.Enabled = false;
                button1.Enabled = true;
                comboBox1.Enabled = true;
                VICTOR4080_DisConnect();
                _serialPort.Close();
                _serialPort.DataReceived -= SerialPort_DataReceived;
                button2.Text = "连接设备";
                button2.BackColor = System.Drawing.Color.White;
            }
            else
            {
                try
                {
                    //配置串口参数
                    _serialPort.PortName = comboBox1.Text;
                    _serialPort.BaudRate = 115200;
                    _serialPort.DataBits = 8;
                    _serialPort.Parity = Parity.None;
                    _serialPort.StopBits = StopBits.One;
                    _serialPort.Encoding = Encoding.ASCII;
                    _serialPort.DataReceived += SerialPort_DataReceived;

                    //打开串口
                    _serialPort.Open();
                    InitLable();
                    if (VICTOR4080_Connect())
                    {
                        timer1.Enabled = true;
                        button1.Enabled = false;
                        comboBox1.Enabled = false;
                        button2.Text = "关闭连接";
                        button2.BackColor = System.Drawing.Color.LightGreen;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                timer1.Enabled = false;

                if(VICTOR4080_Set(VICTOR4080SetItems.Func1, comboBox2.SelectedIndex))
                {
                    lb2Func1 = comboBox2.Text;

                    ShowSetting();
                }

                timer1.Enabled = true;
            }
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                timer1.Enabled = false;

                if (VICTOR4080_Set(VICTOR4080SetItems.Func2, comboBox3.SelectedIndex))
                {
                    lb2Func4 = comboBox3.Text;

                    ShowSetting();
                }

                timer1.Enabled = true;
            }
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                timer1.Enabled = false;

                if (VICTOR4080_Set(VICTOR4080SetItems.SerPal, comboBox4.SelectedIndex))
                {
                    if (comboBox4.SelectedIndex == 0)
                    {
                        lb2Func2 = "s";
                    }
                    else if (comboBox4.SelectedIndex == 1)
                    {
                        lb2Func2 = "p";
                    }

                    ShowSetting();
                }

                ShowSetting();

                timer1.Enabled = true;
            }
        }

        private void comboBox5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                timer1.Enabled = false;

                if (VICTOR4080_Set(VICTOR4080SetItems.Range, comboBox5.SelectedIndex))
                {
                    lb3Range1 = comboBox5.Text;

                    ShowSetting();
                }

                timer1.Enabled = true;
            }
        }

        private void comboBox6_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                timer1.Enabled = false;

                if (VICTOR4080_Set(VICTOR4080SetItems.Speed, comboBox6.SelectedIndex))
                {
                    if (comboBox6.SelectedIndex == 0)
                    {
                        lb4Speed1 = "慢速";
                        timer1.Interval = 500;
                    }
                    else if (comboBox6.SelectedIndex == 1)
                    {
                        lb4Speed1 = "中速";
                        timer1.Interval = 250;
                    }
                    else if (comboBox6.SelectedIndex == 2)
                    {
                        lb4Speed1 = "快速";
                        timer1.Interval = 125;
                    }

                    ShowSetting();
                }

                timer1.Enabled = true;
            }
        }

        private void comboBox7_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                timer1.Enabled = false;

                if (VICTOR4080_Set(VICTOR4080SetItems.Freq, comboBox7.SelectedIndex))
                {
                    lb5Freq1 = comboBox7.Text;

                    ShowSetting();
                }

                timer1.Enabled = true;
            }
        }

        private void comboBox8_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                timer1.Enabled = false;

                if (VICTOR4080_Set(VICTOR4080SetItems.Level, comboBox8.SelectedIndex))
                {
                    lb6Level1 = comboBox8.Text;

                    ShowSetting();
                }

                timer1.Enabled = true;
            }
        }

        private void comboBox9_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                timer1.Enabled = false;

                if (VICTOR4080_Set(VICTOR4080SetItems.Bias, comboBox9.SelectedIndex))
                {
                    lb7Bias1 = comboBox9.Text;

                    ShowSetting();
                }

                timer1.Enabled = true;
            }
        }

        private bool VICTOR4080_Connect()
        {
            bool res = false;

            res |= VICTOR4080_Set(VICTOR4080SetItems.Connect);

            res |= VICTOR4080_Set(VICTOR4080SetItems.Display);

            if (res)
            {
                comboBox2_SelectionChangeCommitted(this, EventArgs.Empty);
                comboBox3_SelectionChangeCommitted(this, EventArgs.Empty);
                comboBox4_SelectionChangeCommitted(this, EventArgs.Empty);
                comboBox5_SelectionChangeCommitted(this, EventArgs.Empty);
                comboBox6_SelectionChangeCommitted(this, EventArgs.Empty);
                comboBox7_SelectionChangeCommitted(this, EventArgs.Empty);
                comboBox8_SelectionChangeCommitted(this, EventArgs.Empty);
                comboBox9_SelectionChangeCommitted(this, EventArgs.Empty);

                ShowSetting();
            }

            return res;
        }

        private bool VICTOR4080_Set(VICTOR4080SetItems item, int index = 0)
        {
            bool res = false;
            string tx = "", para = "";

            switch (item)
            {
                case VICTOR4080SetItems.Connect:
                    tx = "SYSTEM:";
                    para = "REMOTE";
                    break;
                case VICTOR4080SetItems.Display:
                    tx = "DISPLAY:PAGE ";
                    para = "MEASUREMENT";
                    break;
                case VICTOR4080SetItems.Func1:
                    tx = "FUNCTION:IMPEDANCE:A ";
                    switch (index)
                    {
                        case 0:
                            para = "R";
                            break;
                        case 1:
                            para = "C";
                            break;
                        case 2:
                            para = "L";
                            break;
                        case 3:
                            para = "Z";
                            break;
                        default:
                            break;
                    }
                    break;
                case VICTOR4080SetItems.Func2:
                    tx = "FUNCTION:IMPEDANCE:B ";
                    switch (index)
                    {
                        case 0:
                            para = "X";
                            break;
                        case 1:
                            para = "D";
                            break;
                        case 2:
                            para = "Q";
                            break;
                        case 3:
                            para = "THR";
                            break;
                        case 4:
                            para = "ESR";
                            break;
                        default:
                            break;
                    }
                    break;
                case VICTOR4080SetItems.SerPal:
                    tx = "FUNCTION:IMPEDANCE:EQUIVALENT ";
                    switch (index)
                    {
                        case 0:
                            para = "SERIAL";
                            break;
                        case 1:
                            para = "PALLEL";
                            break;
                        default:
                            break;
                    }
                    break;
                case VICTOR4080SetItems.Range:
                    tx = "FUNCTION:IMPEDANCE:RANGE ";
                    switch (index)
                    {
                        case 0:
                            para = "10";
                            break;
                        case 1:
                            para = "100";
                            break;
                        case 2:
                            para = "1000";
                            break;
                        case 3:
                            para = "10000";
                            break;
                        case 4:
                            para = "100000";
                            break;
                        case 5:
                            para = "1000000";
                            break;
                        case 6:
                            para = "AUTO";
                            break;
                        default:
                            break;
                    }
                    break;
                case VICTOR4080SetItems.Speed:
                    tx = "APERTURE ";
                    switch (index)
                    {
                        case 0:
                            para = "SLOW";
                            break;
                        case 1:
                            para = "MEDIUM";
                            break;
                        case 2:
                            para = "FAST";
                            break;
                        default:
                            break;
                    }
                    break;
                case VICTOR4080SetItems.Freq:
                    tx = "FREQUENCY ";
                    switch (index)
                    {
                        case 0:
                            para = "100";
                            break;
                        case 1:
                            para = "120";
                            break;
                        case 2:
                            para = "1000";
                            break;
                        case 3:
                            para = "10000";
                            break;
                        case 4:
                            para = "40000";
                            break;
                        case 5:
                            para = "100000";
                            break;
                        default:
                            break;
                    }
                    break;
                case VICTOR4080SetItems.Level:
                    tx = "VOLTAGE ";
                    switch (index)
                    {
                        case 0:
                            para = "300";
                            break;
                        case 1:
                            para = "600";
                            break;
                        case 2:
                            para = "1000";
                            break;
                        default:
                            break;
                    }
                    break;
                case VICTOR4080SetItems.Bias:
                    tx = "BIAS:VOLTAGE ";
                    switch (index)
                    {
                        case 0:
                            para = "0";
                            break;
                        case 1:
                            para = "100";
                            break;
                        case 2:
                            para = "300";
                            break;
                        case 3:
                            para = "600";
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            if ("" != tx + para)
            {
                int cnt = 0;

                SerialPort_DataSend(tx + para);

                do
                {
                    if (_rxQueue.Count > 0)
                    {
                        string rx = _rxQueue.Dequeue();
                        
                        if ("exec success\n" == rx)
                        {
                            res = true;
                            break;
                        }
                        else if ("exec err\n" == rx)
                        {
                            res = false;
                            break;
                        }
                        else if ("cmd err\n" == rx)
                        {
                            res = false;
                            break;
                        }
                    }
                    else
                    {
                        Thread.Sleep(10);
                        cnt++;
                    }
                } while (cnt < 20);
            }

            return res;
        }

        private void VICTOR4080_DisConnect()
        {
            SerialPort_DataSend("SYSTEM:LOCAL");
        }

        private void SerialPort_DataSend(String tx)
        {
            _serialPort.WriteLine(tx); Console.WriteLine(tx);
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string rx = _serialPort.ReadExisting(); Console.WriteLine(rx);

            if (rx.Contains('.') && rx.Contains('e') && rx.Contains(','))
            {
                string[] nums = rx.Split(',');
                double num1 = double.Parse(nums[0]);
                double num2 = double.Parse(nums[1]);

                AddPoint(num1, num2);

                this.Invoke(new Action(() =>
                {
                    int decimalPlaces = 4;

                    // R || Z
                    if (comboBox2.SelectedIndex == 0 || comboBox2.SelectedIndex == 3)
                    {
                        string fmt = $"F{decimalPlaces}";

                        if(num1 < 0)
                        {
                            label9.Text = "N/A";
                        }
                        else if (num1 >= 1000000)
                        {
                            //兆欧 MΩ
                            double mOhm = num1 / 1000000;
                            label9.Text = $"{mOhm.ToString(fmt)} MΩ";
                        }
                        else if (num1 >= 1000)
                        {
                            //千欧 kΩ
                            double kOhm = num1 / 1000;
                            label9.Text = $"{kOhm.ToString(fmt)} kΩ";
                        }
                        else
                        {
                            //欧姆 Ω
                            double Ohm = num1;
                            label9.Text = $"{Ohm.ToString(fmt)} Ω";
                        }
                    }
                    //C
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        string fmt = $"F{decimalPlaces}";

                        if(num1 < 0)
                        {
                            label9.Text = "N/A";
                        }
                        else if (num1 >= 1)
                        {
                            //法 F
                            double f = num1;
                            label9.Text = $"{f.ToString(fmt)} F";
                        }
                        else if (num1 >= 1e-3)
                        {
                            //毫法 mF
                            double mf = num1 * 1000;
                            label9.Text = $"{mf.ToString(fmt)} mF";
                        }
                        else if (num1 >= 1e-6)
                        {
                            //微法 μF
                            double uf = num1 * 1000000;
                            label9.Text = $"{uf.ToString(fmt)} μF";
                        }
                        else if (num1 >= 1e-9)
                        {
                            //纳法 nF
                            double nf = num1 * 1000000000;
                            label9.Text = $"{nf.ToString(fmt)} nF";
                        }
                        else
                        {
                            //皮法 pF
                            double pf = num1 * 1000000000000;
                            label9.Text = $"{pf.ToString(fmt)} pF";
                        }
                    }
                    //L
                    else if (comboBox2.SelectedIndex == 2)
                    {
                        string fmt = $"F{decimalPlaces}";

                        if (num1 < 0)
                        {
                            label9.Text = "N/A";
                        }
                        else if (num1 >= 1)
                        {
                            //亨 H
                            double H = num1;
                            label9.Text = $"{H.ToString(fmt)} H";
                        }
                        else if (num1 >= 1e-3)
                        {

                            double mH = num1 * 1000;
                            label9.Text = $"{mH.ToString(fmt)} mH";
                        }
                        else if (num1 >= 1e-6)
                        {
                            //微亨 μH
                            double uH = num1 * 1000000;
                            label9.Text = $"{uH.ToString(fmt)} μH";
                        }
                        else
                        {
                            //纳亨 nH
                            double nH = num1 * 1000000000;
                            label9.Text = $"{nH.ToString(fmt)} nH";
                        }
                    }

                    //X || ESR
                    if (comboBox3.SelectedIndex == 0 || comboBox3.SelectedIndex == 4)
                    {
                        string fmt = $"F{decimalPlaces}";

                        if(num2 < 0)
                        {
                            label11.Text = "N/A";
                        }    
                        else if (num2 >= 1000000)
                        {
                            //兆欧 MΩ
                            double mOhm = num2 / 1000000;
                            label11.Text = $"{mOhm.ToString(fmt)} MΩ";
                        }
                        else if (num2 >= 1000)
                        {
                            //千欧 kΩ
                            double kOhm = num2 / 1000;
                            label11.Text = $"{kOhm.ToString(fmt)} kΩ";
                        }
                        else
                        {
                            //欧姆 Ω
                            double Ohm = num2;
                            label11.Text = $"{Ohm.ToString(fmt)} Ω";
                        }
                    }
                    //D || Q
                    else if (comboBox3.SelectedIndex == 1 || comboBox3.SelectedIndex == 2)
                    {
                        string fmt = $"F{decimalPlaces}";
                        label11.Text = $"{num2.ToString(fmt)}";
                    }
                    //θ
                    else if (comboBox3.SelectedIndex == 3)
                    {
                        string fmt = $"F{decimalPlaces}";
                        label11.Text = $"{num2.ToString(fmt)} °";
                    }
                }));
            }
            else
            {
                _rxQueue.Enqueue(rx);
            }
        }

        private void ShowSetting()
        {
            //功能
            label2.Text = lb2Func + lb2Func1 + lb2Func2 + lb2Func3 + lb2Func4;
            //量程
            label3.Text = lb3Range + lb3Range1;
            //速度
            label4.Text = lb4Speed + lb4Speed1;
            //频率
            label5.Text = lb5Freq + lb5Freq1;
            //电平
            label6.Text = lb6Level + lb6Level1;
            //偏置
            label7.Text = lb7Bias + lb7Bias1;
            //第一测量
            label8.Text = lb2Func1 + lb2Func2 + ":";
            //第二测量
            label10.Text = lb2Func4 + ":";
        }

        private void InitLable()
        {
            //功能
            label2.Text = "";
            //量程
            label3.Text = "";
            //速度
            label4.Text = "";
            //频率
            label5.Text = "";
            //电平
            label6.Text = "";
            //偏置
            label7.Text = "";
            //第一测量
            label8.Text = "";
            //第一测量结果
            label9.Text = "";
            //第二测量
            label10.Text = "";
            //第二测量结果
            label11.Text = "";
        }

        private void InitComboBox()
        {
            //串口
            comboBox1.Items.AddRange(SerialPort.GetPortNames());
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            //第一测量
            comboBox2.Items.Add("R");
            comboBox2.Items.Add("C");
            comboBox2.Items.Add("L");
            comboBox2.Items.Add("Z");
            comboBox2.SelectedIndex = 3;
            //第二测量
            comboBox3.Items.Add("X");
            comboBox3.Items.Add("D");
            comboBox3.Items.Add("Q");
            comboBox3.Items.Add("θ");
            comboBox3.Items.Add("ESR");
            comboBox3.SelectedIndex = 3;
            //串并联
            comboBox4.Items.Add("Serial");
            comboBox4.Items.Add("Pallel");
            comboBox4.SelectedIndex = 0;
            //量程
            comboBox5.Items.Add("10Ω");
            comboBox5.Items.Add("100Ω");
            comboBox5.Items.Add("1KΩ");
            comboBox5.Items.Add("10KΩ");
            comboBox5.Items.Add("100KΩ");
            comboBox5.Items.Add("1MΩ");
            comboBox5.Items.Add("自动");
            comboBox5.SelectedIndex = 6;
            //速度
            comboBox6.Items.Add("慢速（2/s）");
            comboBox6.Items.Add("中速（4/s）");
            comboBox6.Items.Add("快速（8/s）");
            comboBox6.SelectedIndex = 0;
            //频率
            comboBox7.Items.Add("100Hz");
            comboBox7.Items.Add("120Hz");
            comboBox7.Items.Add("1KHz");
            comboBox7.Items.Add("10KHz");
            comboBox7.Items.Add("40KHz");
            comboBox7.Items.Add("100KHz");
            comboBox7.SelectedIndex = 2;
            //电平
            comboBox8.Items.Add("300mV");
            comboBox8.Items.Add("600mV");
            comboBox8.Items.Add("1000mV");
            comboBox8.SelectedIndex = 2;
            //偏置
            comboBox9.Items.Add("0mV");
            comboBox9.Items.Add("100mV");
            comboBox9.Items.Add("300mV");
            comboBox9.Items.Add("600mV");
            comboBox9.SelectedIndex = 0;
        }

        private void InitRenderTimer()
        {
            _renderTimer = new System.Windows.Forms.Timer();
            _renderTimer.Interval = 20;
            _renderTimer.Tick += RenderTimer_Tick;
            _renderTimer.Start();
        }

        private void RenderTimer_Tick(object? sender, EventArgs e)
        {
            _plt.Axes.AutoScale();
            formsPlot1.Refresh();
        }

        private void InitChart()
        {
            _plt = formsPlot1.Plot;
            _plt.Clear();

            // 曲线A
            _loggerA = _plt.Add.DataLogger();
            _loggerA.Color = Colors.Blue;
            _loggerA.LegendText = "模拟量A";
            _loggerA.LineWidth = 2;
            _loggerA.MarkerStyle.IsVisible = false; // 不显示圆点，纯线条
            _loggerA.ViewSlide(ViewMaxPoint);       // 开启滑动窗口，参数=窗口最大点数

            // 曲线B
            _loggerB = _plt.Add.DataLogger();
            _loggerB.Color = Colors.Red;
            _loggerB.LegendText = "模拟量B";
            _loggerB.LineWidth = 2;
            _loggerB.MarkerStyle.IsVisible = false;
            _loggerB.ViewSlide(ViewMaxPoint);

            // X轴时间格式化
            _plt.Axes.DateTimeTicksBottom();
            _plt.XLabel("采集时间");
            _plt.YLabel("模拟量数值");

            _plt.Legend.IsVisible = true;
            _plt.Grid.IsVisible = true;
            _plt.Font.Set("微软雅黑");
        }

        private void AddPoint(double valueA, double valueB)
        {
            if (formsPlot1.InvokeRequired)
            {
                formsPlot1.Invoke(new Action(() => AddPoint(valueA, valueB)));
                return;
            }

            DateTime now = DateTime.Now;
            double xOa = now.ToOADate();

            // 1. 全量存入List，永久保存用于导出CSV
            _allTime.Add(now);
            _valA.Add(valueA);
            _valB.Add(valueB);

            // 2. 写入绘图DataLogger（自动滑动窗口）
            _loggerA.Add(xOa, valueA);
            _loggerB.Add(xOa, valueB);
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            if (_allTime.Count == 0)
            {
                MessageBox.Show("暂无采集数据");
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV文件 (*.csv)|*.csv";
            sfd.FileName = $"采集数据_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            List<string> rows = new List<string> { "采集时间,模拟量A,模拟量B" };
            for (int i = 0; i < _allTime.Count; i++)
            {
                string timeStr = _allTime[i].ToString("yyyy-MM-dd HH:mm:ss.fff");
                rows.Add($"{timeStr},{_valA[i]},{_valB[i]}");
            }

            File.WriteAllLines(sfd.FileName, rows, System.Text.Encoding.UTF8);
            MessageBox.Show($"导出成功，共{_allTime.Count}条记录");
        }
    }
}
