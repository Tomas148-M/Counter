using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace Counter_train_Potucek
{
    public partial class Form1 : Form
    {
        private byte min = 0;
        private byte hod = 0;
        private byte sec = 0;
        string finalsec = "";
        string finalmin = "";
        string finalhod = "";
        public int interval=1;
        public int font = 20;
        public System.Timers.Timer aTimer = new System.Timers.Timer();

        public Form1()
        {
            InitializeComponent();
            set_position();
            Set_Interval();
            SetTimer();
        }
        public void zmena()
        {
            Set_Interval();
        }

        private void SetTimer()
        {
            aTimer.Elapsed += RaiseTimerEvent;
            aTimer.Enabled = true;
        }

        private void Set_Interval()
        {
            aTimer.Interval = 990/interval;
        }

        public void set_position()
        {
            Size loc2 = caption.Size;
            Point loc = caption.Location;
            loc.X = (this.Width / 2) - (loc2.Width / 2);
            loc.Y = (this.Height / 2) - (loc2.Height / 2)-30;
            caption.Location = loc;
        }

        public void Set_Font()
        {
            //Arial Rounded MT Bold; 80,25pt
            FontFamily fontFamily = new FontFamily("Arial Rounded MT");
            Font font = new Font(
               fontFamily,
               16,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
        }
        private void RaiseTimerEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
        
            this.Invoke(new Action(() =>
            {
                    sec++;
                    Set_time();
                    
                    if (sec < 10)
                        finalsec = "0" + sec.ToString();
                    else
                        finalsec = sec.ToString();

                    if (min < 10)
                        finalmin = "0" + min.ToString();
                    else
                        finalmin = min.ToString();

                    if (hod < 10)
                        finalhod = "0" + hod.ToString();
                    else
                        finalhod = hod.ToString();

                    caption.Text = finalhod + " : " + finalmin + " : " + finalsec;

            }));
        }
        private void Set_time()
        {
            if (sec == 60)
            {
                sec = 0;
                min++;
            }
            if (min == 60)
            {
                min = 0;
                hod++;
            }
            if (hod == 24)
            {
                hod = 0;
            }
        }


        private void caption_AutoSizeChanged(object sender, EventArgs e)
        {
            set_position();
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            Setting settingsForm = new Setting(this);
            settingsForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    
}
