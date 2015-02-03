using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Speech.Synthesis;



namespace ThirdLibrary
{
    [ToolboxBitmap(typeof(AlarmSound), "Resources.AlarmSound.bmp")]
    public partial class AlarmSound : Component
    {
        SpeechSynthesizer Talker = new SpeechSynthesizer();
        public AlarmSound(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public void Alarm(string strAlarm)
        {
            try
            {
                Talker.Rate = 2;//控制语速(-10--10)
                Talker.Volume = 100;//控制音量

                #region 获取本机上所安装的所有的Voice的名称
                //string voicestring = "";

                //foreach (InstalledVoice iv in Talker.GetInstalledVoices())
                //{
                //    voicestring += iv.VoiceInfo.Name + ",";
                //}
                //Microsoft Mary,Microsoft Mike,Microsoft Sam,Microsoft Simplified Chinese,SampleTTSVoice
                //Talker.SelectVoice("Microsoft Mary");
                #endregion

                //Talker.SetOutputToWaveFile("c:\soundfile.wav");//读取文件
          
                Talker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Child, 2, System.Globalization.CultureInfo.CurrentCulture);
                Talker.SpeakAsync(strAlarm);
            }
            catch(Exception ex)
            {
                Log.WriteLog("语音提示控件", ex);
            }
        }

    }
}
