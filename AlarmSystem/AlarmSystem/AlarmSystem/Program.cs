using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AlarmSystem;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int iProcessNum = 0;

            foreach (Process singleProc in Process.GetProcesses())
            {
                if (singleProc.ProcessName == Process.GetCurrentProcess().ProcessName)
                {
                    iProcessNum += 1;
                }
            }
            if (iProcessNum > 1)
            {
                MessageBox.Show("该程序已经在运行中!", "报警系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LED屏幕报警显示());
            }
        }
    }
}
