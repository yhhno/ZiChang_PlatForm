using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Video : Form
    {
        public Video()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dhVideo1.Initialize("172.10.14.18", 1, "888888", "888888", "aa.jpg");
            this.dhVideo2.Initialize("172.10.14.18", 2, "888888", "888888", "bb.jpg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dhVideo1.Close();
            this.dhVideo2.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
