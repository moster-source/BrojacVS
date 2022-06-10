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

        int intMinute;
        int intSekunde;
        System.Threading.Timer t;
        public static System.Timers.Timer _timer = new System.Timers.Timer();
        //System.Threading.Timer t = new System.Threading.Timer(TimerCallbackx, null, 0, 1000);
        //https://docs.microsoft.com/en-us/dotnet/api/system.timers.timer.elapsed?view=net-6.0
        public Form1()


        {
            InitializeComponent();
            
            
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

        private void label1_Click(object sender, EventArgs e)
        {
            if t.enabled
            t = new System.Threading.Timer(TimerCallbackx, null, 0, 1000);
        }
        private static void TimerCallbackx(Object o)

        {
            //Console.WriteLine("In TimerCallback: " + DateTime.Now);
            DialogResult d;
            d = MessageBox.Show("Timer call back", "timjer test", MessageBoxButtons.OK);
            SystemSounds.Beep.Play();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            try
            {
                intMinute = Convert.ToInt32(txtVrijeme.Text);
                lblVrijeme.Text = intMinute.ToString() + ":" + "00";
                intSekunde = 0;
            }
            catch (FormatException)
            {
                intMinute = 0;
                intSekunde = 0;
                lblVrijeme.Text = intMinute.ToString() + ":" + "00";
            }
            

        }
    }
}
