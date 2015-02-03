using System;
using System.Runtime.InteropServices;
namespace ThirdLibrary
{
    partial class AlarmSound
    {
        [DllImport("winmm")]
        public static extern bool PlaySound(string strSound, IntPtr hMod, PlaySoundFlags flags);

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        [Flags]
        public enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0000, SND_ASYNC = 0x0001, SND_NODEFAULT = 0x0002,SND_MEMORY = 0x0004,SND_LOOP = 0x0008, SND_NOSTOP = 0x0010,SND_NOWAIT = 0x00002000,SND_ALIAS = 0x00010000,SND_ALIAS_ID = 0x00110000, SND_FILENAME = 0x00020000,SND_RESOURCE = 0x00040004
        }

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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
        }

        #endregion

    }
}
