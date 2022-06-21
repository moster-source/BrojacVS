using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
//using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brojac


{


    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        public static System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        public static int min;
        public static int sec;
        public static int minEntered;



        public Form1()
        {
            InitializeComponent();
            t.Interval = 1000; // specify interval time as you want
            t.Tick += new EventHandler(timer_Tick);
            t.Enabled = false;

            min = 15;
            minEntered = 15;
            sec = 0;

        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblVrijemeMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label1_Click(object sender, EventArgs e) //klik na start
        {
            if (t.Enabled)
            {
                t.Stop();
                sec=0;
                min = minEntered;
                return;
            }
            else 
            {
                //if backcolor red then poplavi
                t.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (sec == 0) 
            {
                if (min == 1)
                {
                    SystemSounds.Beep.Play();
                    //lblVrijeme.Text = "";
                }
                if (min == 0) {
                    lblVrijeme.Text =min.ToString() + ":" + sec.ToString();
                    min = minEntered;
                    t.Stop();
                    return;
                }
            }
            
            lblVrijeme.Text = min.ToString() + ":" + sec.ToString();
            sec = sec - 1;
            
            if (sec == -1) {
                sec = 59;
                min = min - 1;
            }

        }
        private void label2_Click(object sender, EventArgs e)
        {
            try
            {
                min = Convert.ToInt32(txtVrijeme.Text);
                lblVrijeme.Text = min.ToString() + ":" + "00";
                sec = 0;
            }
            catch (FormatException)
            {
                min = 0;
                min = 0;
                lblVrijeme.Text = min.ToString() + ":" + "00";
            }
            

        }
    }
}
