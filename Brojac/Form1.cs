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

        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

        public Form1()


        {
            InitializeComponent();
            t.Interval = 1000; // specify interval time as you want
            t.Tick += new EventHandler(timer_Tick);
            t.Enabled = false;


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
            }
            else 
            {
                t.Start();
            }
        }

        private static void timer_Tick(object sender, EventArgs e) { //funkcija timera

            //DialogResult d;
            //d = MessageBox.Show("Timer call back", "timjer test", MessageBoxButtons.OK);

            Console.WriteLine("In TimerCallback: " + DateTime.Now);


        }

        /*
                private static void TimerCallbackx(Object o)

                {
                    //Console.WriteLine("In TimerCallback: " + DateTime.Now);
                    DialogResult d;
                    d = MessageBox.Show("Timer call back", "timjer test", MessageBoxButtons.OK);
                    SystemSounds.Beep.Play();
                }
        */
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
