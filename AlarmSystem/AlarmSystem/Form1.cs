using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

//using System.Speech.Synthesis;

namespace AlarmSystem
{
    public partial class Form1 : Form
    {
        short CardType;          //控制卡类型,2型卡
        short ComPort;          //串口1
        int ComBaudRate;  //通讯速率
        short ComDelay;      //延时
        short LedNum;           //屏号
        short LedWidth;       //屏宽
        short LedHeight;      //屏高
        short LedColor;         //双色屏
        //AlarmThread am;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string err = "";
            err = getErr();
            if (err != "")
            {
                MessageBox.Show(err);
                return;
            }
            AppConfig.SaveValue("Config", "IsConfigruation", "1");
            AppConfig.SaveValue("Config", "DBName", txtDBName.Text.Trim());
            AppConfig.SaveValue("Config", "DBServer", txtDBServer.Text.Trim());
            AppConfig.SaveValue("Config", "DBUserName", txtDBUserName.Text.Trim());
            AppConfig.SaveValue("Config", "DBPassWd", CryptDes.EncryptDES(txtPassWd.Text, "EncryDes"));
            AppConfig.SaveValue("LED", "CardType", comboBox2.Text);//卡型号
            AppConfig.SaveValue("LED", "ComPort", comboBox1.Text);//串口
            AppConfig.SaveValue("LED", "ComBaudRate", txt_ComBaudRate.Text);//波特率
            AppConfig.SaveValue("LED","ComDelay","1000");//延时
            AppConfig.SaveValue("LED", "LedNum","0");
            AppConfig.SaveValue("LED", "LedWidth",txt_LedWidth.Text);//屏宽
            AppConfig.SaveValue("LED","LedHeight",txt_ledHeght.Text);//屏高
            if (radioButton1.Checked)
            {
                AppConfig.SaveValue("LED", "LedColor", "1");//双色屏
            }
            if (radioButton2.Checked)
            {
                AppConfig.SaveValue("LED","LedColor","2");//单色屏
            }
            MessageBox.Show("修改成功,更改后的配置将在系统重启后生效!", "循环报警系统", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close();
        }

        private string getErr()
        {
            string err = "";
            if (comboBox1.Text == "")
            {
                err += "请输入串口号；";
            }
            if (comboBox2.Text == "")
            {
                err += "请选择卡型号；";
            }
            if (txt_ComBaudRate.Text == "")
            {
                err += "请选择串口；";
            }
            if (txt_ledHeght.Text == "")
            {
                err += "请输入屏高；";
            }
            if (txt_LedWidth.Text == "")
            {
                err += "请输入屏宽；";
            }
            if (txtDBName.Text == "")
            {
                err += "请输入数据库名；";
            }
            if (txtDBServer.Text == "")
            {
                err += "请输入服务器名；";
            }
            if (txtDBUserName.Text == "")
            {
                err += "请输入数据库登陆名；";
            }
            if (txtPassWd.Text == "")
            {
                err += "请输入数据库密码；";
            }
            return err;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (AppConfig.ReadValue("Config", "IsConfigruation") == "1")
            {
                txtDBName.Text = AppConfig.ReadValue("Config", "DBName");
                txtDBServer.Text = AppConfig.ReadValue("Config", "DBServer");
                txtDBUserName.Text = AppConfig.ReadValue("Config", "DBUserName");
                txtPassWd.Text = CryptDes.DecryptDES(AppConfig.ReadValue("Config", "DBPassWd"), "EncryDes");
                this.Text = this.Text + AppConfig.ReadValue("Config", "Version");
                CardType = short.Parse(AppConfig.ReadValue("LED","CardType"));
                ComPort = short.Parse(AppConfig.ReadValue("LED","ComPort"));
                ComBaudRate = int.Parse(AppConfig.ReadValue("LED", "ComBaudRate"));
                ComDelay = short.Parse(AppConfig.ReadValue("LED", "ComDelay"));
                LedNum = short.Parse(AppConfig.ReadValue("LED","LedNum"));
                LedWidth = short.Parse(AppConfig.ReadValue("LED","LedWidth"));
                LedHeight = short.Parse(AppConfig.ReadValue("LED","LedHeight"));
                LedColor = short.Parse(AppConfig.ReadValue("LED","LedColor"));
                SqlHelp.ConnString = "Data Source=" + txtDBServer.Text + ";Initial Catalog=" + txtDBName.Text + ";User ID=" + txtDBUserName.Text + ";Password=" + txtPassWd.Text;
               // DbHelperSQL.connectionString = "Data Source=" + txtDBServer.Text + ";Initial Catalog=" + txtDBName.Text + ";User ID=" + txtDBUserName.Text + ";Password=" + txtPassWd.Text;

                //----------------------------------尝试判断数据库连接是否正确------------------------------------
                try
                {

                   // am = new AlarmThread(CardType, ComPort, ComBaudRate, LedNum, ComDelay, LedWidth, LedHeight, LedColor);
                   // am.Show();
                    //WindowState = FormWindowState.Minimized; Hide();

                }
                catch (Exception exc)
                {
                    MessageBox.Show("数据库配置错误," + exc.Message.ToString(), "循环报警系统", MessageBoxButtons.OK, MessageBoxIcon.Error); Show(); this.Activate();
                }
                //------------------------------------------------------------------------------------------------
            }
            else
            {
                MessageBox.Show("请设置报警系统数据库和LED屏设置", "循环报警系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Show(); WindowState = FormWindowState.Normal; txtPassWd.Text = ""; txtPassWd.Text = CryptDes.DecryptDES(AppConfig.ReadValue("Config", "DBPassWd"), "EncryDes");
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowState = FormWindowState.Minimized; Hide(); e.Cancel = true;
        }

        private void lblDBServer_Click(object sender, EventArgs e)
        {

        }

        private void lblDBName_Click(object sender, EventArgs e)
        {

        }

        private void txtDBServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDBName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDBUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDBUserName_Click(object sender, EventArgs e)
        {

        }

        private void lblPassWd_Click(object sender, EventArgs e)
        {

        }

        private void txtPassWd_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_ComBaudRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_LedWidth_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_ledHeght_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void gbConfig_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}
