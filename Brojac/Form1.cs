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
            txtVrijeme.Visible = false;
            label2.Visible = false;
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
                sec = 0;
                min = minEntered;
                return;
            }
            else
            {
                if (this.BackColor == Color.Red)
                {
                    pocrveni(false);
                }

                if (min == 0)
                {
                    return;
                }
                sec = 59;
                min = minEntered - 1;
                //this.lblVrijeme.Text = min.ToString() + ":" + sec.ToString();
                this.lblVrijeme.Text = String.Format("{0:00}", min) + ":" + String.Format("{0:00}", sec);
                t.Enabled = true;
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
                    min = minEntered;
                    SystemSounds.Beep.Play();
                    //lblVrijeme.Text = minEntered.ToString() + ":" + sec.ToString();
                    this.lblVrijeme.Text = String.Format("{0:00}", min) + ":" + String.Format("{0:00}", sec);
                    pocrveni(true);
                    t.Stop();
                    return;
                }
            }
            //lblVrijeme.Text = min.ToString() + ":" + sec.ToString();
            this.lblVrijeme.Text = String.Format("{0:00}", min) + ":" + String.Format("{0:00}", sec);
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
                minEntered = min;
                sec = 0;
                //lblVrijeme.Text = min.ToString() + ":" + "00";
                this.lblVrijeme.Text = String.Format("{0:00}", min) + ":" + String.Format("{0:00}", sec);
                txtVrijeme.Visible = false;
                txtVrijeme.Text = "";
                label2.Visible = false;
                lblVrijeme.Visible = true;
                label1.Visible = true;
                
            }
            catch (FormatException)
            {
                min = 0;
                min = 0;
                //lblVrijeme.Text = min.ToString() + ":" + "00";
                this.lblVrijeme.Text = String.Format("{0:00}", min) + ":" + String.Format("{0:00}", sec);
                txtVrijeme.Visible = false;
                txtVrijeme.Text = "";
                label2.Visible = false;
                lblVrijeme.Visible = true;
                label1.Visible = true;
            }
        }
        private void pocrveni(Boolean blnCrveni) {
            if (blnCrveni)
            {
                //ControlLight
                this.BackColor = Color.Red;
                this.lblVrijeme.BackColor = Color.Red;
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.lblVrijeme.BackColor = SystemColors.Control;
            }
              
        }

        private void txtVrijemeEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                this.label2_Click(sender,e);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //min = 0;
            //sec = 0;
            this.lblVrijeme.Text = String.Format("{0:00}", min) + ":" + String.Format("{0:00}", sec);
            //lblVrijeme.Text = string.Format("{0:00}", min);
        }

        private void lblVrijemeMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //ReleaseCapture();
                txtVrijeme.Visible = true;
                label2.Visible = true;
                label1.Visible = false;
                lblVrijeme.Visible=false;
                pocrveni(false);
                this.txtVrijeme.Focus();
                //MessageBox.Show("", "");
                t.Stop();
            }
        }

    }
}
